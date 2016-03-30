﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;
using System.ComponentModel;

namespace ArkConfigurationTool
{
    public partial class MainWindow : Window
    {

        private int xpStep = 40000;

        private Boolean isFirstRun = true;
        private Boolean isDebugMode = true;

        private List<String> serverNames;
        private List<String> profiles;

        private Process serverProcess;

        /// <summary>
        ///     Initializes the program
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            serverNames = new List<string>();
            profiles = new List<string>();

            performSetup();

            load();
        }

        /// <summary>
        ///     Sets up the environment for the configuration tool
        /// </summary>
        public void performSetup()
        {
            ConfigData settings = new ConfigData("settings", "ArkConfigurationTool\\");

            List<String> options = new List<String>();

            String[] keys =
            {
                "isFirstRun",
                "isDebugMode",
                "serverList",
                "profileList"
            };

            String[] values =
            {
                "0",
                "0",
                "",
                ""
            };

            if (!File.Exists("ArkConfigurationTool\\settings.act"))
            {
                /*  
                    no config file, set up:

                    Create directories
                    Install SteamCMD
                    Create config file
                */

                // Create Directories
                String[] dirs =
                {
                    Reference.serversDirectory,
                    Reference.profilesDirectory,
                    Reference.steamCmdDirectory,
                    Reference.logsDirectory
                };

                foreach(String directory in dirs)
                {
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }

                // Install SteamCMD
                if(!File.Exists(Reference.steamCmdDirectory + "steamcmd.exe"))
                {
                    // Download
                    List<String> lines = new List<String>();

                    lines.Add("");
                    lines.Add("=====================================");
                    lines.Add("        Downloading SteamCMD         ");
                    lines.Add("=====================================");
                    lines.Add("");

                    foreach (String line in lines)
                    {
                        handleOutput(line);
                    }

                    String fileUrl = Reference.steamCmdUrl;
                    String destination = Reference.steamCmdDirectory + "steamCMD.zip";
                    download(fileUrl, destination);
                }
            }
            else
            {
                // load settings
                options = settings.read();

                for(int i = 0; i < options.Count; i++)
                {
                    String[] option = options[i].Split('=');

                    String key = option[0];
                    String value = option[1];

                    switch(options[i])
                    {
                        case "isFirstRun":
                            values[0] = value;
                            break;
                        case "isDebugMode":
                            values[1] = value;
                            break;
                        case "serverList":
                            values[2] = value;
                            break;
                        case "profileList":
                            values[3] = value;
                            break;
                    }
                }
            }

            // set variables
            isFirstRun = values[0] == "1";
            isDebugMode = values[1] == "1";
            serverNames.AddRange(values[2].Split(','));
            profiles.AddRange(values[3].Split(','));

            // save changes
            saveConfig(keys, values);

        }

        /// <summary>
        ///     Downloads a file
        /// </summary>
        public void download(String fileUrl, String destination)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += downloadProgressChanged;
            webClient.DownloadFileAsync(new Uri(fileUrl), destination);

            webClient.DownloadFileCompleted += downloadComplete;
        }

        /// <summary>
        ///     Updates the log on download progress
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Event arguments</param>
        private void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            String line = (String.Format("{0}    downloaded {1} of {2} bytes. {3} % complete...",
                    (string)e.UserState,
                    e.BytesReceived,
                    e.TotalBytesToReceive,
                    e.ProgressPercentage));

            handleOutput(line);
        }

        /// <summary>
        ///     Triggered when download completes
        /// </summary>
        /// 
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">The arguments for the event</param>
        private void downloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            // unzip
            List<String> lines = new List<String>();

            lines.Add("");
            lines.Add("=====================================");
            lines.Add("         Unzipping SteamCMD          ");
            lines.Add("=====================================");
            lines.Add("");
            
            foreach (String line in lines)
            {
                handleOutput(line);
            }

            ZipFile.ExtractToDirectory(Reference.steamCmdDirectory + "steamCMD.zip", Reference.steamCmdDirectory);

            // remove zip file
            lines = new List<String>();

            lines.Add("");
            lines.Add("=====================================");
            lines.Add("         SteamCMD Installed          ");
            lines.Add("=====================================");
            lines.Add("");

            foreach (String line in lines)
            {
                handleOutput(line);
            }

            File.Delete(Reference.steamCmdDirectory + "steamCMD.zip");
;        }

        /// <summary>
        ///     Loads the current servers, profiles, etc...
        /// </summary>
        public void load()
        {
            // Check Folder exists
            if(!Directory.Exists(Reference.serversDirectory))
            {
                Directory.CreateDirectory(Reference.serversDirectory);
            }

            // load servers
            if(serverNames.Count > 0)
            {
                serverNames.AddRange(Directory.GetDirectories(Reference.serversDirectory));
                for (int i = 0; i < serverNames.Count; i++)
                {
                    if (serverNames[i].Equals(""))
                    {
                        continue;
                    }

                    String server = serverNames[i].Substring(29);

                    MenuItem item = new MenuItem();
                    item.Header = server;
                    item.Click += new RoutedEventHandler(loadServer);
                    openServer.Items.Add(item);
                }
            }

            // Check Folder exists
            if (!Directory.Exists(Reference.profilesDirectory))
            {
                Directory.CreateDirectory(Reference.profilesDirectory);
            }

            // load profiles
            if(profiles.Count > 0)
            {
                profiles.AddRange(Directory.GetDirectories(Reference.profilesDirectory));
                for (int i = 0; i < profiles.Count; i++)
                {
                    if (profiles[i].Equals(""))
                    {
                        continue;
                    }

                    String profile = profiles[i].Substring(30);

                    MenuItem item = new MenuItem();
                    item.Header = profile;
                    item.Click += new RoutedEventHandler(loadServerProfile);
                    loadProfile.Items.Add(item);
                }
            }
        }

        /// <summary>
        ///     Saves the settings file
        /// </summary>
        /// 
        /// <param name="keys">The array of keys to use for values</param>
        /// <param name="values">the values to write to file</param>
        private void saveConfig(String[] keys, String[] values)
        {

            ConfigData settings = new ConfigData("settings", "ArkConfigurationTool\\");

            List<String> options = new List<String>();

            // Create server list string
            String serverList = "";

            for (int i = 0; i < serverNames.Count; i++)
            {
                serverList += serverNames[i];

                if (i != serverNames.Count - 1)
                {
                    serverList += ",";
                }
            }

            values[2] = serverList;

            // create profile list string
            String profileList = "";

            for (int i = 0; i < profiles.Count; i++)
            {
                profileList += profiles[i];

                if (i != profiles.Count - 1)
                {
                    profileList += ",";
                }
            }

            values[3] = profileList;

            // create options list
            for (int i = 0; i < keys.Length; i++)
            {
                options.Add(keys[i] + "=" + values[i]);
            }

            // Write to file
            settings.write(options);
        }

        /// <summary>
        ///     Loads a server when selected from the "Open Server..." menu item
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Arguments for the event</param>
        private void loadServer(Object sender, RoutedEventArgs e)
        {
            // get server name
            // load settings etc...
        }


        /// <summary>
        ///     Loads a profile when selected from the "Open Profile..." menu item
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Arguments for the event</param>
        private void loadServerProfile(Object sender, RoutedEventArgs e)
        {
            // load settings from profile
        }


        /// <summary>
        ///     Navigates to a link when clicked
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Arguments for the event</param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // open link here
        }


        /// <summary>
        ///     Saves the server settings when clicked
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Arguments for the event</param>
        private void generateClick(object sender, RoutedEventArgs e)
        {
            // Save server here
        }

        /// <summary>
        ///     Executes a Command Prompt command and directs the output to the
        ///     output TextBox
        /// </summary>
        /// 
        /// <param name="command">The command to run</param>
        /// <param name="isStartServer">Whether or not the process being started is the server process</param>
        private void executeCommand(string command, Boolean isStartServer)
        {
            // set up cmd for command
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            // begin cmd
            var process = Process.Start(processInfo);

            // Set handler for Output
            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                handleOutput(e.Data);
            process.BeginOutputReadLine();

            // Set handler for Error(s)
            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                handleOutput(e.Data);
            process.BeginErrorReadLine();

            // hold onto server if is server process
            if(isStartServer)
            {
                serverProcess = process;
            }

            // wait til done
            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

        /// <summary>
        ///     Outputs the given text to the output TextBox
        /// </summary>
        /// 
        /// <param name="text">The text to output</param>
        private void handleOutput(String text)
        {
            consoleOutput.AppendText(text + "\n");
            consoleOutput.ScrollToEnd();
        }

        /// <summary>
        ///     Collects and condenses the list of server settings that belong
        ///     in GameUserSettings.ini
        /// </summary>
        /// 
        /// <returns>The finalized list of server settings ready for writing to file</returns>
        private List<String> generateGameUserIni()
        {
            List<String> settings = new List<string>();

            Boolean[] defaultFalse =
            {
                (Boolean)joinNotify.IsChecked,
                (Boolean)thirdPerson.IsChecked,
                (Boolean)mapLocation.IsChecked,
                (Boolean)tributeDownloads.IsChecked,
                (Boolean)proximityChat.IsChecked,
                (Boolean)serverPve.IsChecked,
                (Boolean)serverHardcore.IsChecked,
                (Boolean)allowHud.IsChecked,
                (Boolean)flyerCarryPve.IsChecked,
                (Boolean)caveBuildPve.IsChecked,
                (Boolean)dinosaurDecay.IsChecked
            };

            Boolean[] defaultTrue =
            {
                (Boolean)leaveNotify.IsChecked,
                (Boolean)globalChat.IsChecked,
                (Boolean)structureDecayPve.IsChecked,
                (Boolean)structureDecayPvp.IsChecked,
            };

            float[] floatValues =
            {
                // Default 1.0
                float.Parse(structureDistance.Text),
                float.Parse(daySpeed.Text),
                float.Parse(nightSpeed.Text),
                float.Parse(dayCycle.Text),
                float.Parse(playerDamage.Text),
                float.Parse(dinoDamage.Text),
                float.Parse(structureDamage.Text),
                float.Parse(playerResist.Text),
                float.Parse(dinoResist.Text),
                float.Parse(structureResist.Text),
                float.Parse(structureDecayMultiplier.Text),
                float.Parse(dinoCount.Text),
                float.Parse(xpMultiplier.Text),
                float.Parse(pveStructureDecayMultiplier.Text),
                float.Parse(pveStructureDestructionPeriod.Text),
                float.Parse(saddleStructureLimit.Text),
                float.Parse(perPlatformStructureMultiplier.Text),
                float.Parse(tameMultiplier.Text),
                float.Parse(harvestMultiplier.Text),
                float.Parse(resourceHealth.Text),
                float.Parse(resourceRespawn.Text),
                float.Parse(playerWater.Text),
                float.Parse(playerFood.Text),
                float.Parse(playerStamina.Text),
                float.Parse(playerHealth.Text),
                float.Parse(dinoFood.Text),
                float.Parse(dinoStamina.Text),
                float.Parse(dinoHealth.Text),

                // Default 4.0
                float.Parse(difficulty.Text)
            };

            int[] intValues =
            {
                // Default 50
                int.Parse(maxPlayers.Text)
            };

            String[] stringValues =
            {
                // Default blank
                serverPassword.Text,
                adminPassword.Text,
                spectatorPassword.Text,
                banList.Text
            };

            GameUserIni game = new GameUserIni();
            settings = game.write(defaultFalse, defaultTrue, floatValues, stringValues, intValues);

            return settings;
        }


        /// <summary>
        ///     Collects and condenses the list of server settings that belong
        ///     in Game.ini
        /// </summary>
        /// 
        /// <returns>The finalized list of server settings ready for writing to file</returns>
        private List<String> generateGameIni()
        {
            List<String> settings = new List<string>();

            /*
            
                *OverrideEngramEntries=(
                EngramIndex=<index>
                [,EngramHidden=<hidden>]
                [,EngramPointsCost=<cost>]
                [,EngramLevelRequirement=<level>]
                [,RemoveEngramPreReq=<remove_prereq>]
                )    

                *DinoSpawnWeightMultipliers=(
                DinoNameTag=<tag>
                [,SpawnWeightMultiplier=<factor>]
                [,OverrideSpawnLimitPercentage=<override>]
                [,SpawnLimitPercentage=<limit>]
                )

                ?harvestResourceItemAmountClassMultipliers=(
                className="<classname>",
                multiplier=<valule>
                )
                
                *preventDinoTameClassNames

                *npcReplacements=(
                fromClassName="<className>"
                toClassName="<toClassName>"
                )

                ?
                perLevelStatsMultiplier_Player<type>[<attribute>]
                perLevelStatsMultiplier_DinoTamed<type>[<attribute>]
                perLevelStatsMultiplier_DinoWild<type>[<attribute>]
                ?
            */

            float[] floatValues =
            {
                float.Parse(resourceReplenishPlayer.Text),
                float.Parse(resourceReplenishStructure.Text),
                float.Parse(matingInterval.Text),
                float.Parse(eggHatch.Text),
                float.Parse(babyMature.Text),
                float.Parse(babyFood.Text),
                float.Parse(eggInterval.Text),
                float.Parse(poopInterval.Text),
                float.Parse(cropDecay.Text),
                float.Parse(structureDamageCooldown.Text),
                float.Parse(dinoHarvestDamage.Text),
                float.Parse(playerHarvestDamage.Text),
                float.Parse(dinoTurretDamage.Text),
                float.Parse(pvpRespawn.Text),
                float.Parse(pvpRespawnMultiplier.Text),
                float.Parse(pvpRespawnBase.Text)
        };
            

            Boolean[] boolValues =
            {
                (Boolean)passiveDefenseDamageDinos.IsChecked,
                (Boolean)pvpRespwanInterval.IsChecked,
                (Boolean)autoPve.IsChecked,
                (Boolean)autoPveUsesSystemTime.IsChecked
            };

            GameIni game = new GameIni(int.Parse(levelCap.Text), xpStep, int.Parse(engramStep.Text), int.Parse(lvlStep.Text));
            settings = game.write(boolValues, floatValues);

            return settings;
        }

        /// <summary>
        ///     Starts the server upon start click
        /// </summary>
        /// 
        /// <param name="sender">the object that sent this event</param>
        /// <param name="e">the event arguments</param>
        private void startClick(object sender, RoutedEventArgs e)
        {
            startServer();
        }

        /// <summary>
        ///     Stops the server upon start click
        /// </summary>
        /// 
        /// <param name="sender">the object that sent this event</param>
        /// <param name="e">the event arguments</param>
        private void stopClick(object sender, RoutedEventArgs e)
        {
            stopServer();
        }

        /// <summary>
        ///     Updates the server upon start click
        /// </summary>
        /// 
        /// <param name="sender">the object that sent this event</param>
        /// <param name="e">the event arguments</param>
        private void updateClick(object sender, RoutedEventArgs e)
        {
            Boolean wasRunning;

            wasRunning = stopServer();
            updateServer();

            if(wasRunning)
            {
                startServer();
            }
        }

        /// <summary>
        ///     Performs the action of starting the server
        /// </summary>
        private void startServer()
        {
            // Run start script
            toggleButtons(true);

            List<String> lines = new List<string>();

            lines.Add("");
            lines.Add("=====================================");
            lines.Add("         Starting Server             ");
            lines.Add("=====================================");
            lines.Add("");

            foreach(String line in lines)
            {
                handleOutput(line);
            }

            if(!canStartServer())
            {
                // error

                return;
            }

            String[] startArgs = new String[3]
            {
                serverName.Text,
                serverMap.Text,
                ""
            };

            String extras = "";
            if(!modList.Text.Equals(""))
            {
                extras += "?GameModIds=" + modList;
            }

            startArgs[2] = extras;

            String start = String.Format(Reference.cmdStartServer, startArgs);
            executeCommand(start, true);
        }

        /// <summary>
        ///     Performs the action of stopping the server
        /// </summary>
        /// 
        /// <returns>true if the server was running before stopping</returns>
        private Boolean stopServer()
        {
            Boolean wasRunning = false;

            // Stop server here
            toggleButtons(false);
            if(serverProcess != null)
            {
                List<String> lines = new List<string>();

                lines.Add("");
                lines.Add("=====================================");
                lines.Add("         Stopping Server             ");
                lines.Add("=====================================");
                lines.Add("");

                foreach (String line in lines)
                {
                    handleOutput(line);
                }

                serverProcess.Close();
                wasRunning = true;
            }

            return wasRunning;
        }

        /// <summary>
        ///     Performs the action of updating the server
        /// </summary>
        private void updateServer()
        {
            // Update server here
            List<String> lines = new List<string>();

            lines.Add("");
            lines.Add("=====================================");
            lines.Add("         Updating Server             ");
            lines.Add("=====================================");
            lines.Add("");

            foreach (String line in lines)
            {
                handleOutput(line);
            }

            String update = String.Format(Reference.cmdUpdateServer, serverName.Text);
            executeCommand(update, false);
        }

        /// <summary>
        ///     Performs the action of updating the Mods
        /// </summary>
        private void updateMods()
        {
            // Update mods here
            List<String> lines = new List<string>();

            lines.Add("");
            lines.Add("=====================================");
            lines.Add("          Updating Mods              ");
            lines.Add("=====================================");
            lines.Add("");

            foreach (String line in lines)
            {
                handleOutput(line);
            }

            String[] mods = modList.Text.Split(',');
            for (int i = 0; i < mods.Length; i++)
            {
                lines = new List<string>();

                String modNum = String.Format("{0:00}/{1:00}", i, mods.Length);

                lines.Add("");
                lines.Add("=====================================");
                lines.Add(String.Format("        Updating Mod {0}           ", modNum));
                lines.Add("=====================================");
                lines.Add("");

                String updateMods = String.Format(Reference.cmdUpdateMod, mods[i]);

                executeCommand(Reference.cmdUpdateMod, false);
            }
        }

        /// <summary>
        ///     Toggles the Start and Stop buttons
        /// </summary>
        /// 
        /// <param name="isServerOn">whether the server is turned on</param>
        private void toggleButtons(Boolean isServerOn)
        {
            startButton.IsEnabled = !isServerOn;
            stopButton.IsEnabled = isServerOn;
        }

        /// <summary>
        ///     Checks if the server can be started
        /// </summary>
        /// 
        /// <returns>true if can start</returns>
        private Boolean canStartServer()
        {
            Boolean canStart = true;

            canStart = serverName.Text.Equals("") ? canStart : false;
            canStart = serverMap.Text.Equals("") ? canStart : false;

            if(canStart && !serverExists(serverName.Text))
            {
                installServer(serverName.Text);
            }

            return canStart;
        }

        /// <summary>
        ///     Checks if the server exists
        /// </summary>
        /// 
        /// <param name="serverName">The server to check the existance of</param>
        /// 
        /// <returns>true if the server exists</returns>
        private Boolean serverExists(String serverName)
        {
            Boolean exists = false;

            if(serverNames != null)
            {
                exists = serverNames.Contains(serverName);
            }

            return exists;
        }

        /// <summary>
        ///     Runs the update commands to ensure the server is installed
        /// </summary>
        /// 
        /// <param name="serverName">the name of the server to install</param>
        private void installServer(String serverName)
        {
            updateServer();
            updateMods();
        }
    }
}
