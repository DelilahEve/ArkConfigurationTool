using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class Reference
    {
        // Misc Values
        public static int xpStep = 40000;

        // Directories
        public static String serversDirectory = "ArkConfigurationTool\\Servers\\";
        public static String profilesDirectory = "ArkConfigurationTool\\Profiles\\";
        public static String logsDirectory = "ArkConfigurationTool\\Logs\\";
        public static String steamCmdDirectory = "ArkConfigurationTool\\steamCMD\\";

        // Paths
        public static String serverExePath = "\\ShooterGame\\Binaries\\Win64\\ShooterGameServer.exe";
        public static String gameUserIniPath = "\\ShooterGame\\Saved\\Config\\WindowsServer\\GameUserSettings.ini";
        public static String gameIniPath = "\\ShooterGame\\Saved\\Config\\WindowsServer\\Game.ini";

        // URLs
        public static String steamCmdUrl = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";

        // Position Markers
        public static String gameStart = "[/script/shootergame.shootergamemode]";
        public static String gameUserStart = "[ServerSettings]";
        public static String gameUserEnd = "[/Script/ShooterGame.ShooterGameUserSettings]";
        public static String motdStart = "[MessageOfTheDay]";

        // 0 = .exe location
        // 1 = Map
        // 2 = GameModIds/etc...
        public static String cmdStartServer = "start {0} \"{1}?listen{2}\"";

        // 0 = Install dir
        public static String cmdUpdateServer = "start " + steamCmdDirectory + "steamcmd.exe +login anonymous +force_install_dir {0} +app_update 346110 validate +quit";

        // 0 = Install dir
        // 1 = ModId
        public static String cmdUpdateMod = "start " + steamCmdDirectory + "steamcmd.exe +login anonymous +force_install_dir {0} +workshop_download_item 346110 {1} +quit";

        public static int[] playerLevelXP = {
            0,
            0,
            5,
            20,
            40,
            70,
            120,
            190,
            270,
            360,
            450,
            550,
            660,
            780,
            910,
            1050,
            1200,
            1360,
            1530,
            1710,
            1900,
            2100,
            2310,
            2530,
            2760,
            3000,
            3250,
            3510,
            3780,
            4060,
            4350,
            4650,
            4960,
            5280,
            5610,
            5950,
            6300,
            6660,
            7030,
            7410,
            7800,
            8200,
            8610,
            9030,
            9460,
            9900,
            10350,
            10810,
            11280,
            11760,
            12250,
            12750,
            13260,
            13780,
            14310,
            14850,
            15400,
            15960,
            16530,
            17110,
            17700,
            18850,
            21078,
            22448,
            23908,
            25462,
            27498,
            30248,
            34786,
            40004,
            46804,
            54761,
            63713,
            73000,
            85000,
            98000,
            112000,
            127500,
            144500,
            163500,
            184500,
            207500,
            232570,
            259896,
            289681,
            323189,
            360886,
            403318,
            451484,
            506186,
            566358,
            632547,
            705354,
            785441,
            873538
        };

        public static int[] dinoLevelXP = {
            10,
            30,
            60,
            100,
            150,
            210,
            280,
            360,
            450,
            550,
            660,
            780,
            910,
            1050,
            1200,
            1360,
            1530,
            1710,
            1900,
            2100,
            2310,
            2530,
            2760,
            3000,
            3250,
            3510,
            3780,
            4060,
            4350,
            4650,
            4960,
            5280,
            5610,
            5950,
            6545,
            7199,
            7919,
            8711,
            9582,
            10540,
            11594,
            12985,
            14932,
            17172,
            19748,
            23105,
            27105,
            31505,
            36005,
            41000,
            47000,
            55000,
            65000,
            80000,
            98000,
            120000,
            150000,
            185000,
            225000,
            275000
        };

        /// <summary>
        ///     Generates a level ramp based on the given level cap
        /// </summary>
        /// 
        /// <param name="cap">The level cap to remain within</param>
        /// 
        /// <returns>A list of xp values representing the xp ramp</returns>
        public static List<int> generateLevelRamp(int cap)
        {
            /* ---------------------- Edit to allow overriding vanilla levels -------------------------- */
            /* ---------------------- Edit to allow overriding boosted levels -------------------------- */
            List<int> ramp = new List<int>();
            
            int xp = 0;
            for (int i = 0; i <= cap; i++)
            {
                // Calculate XP
                if (i < playerLevelXP.Length)
                {
                    xp += playerLevelXP[i];
                }
                else
                {
                    xp += xpStep;
                }

                ramp.Add(xp);
            }

            return ramp;
        }

        public static List<int> generateLevelRampDino(int cap)
        {
            List<int> ramp = new List<int>();

            int xp = 0;
            for (int i = 0; i <= cap; i++)
            {
                // Calculate XP
                if (i < dinoLevelXP.Length)
                {
                    xp += dinoLevelXP[i];
                }
                else
                {
                    xp += xpStep;
                }

                ramp.Add(xp);
            }

            return ramp;
        }

        /// <summary>
        ///     Generates an engram point ramp based on a given
        ///     level cap
        /// </summary>
        /// 
        /// <param name="cap">The level cap to stay within</param>
        /// <param name="epStep">The number of engrams to add at each level step</param>
        /// <param name="levelStep">The level step at which additional EP is added to the given amount</param>
        /// 
        /// <returns>a list of engram points for the given level cap</returns>
        public static List<int> generateEpRamp(int cap, int epStep, int levelStep, Boolean doOverride)
        {
            /* ---------------------- Edit to allow overriding vanilla levels -------------------------- */
            /* ---------------------- Edit to allow overriding boosted levels -------------------------- */
            List<int> ramp = new List<int>();
            
            int countedLevels = 0;
            for (int i = 0; i <= cap; i++)
            {
                // Calculate EP
                int ep = 0;

                if (i < 10)
                {
                    ep = 8;
                }
                else if (i < 20)
                {
                    ep = 12;
                }
                else if (i < 30)
                {
                    ep = 16;
                }
                else if (i < 40)
                {
                    ep = 20;
                }
                else if (i < 50)
                {
                    ep = 24;
                }
                else if (i < 60)
                {
                    ep = 28;
                }
                else if (i < 73)
                {
                    ep = 40;
                }
                else if (i < 87)
                {
                    ep = 50;
                }
                else if (i < 95)
                {
                    ep = 60;
                }
                else
                {
                    // calculate based on input
                    if (i == 95)
                    {
                        ep += epStep;
                    }

                    if (countedLevels == levelStep)
                    {
                        countedLevels = 0;
                        ep += epStep;
                    }

                    countedLevels++;
                }

                ramp.Add(ep);
            }

            return ramp;
        }
        
    }
}
