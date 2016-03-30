using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class GameIni
    {

        private int levelCap;
        private int xpStep;
        private int engramStep;
        private int levelStep;

        private String[] boolKeys =
        {
            "bIncreasePVPRespawnInterval",
            "bAutoPVETimer",
            "bAutoPvEUseSystemTime",
            "bPVEAllowTribeWar",
            "bPVEAllowTribeWarCancel",
            "bPassiveDefencesDamageRiderlessDinos",
            "bPVEDisableFriendlyFire",
            "bDisableLootCrates"
        };

        private String[] floatKeys =
        {
            "matingIntervalMultiplier",
            "eggHatchSpeedMultiplier",
            "babyMatureSpeedMultiplier",
            "babyFoodConsumptionSpeedMultiplier",
            "cropGrowthSpeedMultiplier",
            "layEggIntervalMultiplier",
            "poopIntervalMultiplier",
            "cropDecaySpeedMultiplier",
            "structureDamageRepairCooldown",
            "customRecipeEffectivenessMultiplier",
            "customRecipeSkillMultiplier",
            "dinoHarvestingDamageMultiplier",
            "playerHarvestingDamageMultiplier",
            "dinoTurretDamageMultiplier",
            "resourceNoReplenishRadiusPlayers",
            "resourceNoReplenishRadiusStructures",
            "IncreasePvPRespawnIntervalCheckPeriod",
            "IncreasePvPRespawnIntervalMultiplier",
            "IncreasePvPRespawnIntervalBaseAmount",
            "AutoPvEStartTimeSeconds",
            "AutoPvEStopTimeSeconds",
            "globalSpoilingTimeMultiplier",
            "gloablItemDecompositionTimeMultiplier",
            "globalCorpseDecompositionTimeMultiplier"
        };

        /// <summary>
        ///     Constructs the GameIni class for use with Game.ini file
        /// </summary>
        /// 
        /// <param name="levelCap">The level cap to set one players</param>
        /// <param name="xpStep">The step in xp between levels</param>
        /// <param name="engramStep">the step in engrams between level steps</param>
        /// <param name="levelStep">The step in level for engram steps</param>
        public GameIni(int levelCap, int xpStep, int engramStep, int levelStep)
        {
            this.levelCap = levelCap;
            this.xpStep = xpStep;
            this.engramStep = engramStep;
            this.levelStep = levelStep;
        }

        /// <summary>
        ///     Reads the settings from the Game.ini file
        /// </summary>
        public List<String> read(String serverName)
        {
            String fileName = Reference.serversDirectory + serverName + Reference.gameIniPath;
            List<String> lines = new List<String>();

            if (File.Exists(fileName))
            {
                // read in un-needed file parts
                StreamReader reader = new StreamReader(fileName);

                Boolean passedSection = false;
                String line = "";
                while ((line = reader.ReadLine()) != null && !passedSection)
                {
                    if (line == Reference.gameUserStart)
                    {
                        continue;
                    }

                    if (line == Reference.gameUserEnd && !passedSection)
                    {
                        passedSection = true;
                    }

                    if (!passedSection)
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines;
        }

        /// <summary>
        ///     Generates the list of settings that belongs in Game.ini
        /// </summary>
        /// 
        /// <param name="boolValues">list of boolean values set</param>
        /// <param name="floatValues">list of float values set</param>
        /// 
        /// <returns>a list of settings with only non-default values</returns>
        public List<String> write(Boolean[] boolValues, float[] floatValues)
        {
            List<String> settings = new List<String>();

            // Boolean Values
            for(int i = 0; i < boolValues.Length; i++)
            {
                if(boolValues[i])
                {
                    settings.Add(boolKeys[i] + "=" + boolValues[i]);
                }
            }

            // Float Values
            for(int i = 0; i < floatValues.Length; i++)
            {
                if(floatValues[i] != 1.0f)
                {
                    settings.Add(floatKeys[i] + "=" + floatValues[i]);
                }
            }

            // Player Level Values
            settings.AddRange(generatePlayerLevelOverride());

            return settings;
        }

        /// <summary>
        ///     Generates the settings for overriding
        ///     player levels
        /// </summary>
        /// 
        /// <returns>List of lines for output</returns>
        private List<String> generatePlayerLevelOverride()
        {
            List<String> lines = new List<String>();
            String line = "LevelExperienceRampOverrides=(";

            /* ---------------------- Edit to allow overriding vanilla levels -------------------------- */
            /* ---------------------- Edit to allow overriding boosted levels -------------------------- */
            int xp = 0;
            for (int i = 0; i < levelCap; i++)
            {
                line += "ExperiencePointsForLevel[" + i + "]=";

                if (i < Reference.playerLevelXP.Length)
                {
                    xp += Reference.playerLevelXP[i];
                }
                else
                {
                    xp += xpStep;
                }

                line += xp;

                if (i != levelCap)
                {
                    line += ",";
                }
            }

            line += ")";

            lines.Add(line);

            lines.Add("overrideMaxExperiencePointsPlayer=" + xp);

            return lines;
        }

        /// <summary>
        ///     Generates the settings for overriding
        ///     dino levels
        /// </summary>
        /// 
        /// <returns>List of lines for output</returns>
        private List<String> generateDinoLevelOverride()
        {
            List<String> lines = new List<String>();
            String line = "LevelExperienceRampOverrides=(";

            /* ---------------------- Edit to allow overriding vanilla levels -------------------------- */
            /* ---------------------- Edit to allow overriding boosted levels -------------------------- */
            int xp = 0;
            for (int i = 0; i < levelCap; i++)
            {
                line += "ExperiencePointsForLevel[" + i + "]=";

                if (i < Reference.dinoLevelXP.Length)
                {
                    xp += Reference.dinoLevelXP[i];
                }
                else
                {
                    xp += xpStep;
                }

                line += xp;

                if (i != levelCap)
                {
                    line += ",";
                }
            }

            line += ")";

            lines.Add(line);

            lines.Add("overrideMaxExperiencePointsDino=" + xp);

            return lines;
        }

        /// <summary>
        ///     Generates lines pertaining to Dino characters
        /// </summary>
        /// 
        /// <returns>a list of settings to be applied to dinos</returns>
        public List<String> generateDinoSettings()
        {
            List<String> settings = new List<String>();

            // generate settings from dino tab here

            // allowSpawn
            // allowTame
            // spawnRateMultiplier
            // spawnLimit
            // overrideAi

            return settings;
        }

        /// <summary>
        ///     Generates lines for Engram Point
        ///     overrides
        /// </summary>
        /// 
        /// <returns>List of lines for ep overrides</returns>
        private List<String> generateEPLines()
        {
            List<String> lines = new List<string>();

            int countedLevels = 0;

            for (int i = 0; i < levelCap; i++)
            {
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
                        ep += engramStep;
                    }

                    if (countedLevels == levelStep)
                    {
                        countedLevels = 0;
                        ep += engramStep;
                    }

                    countedLevels++;
                }

                lines.Add("OverridePlayerLevelEngramPoints=" + ep);
            }

            return lines;
        }

        /// <summary>
        ///  Writes the file contents to disk
        /// </summary>
        public static void saveFile(String serverName, List<String> options)
        {
            String fileName = Reference.serversDirectory + serverName + Reference.gameIniPath;

            if (File.Exists(fileName))
            {
                // read in all of file
                List<String> lines = new List<String>();
                
                // Build lines for file
                lines.Add(Reference.gameStart);
                lines.AddRange(options);

                // Prep output
                StreamWriter writer = new StreamWriter(fileName);

                // Clear file
                writer.Write("");


                // Output file
                foreach (String l in lines)
                {
                    writer.WriteLine(l);
                }
            }
        }
    }
}
