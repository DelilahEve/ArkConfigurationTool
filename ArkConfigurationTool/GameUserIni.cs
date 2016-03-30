using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class GameUserIni
    {
        private String[] boolKeys =
        {
            // Default False:
            "alwaysNotifyPlayerJoined",
            "allowThirdPersonPlayer",
            "showMapPlayerLocation",
            "noTributeDownloads",
            "proximityChat",
            "serverPVE",
            "serverHardcore",
            "serverForceNoHud",
            "allowFlyerCarryPVE",
            "allowCaveBuildingPVE",
            "disableDinoDecayPVE",

            // Default True:
            "alwaysNotifyPlayerLeft",
            "globalVoiceChat",
            "disableStructureDecayPVE",
            "pvpStructureDecay",
        };
        
        private String[] floatKeys =
        {
            // Default 1.0 value
            "maxStructuresInRange",
            "dayCycleSpeedScale",
            "nightTimeSpeedScale",
            "dayTimeSpeedScale",
            "playerDamageMultiplier",
            "dinoDamageMultiplier",
            "structureDamageMultiplier",
            "playerResistanceMultiplier",
            "dinoResistanceMultiplier",
            "structureResistanceMultiplier",
            "dinoCountMultiplier",
            "xpMulitplier",
            "pveStructureDecayPeriodMultiplier",
            "pveStructureDecayDestructionPeriod",
            "maxPlatformSaddleStructureLimit",
            "perPlatformMaxStructuresMultiplier",
            "tamingSpeedMultiplier",
            "harvestAmountMultiplier",
            "harvestHealthMultiplier",
            "resourcesRespawnPeriodMultiplier",
            "playerCharacterWaterDrainMultiplier",
            "playerCharacterFoodDrainMultiplier",
            "playerCharacterStaminaDrainMultiplier",
            "playerCharacterHealthRecoveryMultiplier",
            "dinoCharacterFoodDrainMultiplier",
            "dinoCharacterStaminaDrainMultiplier",
            "dinoCharacterHealthRecoveryMultiplier",

            // Default 4.0 value
            "difficultyOffset"
        };

        private String[] stringKeys =
        {
            "serverPassword",
            "serverAdminPassword",
            "spectatorPassword",
            "banListURL"
        };

        private String[] intKeys =
        {
            "maxPlayers"
        };

        /// <summary>
        ///     Reads the GameUserSettings.ini into the program
        /// </summary>
        /// 
        /// <returns>a list of settings from the file</returns>
        public List<String> read(String serverName)
        {
            String fileName = Reference.serversDirectory + serverName + Reference.gameUserIniPath;
            List<String> lines = new List<String>();

            if (File.Exists(fileName))
            {
                // read in un-needed file parts
                StreamReader reader = new StreamReader(fileName);

                Boolean passedSection = false;
                String line = "";
                while ((line = reader.ReadLine()) != null && !passedSection)
                {
                    if(line == Reference.gameUserStart)
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

                reader.Close();
            }

            return lines;
        }

        /// <summary>
        ///     Generates a list of settings to be written to file
        /// </summary>
        /// 
        /// <param name="defaultFalse">The boolean values that are false by default</param>
        /// <param name="defaultTrue">The boolean values that are true by default</param>
        /// <param name="floatValues">The list of float values to check</param>
        /// <param name="stringValues">The list of string values to cehck</param>
        /// <param name="intValues">The list of integer values to check</param>
        /// 
        /// <returns>a list of non-default settings to be written to GameUserSettings.ini</returns>
        public List<String> write(Boolean[] defaultFalse, Boolean[] defaultTrue, float[] floatValues, String[] stringValues, int[] intValues)
        {
            List<String> settings = new List<String>();

            // Set Booleans
            int b = 0;
            for (int i = 0; i < defaultFalse.Length; i++)
            {
                if (defaultFalse[i])
                {
                    settings.Add(boolKeys[b] + "=" + defaultFalse[i]);
                }

                b++;
            }

            for (int i = 0; i < defaultTrue.Length; i++)
            {
                if (!defaultTrue[i])
                {
                    settings.Add(boolKeys[b] + "=" + defaultTrue[i]);
                }

                b++;
            }

            // Set Floats
            int f = 0;
            for (int i = 0; i < floatValues.Length - 1; i++)
            {
                if (floatValues[i] != 1.0)
                {
                    settings.Add(floatKeys[f] + "=" + floatValues[i]);
                }

                f++;
            }

            settings.Add(floatKeys[f] + "=" + floatValues[f]);

            // Set Strings
            for (int i = 0; i < stringValues.Length; i++)
            {
                if (stringValues[i].Equals(""))
                {
                    settings.Add(stringKeys[i] + "=" + stringValues[i]);
                }
            }

            // Set Ints
            for (int i = 0; i < intValues.Length; i++)
            {
                settings.Add(intKeys[i] + "=" + intValues[i]);
            }

            return settings;
        }

        /// <summary>
        ///  Writes the file contents to disk
        /// </summary>
        public static void saveFile(String serverName, List<String> options)
        {
            String fileName = Reference.serversDirectory + serverName + Reference.gameUserIniPath;

            if (File.Exists(fileName))
            {
                // read in all of file
                List<String> lines = new List<String>();
                List<String> restOfFile = new List<String>();

                // read in un-needed file parts
                StreamReader reader = new StreamReader(fileName);

                Boolean passedSection = false;
                String line = "";
                while((line = reader.ReadLine()) != null)
                {
                    if(line == Reference.gameUserEnd && !passedSection)
                    {
                        passedSection = true;
                    }

                    if(passedSection)
                    {
                        restOfFile.Add(line);
                    }
                }

                reader.Close();

                // Build lines for file
                lines.Add(Reference.gameUserStart);
                lines.AddRange(options);
                lines.AddRange(restOfFile);

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
