using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ArkConfigurationTool
{
    class GameIni
    {

        private int levelCap;
        private int xpStep;
        private int engramStep;
        private int levelStep;

        private DataGrid levelTable;
        private DataGrid dinoTable;
        private DataGrid engramTable;

        private Boolean doOverride = false;

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
        /// <param name="levelTable">The Table containing level settings</param>
        /// <param name="dinoTable">The table containing dino settings</param>
        /// <param name="engramTable">The table containing engram settings</param>
        public GameIni(int levelCap, int xpStep, int engramStep, int levelStep, DataGrid levelTable, DataGrid dinoTable, DataGrid engramTable, Boolean doOverride)
        {
            this.levelCap = levelCap;
            this.xpStep = xpStep;
            this.engramStep = engramStep;
            this.levelStep = levelStep;

            this.levelTable = levelTable;
            this.dinoTable = dinoTable;
            this.engramTable = engramTable;

            this.doOverride = doOverride;
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
                StreamReader reader = new StreamReader(fileName);
                
                String line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == Reference.gameStart)
                    {
                        continue;
                    }

                    lines.Add(line);
                }

                reader.Close();
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
            // Dino Levels (LATER)
            // Dino Settings
            settings.AddRange(generateDinoSettings());
            // Engram Settings
            settings.AddRange(generateEngramSettings());

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
            
            List<Level> levels = (List<Level>)levelTable.ItemsSource;

            List<int> xpRamp;
            if (levels.Count == 0)
            {
                xpRamp = Reference.generateLevelRamp(levelCap);
            }    
            else
            {
                xpRamp = new List<int>();

                foreach(Level l in levels)
                {
                    xpRamp.Add(l.xpForLevel);
                }
            }

            for (int i = 0; i < levelCap; i++)
            {
                line += "ExperiencePointsForLevel[" + i + "]=";

                line += xpRamp[i];

                if (i != levelCap)
                {
                    line += ",";
                }
            }

            line += ")";

            lines.Add(line);

            lines.Add("overrideMaxExperiencePointsPlayer=" + xpRamp[xpRamp.Count-1]);

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
            
            List<int> xpRamp = Reference.generateLevelRampDino(levelCap);

            for (int i = 0; i < levelCap; i++)
            {
                line += "ExperiencePointsForLevel[" + i + "]=";
                
                line += xpRamp[i];

                if (i != levelCap)
                {
                    line += ",";
                }
            }

            line += ")";

            lines.Add(line);

            lines.Add("overrideMaxExperiencePointsDino=" + xpRamp[xpRamp.Count-1]);

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

            String dinoOverride = "DinoSpawnWeightMultipliers=(DinoNameTag={0},SpawnWeightMultiplier={1},OverrideSpawnLimitPercentage={2},SpawnLimitPercentage={3})";
            String preventTame = "preventDinoTameClassNames={0}";
            String npcReplace = "npcReplacements=(fromClassName=\"{0}\",toClassName=\"{1}\")";

            List<Dino> dinos = (List<Dino>)dinoTable.ItemsSource;

            foreach(Dino d in dinos)
            {
                if(!d.isDefault())
                {
                    if(!d.allowSpawn)
                    {
                        settings.Add(String.Format(dinoOverride, d.tag, 0, "false", 0));
                    }
                    else
                    {
                        String limitPercent = "false";

                        if(d.spawnLimit != 1.0)
                        {
                            limitPercent = "true";
                        }
                        settings.Add(String.Format(dinoOverride, d.tag, d.spawnRate, limitPercent, d.spawnLimit));
                    }

                    if(!d.allowTame)
                    {
                        settings.Add(String.Format(preventTame, "false"));
                    }

                    if(d.tag != d.overrideAiTag)
                    {
                        settings.Add(String.Format(npcReplace, Dino.getDinoClassName(d.tag), Dino.getDinoClassName(d.overrideAiTag)));
                    }
                }
            }

            return settings;
        }

        /// <summary>
        ///     Creates a list of settings regarding engrams
        /// </summary>
        /// 
        /// <returns>The list of engram settings</returns>
        public List<String> generateEngramSettings()
        {
            String overrideEngram = "OverrideEngramEntries=(EngramIndex={0},EngramHidden={1},EngramPointsCost={2},EngramLevelRequirement={3})";

            List<String> settings = new List<String>();

            List<Engram> engrams = (List<Engram>)engramTable.ItemsSource;

            foreach(Engram e in engrams)
            {
                if(!Engram.isDefault(e))
                {
                    settings.Add(String.Format(overrideEngram, e.getEngramIndex(), e.hideEngram, e.epCost, e.levelRequired));
                }
            }

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

            List<Level> levels = (List<Level>)levelTable.ItemsSource;

            List<int> epRamp;

            if (levels.Count == 0)
            {
                epRamp = Reference.generateEpRamp(levelCap, engramStep, levelStep, doOverride);
            }
            else
            {
                epRamp = new List<int>();

                foreach(Level l in levels)
                {
                    epRamp.Add(l.epForLevel);
                }
            }

            for(int i = 0; i < epRamp.Count; i++)
            {
                lines.Add("OverridePlayerLevelEngramPoints=" + epRamp[i]);
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

                writer.Close();
            }
        }
    }
}
