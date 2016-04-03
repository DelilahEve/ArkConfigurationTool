using System;
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
using System.Collections.ObjectModel;

namespace ArkConfigurationTool
{
    public partial class MainWindow : Window
    {

        private Boolean isFirstRun = true;
        private Boolean isDebugMode = true;

        private List<String> serverNames;

        private Process serverProcess;

        /// <summary>
        ///     Initializes the program
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            serverNames = new List<string>();

            performSetup();

            toggleButtons(false);

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
                "serverList"
            };

            String[] values =
            {
                "0",
                "0",
                ""
            };

            if (!File.Exists("ArkConfigurationTool\\settings.act"))
            {
                // Create Directories
                String[] dirs =
                {
                    Reference.serversDirectory,
                    Reference.steamCmdDirectory
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
                    }
                }
            }

            // set variables
            isFirstRun = values[0] == "1";
            isDebugMode = values[1] == "1";
            serverNames.AddRange(values[2].Split(','));

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
            /*
            if(serverNames.Count > 0)
            {
                for (int i = 0; i < serverNames.Count; i++)
                {
                    if (serverNames[i].Equals(""))
                    {
                        continue;
                    }

                    String server = serverNames[i];

                    MenuItem item = new MenuItem();
                    item.Header = server;
                    item.Click += new RoutedEventHandler(loadServer);
                    openServer.Items.Add(item);
                }
            }
            */
            
            // Display Tables
            displayLevelTable();
            displayDinoTable();
            displayEngramTable();
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
            String serverName = (sender as MenuItem).Header.ToString();
            
            if (serverProcess == null)
            {
                // load server.act
                // read Game.ini
                // read GameUserSettings.ini
            }
            else
            {
                MessageBox.Show("Cannot switch servers while one is running :(");
            }
        }

        /// <summary>
        ///     Navigates to a link when clicked
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Arguments for the event</param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }


        /// <summary>
        ///     Saves the server settings when clicked
        /// </summary>
        /// 
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Arguments for the event</param>
        private void generateClick(object sender, RoutedEventArgs e)
        {
            List<String> errors = validate();
            if(errors.Count > 0)
            {
                String error = "";

                foreach(String err in errors)
                {
                    error += err + "\n";
                }

                MessageBox.Show(error);
            }
            else
            {
                // Ensure server is installed
                String serverExe = Reference.serversDirectory + serverName.Text + Reference.serverExePath;
                if (!File.Exists(serverExe))
                {
                    updateServer();
                }

                // Save ini files
                List<String> game;
                List<String> gameUser;

                game = generateGameIni();
                gameUser = generateGameUserIni();

                GameIni.saveFile(serverName.Text, game);
                GameUserIni.saveFile(serverName.Text, gameUser);

                // Save congifuration file
                String[] configKeys =
                {
                    "serverName",
                    "mods",
                    "map"
                };

                String[] values =
                {
                    serverName.Text,
                    modList.Text,
                    serverMap.Text
                };

                ConfigData serverConfig = new ConfigData("serverData", Reference.serversDirectory + serverName.Text);

                List<String> settings = new List<String>();

                for (int i = 0; i < configKeys.Length; i++)
                {
                    settings.Add(configKeys[i] + "=" + values[i]);
                }

                serverConfig.write(settings);
            }
        }

        private List<String> validate()
        {
            List<String> errors = new List<String>();
            
            // Check serverName
            if(serverName.Text.Equals(""))
            {
                errors.Add("Server needs a name!");
            }
            // Check map
            if(serverMap.Text.Equals(""))
            {
                errors.Add("Server needs a map");
            }

            // All text boxes numeric && empty -> 1.0
            TextBox[] numeric =
            {
                resourceReplenishPlayer,
                resourceReplenishStructure,
                matingInterval,
                eggHatch,
                babyMature,
                babyFood,
                eggInterval,
                poopInterval,
                cropDecay,
                structureDamageCooldown,
                dinoHarvestDamage,
                playerHarvestDamage,
                dinoTurretDamage,
                pvpRespawn,
                pvpRespawnMultiplier,
                pvpRespawnBase,
                structureDistance,
                daySpeed,
                nightSpeed,
                dayCycle,
                playerDamage,
                dinoDamage,
                structureDamage,
                playerResist,
                dinoResist,
                structureResist,
                structureDecayMultiplier,
                dinoCount,
                xpMultiplier,
                pveStructureDecayMultiplier,
                pveStructureDestructionPeriod,
                saddleStructureLimit,
                perPlatformStructureMultiplier,
                tameMultiplier,
                harvestMultiplier,
                resourceHealth,
                resourceRespawn,
                playerWater,
                playerFood,
                playerStamina,
                playerHealth,
                dinoFood,
                dinoStamina,
                dinoHealth,
                difficulty,
                maxPlayers,
                levelCap,
                engramStep,
                lvlStep
            };

            foreach (TextBox item in numeric)
            {
                if(item.Text.Equals(""))
                {
                    switch(item.Name)
                    {
                        case "difficulty":
                            item.Text.Equals("4.0");
                            break;
                        case "maxPlayers":
                            item.Text.Equals("50");
                            break;
                        case "levelCap":
                            item.Text.Equals("94");
                            break;
                        case "engramStep":
                            item.Text.Equals("4");
                            break;
                        case "lvlStep":
                            item.Text.Equals("10");
                            break;
                        default:
                            item.Text.Equals("1.0");
                            break;
                    }
                }
                else if(!item.Text.All(Char.IsDigit))
                {
                    errors.Add("Feild must be numerical: " + item.Name);
                }
            }

            return errors;
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

            GameUserIni game = new GameUserIni(motd.Text);
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

            GameIni game = new GameIni(
                int.Parse(levelCap.Text), 
                Reference.xpStep, 
                int.Parse(engramStep.Text), 
                int.Parse(lvlStep.Text), 
                levelGrid, 
                dinoGrid, 
                engramGrid, 
                (Boolean)overrideVanilla.IsChecked
            );

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

            if(canStartServer())
            {
                String[] startArgs = new String[3]
                {
                    serverName.Text,
                    serverMap.Text,
                    ""
                };

                String extras = "";
                if (!modList.Text.Equals(""))
                {
                    extras += "?GameModIds=" + modList;
                }

                startArgs[2] = extras;

                String start = String.Format(Reference.cmdStartServer, startArgs);
                executeCommand(start, true);
            }
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

            String path = System.IO.Path.GetFullPath(Reference.serversDirectory + serverName.Text);

            String update = String.Format(Reference.cmdUpdateServer, path);
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

                String path = System.IO.Path.GetFullPath(Reference.serversDirectory + serverName.Text);

                String updateMods = String.Format(Reference.cmdUpdateMod, path, mods[i]);

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

        /// <summary>
        ///     Outputs the Levels table
        /// </summary>
        private void displayLevelTable()
        {
            ObservableCollection<Level> levels = new ObservableCollection<Level>();

            int cap = int.Parse(levelCap.Text);
            int epStep = int.Parse(engramStep.Text);
            int levelStep = int.Parse(lvlStep.Text);

            List<int> xpRamp = Reference.generateLevelRamp(cap);
            List<int> epRamp = Reference.generateEpRamp(cap, epStep, levelStep, (Boolean)overrideVanilla.IsChecked);

            for (int i = 2; i <= cap; i++)
            {
                int lvl = i;
                int difference = xpRamp[i] - xpRamp[i - 1];
                int xp = xpRamp[i];
                int ep = epRamp[i];

                Level level = new Level(lvl, difference, xp, ep);

                levels.Add(level);
            }

            levelGrid.ItemsSource = levels;
        }

        /// <summary>
        ///     Outputs the Dinosaur table
        /// </summary>
        private void displayDinoTable()
        {
            ObservableCollection<Dino> dinos = new ObservableCollection<Dino>();
            foreach(Dino d in Dino.dinos)
            {
                dinos.Add(d);
            }
            
            dinoGrid.ItemsSource = dinos;
        }

        /// <summary>
        ///     Outputs the Engram table
        /// </summary>
        private void displayEngramTable()
        {
            ObservableCollection<Engram> engrams = new ObservableCollection<Engram>();
            foreach(Engram e in Engram.engrams)
            {
                engrams.Add(e);
            }

            engramGrid.ItemsSource = engrams;
        }
    }
}
