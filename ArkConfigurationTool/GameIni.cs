using System;
using System.Collections.Generic;
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

        public GameIni(int levelCap, int xpStep, int engramStep, int levelStep)
        {
            this.levelCap = levelCap;
            this.xpStep = xpStep;
            this.engramStep = engramStep;
            this.levelStep = levelStep;
        }

        public void read()
        {

        }

        public List<String> write()
        {
            List<String> settings = new List<String>();

            // Output GameIni

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
    }
}
