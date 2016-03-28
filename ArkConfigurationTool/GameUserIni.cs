using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class GameUserIni
    {

        // Keys to Boolean values
        // ordered false default first then true
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

        // Keys to Float values
        // default 1.0 first
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

        public GameUserIni()
        {

        }

        public void read()
        {

        }

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

    }
}
