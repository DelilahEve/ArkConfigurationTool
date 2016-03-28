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

namespace ArkConfigurationTool
{
    public partial class MainWindow : Window
    {

        private int xpStep = 40000;

        private List<String> serverNames;
        private List<String> profiles;

        private Process serverProcess;

        public MainWindow()
        {
            InitializeComponent();

            serverNames = new List<string>();
            profiles = new List<string>();

            load();
        }

        public void load()
        {
            // Check Folder exists

            // load servers
            serverNames.AddRange(Directory.GetDirectories(Reference.serversDirectory));
            foreach(String server in serverNames)
            {
                MenuItem item = new MenuItem();
                item.Header = server;
                item.Click += new RoutedEventHandler(loadServer);
                openServer.Items.Add(item);
            }

            // Check Folder exists

            // load profiles
            profiles.AddRange(Directory.GetDirectories(Reference.profilesDirectory));
            foreach(String profile in profiles)
            {
                MenuItem item = new MenuItem();
                item.Header = profile;
                item.Click += new RoutedEventHandler(loadServerProfile);
                loadProfile.Items.Add(item);
            }
        }

        private void loadServer(Object sender, RoutedEventArgs e)
        {
            // get server name
            // load settings etc...
        }

        private void loadServerProfile(Object sender, RoutedEventArgs e)
        {
            // load settings from profile
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // open link here
        }
            
        private void generateClick(object sender, RoutedEventArgs e)
        {
            // Output files here
        }

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

        private void handleOutput(String text)
        {
            consoleOutput.Text += text + "\n";
        }

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

            float resourceNoRespawnPlayer = float.Parse(resourceReplenishPlayer.Text);
            float resourceNoRespawnStructure = float.Parse(resourceReplenishStructure.Text);
            float mating = float.Parse(matingInterval.Text);
            float eggHatchSpeed = float.Parse(eggHatch.Text);
            float babyMatureSpeed = float.Parse(babyMature.Text);
            float babyFoodConsume = float.Parse(babyFood.Text);
            float layEggInterval = float.Parse(eggInterval.Text);
            float poopIntervalMultiplier = float.Parse(poopInterval.Text);
            float cropDecaySpeed = float.Parse(cropDecay.Text);
            float structureDamageCd = float.Parse(structureDamageCooldown.Text);
            float dinoHarvestDamageMultiplier = float.Parse(dinoHarvestDamage.Text);
            float playerHarvestDamageMultiplier = float.Parse(playerHarvestDamage.Text);
            float dinoTurretDammageMultiplier = float.Parse(dinoTurretDamage.Text);
            float pvpRespawnCheckPeriod = float.Parse(pvpRespawn.Text);
            float pvpRespawnMulti = float.Parse(pvpRespawnMultiplier.Text);
            float pvpRespawnBasePeriod = float.Parse(pvpRespawnBase.Text);

            Boolean passiveDefenseDamage = (Boolean)passiveDefenseDamageDinos.IsChecked;
            Boolean increasePvPRespawn = (Boolean)pvpRespwanInterval.IsChecked;
            Boolean autoPveTimer = (Boolean)autoPve.IsChecked;
            Boolean autPveSystemTime = (Boolean)autoPveUsesSystemTime.IsChecked;

            GameIni game = new GameIni(int.Parse(levelCap.Text), xpStep, int.Parse(engramStep.Text), int.Parse(lvlStep.Text));
            settings = game.write();

            return settings;
        }

        private void startClick(object sender, RoutedEventArgs e)
        {
            startServer();
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            stopServer();
        }

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

            executeCommand(Reference.cmdUpdateServer, false);
        }

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

        private void toggleButtons(Boolean isServerOn)
        {
            startButton.IsEnabled = !isServerOn;
            stopButton.IsEnabled = isServerOn;
        }

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

        private Boolean serverExists(String serverName)
        {
            Boolean exists = false;

            if(serverNames != null)
            {
                exists = serverNames.Contains(serverName);
            }

            return exists;
        }

        private void installServer(String serverName)
        {
            updateServer();
            updateMods();
        }
    }
}
