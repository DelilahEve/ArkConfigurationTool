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

namespace ArkConfigurationTool
{
    public partial class MainWindow : Window
    {

        private int xpStep = 40000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // open link here
        }
            
        private void generateClick(object sender, RoutedEventArgs e)
        {
            // Output files here
        }

        private String generateplayerLevelOverride(int levelCap)
        {

            String line = "LevelExperienceRampOverrides=(";

            int xp = 0;
            for (int i = 0; i < levelCap; i++)
            {
                line += "ExperiencePointsForLevel[" + i + "]=";

                if(i < Reference.playerLevelXP.Length)
                {
                    xp += Reference.playerLevelXP[i];
                }
                else
                {
                    xp += xpStep;
                }

                line += xp;
                
                if(i != levelCap)
                {
                    line += ",";
                }
            }

            line += ")";

            return line;
        }

        private List<String> generateGameUserIni()
        {
            List<String> settings = new List<string>();

            // Pull settings here

            /* 
                alwaysNotifyPlayerJoined
                alwaysNotifyPlayerLeft
                allowThirdPersonPlayer
                globalVoiceChat
                showMapPlayerLocation
                noTributeDownloads
                proximityChat
                serverPVE
                serverHardcore
                serverForceNoHud
                disableStructureDecayPVE
                disableDinoDecayPVE
                allowFlyerCarryPVE
                maxStructuresInRange
                maxPlayers
                difficultyOffset
                serverPassword
                serverAdminPassword
                spectatorPassword
                dayCycleSpeedScale
                nightTimeSpeedScale
                dayTimeSpeedScale
                dinoDamageMultiplier
                playerDamageMultiplier
                structureDamageMultiplier
                playerResistanceMultiplier
                dinoResistanceMultiplier
                structureResistanceMultiplier
                xpMulitplier
                pveStructureDecayPeriodMultiplier
                pveStructureDecayDestructionPeriod
                tamingSpeedMultiplier
                harvestAmountMultiplier
                harvestHealthMultiplier
                maxPlatformSaddleStructureLimit
                perPlatformMaxStructuresMultiplier
                resourcesRespawnPeriodMultiplier
                playerCharacterWaterDrainMultiplier
                playerCharacterFoodDrainMultiplier
                playerCharacterStaminaDrainMultiplier
                playerCharacterHealthRecoveryMultiplier
                dinoCharacterFoodDrainMultiplier
                dinoCharacterStaminaDrainMultiplier
                dinoCharacterHealthRecoveryMultiplier
                dinoCountMultiplier
                allowCaveBuildingPVE
                banListURL
                pvpStructureDecay
            */

            Boolean notifyJoin, notifyLeave, thirdPersonView, globalVoice, playerPos, tribDownload, localChat;
            Boolean isPve, isHardcore, noHud, structureDecay, dinoDecay, flyerCarry, caveBuilding;

            notifyJoin = (Boolean) joinNotify.IsChecked;
            notifyLeave = (Boolean) leaveNotify.IsChecked;
            thirdPersonView = (Boolean) thirdPerson.IsChecked;
            globalVoice = (Boolean) globalChat.IsChecked;
            playerPos = (Boolean) mapLocation.IsChecked;
            tribDownload = (Boolean) tributeDownloads.IsChecked;
            localChat = (Boolean) proximityChat.IsChecked;
            isPve = (Boolean) serverPve.IsChecked;
            isHardcore = (Boolean) serverHardcore.IsChecked;
            noHud = (Boolean) allowHud.IsChecked;
            if(isPve)
            {
                structureDecay = (Boolean) structureDecayPve.IsChecked;
            }
            else
            {
                structureDecay = (Boolean) structureDecayPvp.IsChecked;
            }
            dinoDecay = (Boolean) dinosaurDecay.IsChecked;

            return settings;
        }

        private List<String> generateGameIni()
        {
            List<String> settings = new List<string>();

            /*
            
                OverrideEngramEntries=(
                EngramIndex=<index>
                [,EngramHidden=<hidden>]
                [,EngramPointsCost=<cost>]
                [,EngramLevelRequirement=<level>]
                [,RemoveEngramPreReq=<remove_prereq>]
                )    

                DinoSpawnWeightMultipliers=(
                DinoNameTag=<tag>
                [,SpawnWeightMultiplier=<factor>]
                [,OverrideSpawnLimitPercentage=<override>]
                [,SpawnLimitPercentage=<limit>]
                )

                LevelExperienceRampOverrides=(
                ExperiencePointsForLevel[<n>]=<points>
                [,ExperiencePointsForLevel[<n>]=<points>]
                ...
                [,ExperiencePointsForLevel[<n>]=<points>]
                )

                overridePlayerLevelEngramPoints
                globalSpoilingTimeMultiplier
                gloablItemDecompositionTimeMultiplier
                globalCorpseDecompositionTimeMultiplier

                harvestResourceItemAmountClassMultipliers=(
                className="<classname>",
                multiplier=<valule>
                )

                overrideExperiencePointsPlayer
                overrideMaxExperiencePointsDino
                preventDinoTameClassNames

                npcReplacements=(
                fromClassName="<className>"
                toClassName="<toClassName>"
                )

                resourceNoReplenishRadiusPlayers
                resourceNoReplenishRadiusStructures
                bIncreasePVPRespawnInterval
                IncreasePvPRespawnIntervalCheckPeriod=<value1>; 
                IncreasePvPRespawnIntervalMultiplier=<value2>; 
                IncreasePvPRespawnIntervalBaseAmount=<value3>
                bAutoPVETimer
                bAutoPvEUseSystemTime=<Boolean2> 
                AutoPvEStartTimeSeconds=<value1> 
                AutoPvEStopTimeSeconds=<value2>
                bPVEDisableFriendlyFire

                perLevelStatsMultiplier_Player<type>[<attribute>]
                perLevelStatsMultiplier_DinoTamed<type>[<attribute>]
                perLevelStatsMultiplier_DinoWild<type>[<attribute>]
                
                matingIntervalMultiplier
                eggHatchSpeedMultiplier
                babyMatureSpeedMultiplier
                babyFoodConsumptionSpeedMultiplier
                cropGrowthSpeedMultiplier
                layEggIntervalMultiplier
                poopIntervalMultiplier
                cropDecaySpeedMultiplier
                structureDamageRepairCooldown
                bPVEAllowTribeWar
                bPVEAllowTribeWarCancel
                bPassiveDefencesDamageRiderlessDinos
                customRecipeEffectivenessMultiplier
                customRecipeSkillMultiplier
                dinoHarvestingDamageMultiplier
                playerHarvestingDamageMultiplier
                dinoTurretDamageMultiplier
                bDisableLootCrates
            */

            return settings;
        }

        private List<String> generateEPLines(int levelCap)
        {
            List<String> lines = new List<string>();

            int epStep = int.Parse(engramStep.Text);
            int levelStep = int.Parse(lvlStep.Text);

            int countedLevels = 0;

            for (int i = 0; i < levelCap; i++)
            {
                int ep = 0;

                if( i < 10 )
                {
                    ep = 8;
                }
                else if( i < 20 )
                {
                    ep = 12;
                }
                else if( i < 30 )
                {
                    ep = 16;
                }
                else if( i < 40 )
                {
                    ep = 20;
                }
                else if( i < 50 )
                {
                    ep = 24;
                }
                else if( i < 60)
                {
                    ep = 28;
                }
                else if( i < 73 )
                {
                    ep = 40;
                }
                else if( i < 87 )
                {
                    ep = 50;
                }
                else if( i < 95 )
                {
                    ep = 60;
                }
                else
                {
                    // calculate based on input
                    if( i == 95 )
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

                lines.Add("OverridePlayerLevelEngramPoints=" + ep);
            }

            return lines;
        }
    }
}
