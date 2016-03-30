using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class Engram
    {
        public static Engram[] engrams =
        {
            // Level 2
            new Engram("Campfire", false, 3, 2),
            new Engram("Stone Hatchet", false, 3, 2),
            new Engram("Spear", false, 3, 2),
            new Engram("Note", false, 3, 2),
            new Engram("Cloth Pants", false, 3, 2),
            new Engram("Cloth Shirt", false, 3, 2),
            new Engram("Thatch Foundation", false, 3, 2),
            new Engram("Thatch Doorframe", false, 3, 2),

            // Level 3
            new Engram("Wooden Club", false, 4, 3),
            new Engram("Waterskin", false, 6, 3),
            new Engram("Cloth Gloves", false, 3, 3),
            new Engram("Cloth Boots", false, 3, 3),
            new Engram("Cloth Hat", false, 3, 3),
            new Engram("Wooden Sign", false, 3, 3),
            new Engram("Hide Sleeping Bag", false, 3, 3),
            new Engram("Thatch Roof", false, 3, 3),
            new Engram("Thatch Wall", false, 3, 3),
            new Engram("Thatch Door", false, 3, 3),

            // Level 5
            new Engram("Slingshot", false, 6, 5),
            new Engram("Storage Box", false, 6, 5),
            new Engram("Simple Bed", false, 8, 5),
            new Engram("Phiomia Saddle", false, 6, 5),
            new Engram("Mortar & Pestle", false, 6, 5),
            new Engram("Sparkpowder", false, 3, 5),
            new Engram("Blood Extraction Syringe", false, 6, 5),
            new Engram("Narcotic", false, 6, 5),
            new Engram("Paintbrush", false, 3, 5),
            new Engram("Single Panel Flag", false, 6, 5),
            new Engram("Multi-Panel Flag", false, 6, 5),
            new Engram("Standing Torch", false, 6, 5),
            new Engram("Sloped Thatch Wall (Left)", false, 3, 5),
            new Engram("Sloped Thatch Wall (Right)", false, 3, 5),
            new Engram("Sloped Thatch Roof", false, 3, 5),
            new Engram("Wooden Foundation", false, 6, 5),
            new Engram("Wooden Wall", false, 7, 5),

            // Level 10
            new Engram("Cooking Pot", false, 9, 10),
            new Engram("Cementing Paste", false, 3, 10),
            new Engram("Stimulant", false, 6, 10),
            new Engram("Gunpowder", false, 2, 10),
            new Engram("Flare Gun", false, 6, 10),
            new Engram("Compass", false, 5, 10),
            new Engram("Spyglass", false, 2, 10),
            new Engram("Small Crop Plot", false, 9, 10),
            new Engram("Basic Gravestone", false, 8, 10),
            new Engram("Wardrums", false, 6, 10),
            new Engram("Parasaur Saddle", false, 9, 10),
            new Engram("Ichtyosaurus Saddle", false, 8, 10),
            new Engram("Intake Stone Pipe", false, 5, 10),
            new Engram("Straight Stron Pipe", false, 2, 10),
            new Engram("Stone Pipe Tap", false, 5, 10),
            new Engram("Wooden Spike Wall", false, 4, 10),
            new Engram("Wooden Wall Sign", false, 2, 10),
            new Engram("Wooden Ceiling", false, 6, 10),
            new Engram("Sloped Wood Wall (Left)", false, 3, 10),
            new Engram("Sloped Wood Wall (Right)", false, 3, 10),
            new Engram("Sloped Wooden Roof", false, 4, 10),
            new Engram("Wooden Doorframe", false, 6, 10),
            new Engram("Wooden Door", false, 4, 10),
            new Engram("Wooden Chair", false, 6, 10),
            new Engram("Painting Canvas", false, 2, 10),
            new Engram("Wooden Railing", false, 3, 10),
            new Engram("Wooden Sheild", false, 7, 10),
            new Engram("Wooden Cage", false, 10, 10),

            // Level 15
            new Engram("Wooden Fence Foundation", false, 6, 15),
            new Engram("Hide Pants", false, 9, 15),
            new Engram("Hide Shirt", false, 6, 15),
            new Engram("Bow", false, 11, 15),
            new Engram("Stone Arrow", false, 2, 15),
            new Engram("Large Storage Box", false, 9, 15),
            new Engram("Wooden Raft", false, 11, 15),
            new Engram("Parachute", false, 6, 15),
            new Engram("Bug Repellant", false, 12, 15),
            new Engram("Pachy Saddle", false, 9, 15),
            new Engram("Raptor Saddle", false, 9, 15),
            new Engram("Intersection Stone Pipe", false, 5, 15),
            new Engram("Inclined Stone Pipe", false, 3, 15),
            new Engram("Vertical Stone Pipe", false, 3, 15),
            new Engram("Compost Bin", false, 6, 15),
            new Engram("Stone Fence Foundation", false, 6, 15),
            new Engram("Stone Wall", false, 8, 15),
            new Engram("Water Reservoir", false, 7, 15),
            new Engram("Wooden Billboard", false, 4, 15),
            new Engram("Wooden Ramp", false, 3, 15),
            new Engram("Dinosaur Gateway", false, 7, 15),
            new Engram("Dinosaur Gate", false, 5, 15),
            new Engram("Wooden Pillar", false, 9, 15),
            new Engram("Wooden Hatchframe", false, 9, 15),
            new Engram("Wooden Ladder", false, 6, 15),
            new Engram("Feeding Trough", false, 12, 15),
            new Engram("Wooden Bench", false, 10, 15),
            new Engram("Wooden Table", false, 7, 15),

            // Level 20
            new Engram("Hide Gloves", false, 7, 20),
            new Engram("Hide Boots", false, 7, 20),
            new Engram("Hide Hat", false, 9, 20),
            new Engram("Magnifying Glass", false, 16, 20),
            new Engram("Tranquilizer Arrow", false, 8, 20),
            new Engram("Refining Forge", false, 21, 20),
            new Engram("Trike Saddle", false, 12, 20),
            new Engram("Tripwire Alarm Trap", false, 7, 20),
            new Engram("Trophy Base", false, 10, 20),
            new Engram("Trophy Wall Mount", false, 10, 20),
            new Engram("Preserving Bin", false, 9, 20),
            new Engram("Wooden Catwalk", false, 8, 20),
            new Engram("Wooden Trapdoor", false, 6, 20),
            new Engram("Wooden Windowframe", false, 9, 20),
            new Engram("Stone Foundation", false, 6, 20),
            new Engram("Stone Ceiling", false, 6, 20),
            new Engram("Sloped Stone Wall (Left)", false, 3, 20),
            new Engram("Sloped Stone Wall (Right)", false, 3, 20),
            new Engram("Sloped Stone Roof", false, 4, 20),
            new Engram("Stone Doorframe", false, 6, 20),
            new Engram("Reinforced Wooden Door", false, 4, 20),
            new Engram("Stone Dinosaur Gateway", false, 9, 20),
            new Engram("Reinforced Dinosaur Gate", false, 6, 20),
            new Engram("Bookshelf", false, 5, 20),
            new Engram("Stone Railing", false, 4, 20),

            // Level 25
            new Engram("Smithy", false, 16, 25),
            new Engram("Metal Spike Wall", false, 11, 25),
            new Engram("Metal Pick", false, 6, 25),
            new Engram("Metal Hatchet", false, 6, 25),
            new Engram("Pike", false, 10, 25),
            new Engram("Fur Boots", false, 12, 25),
            new Engram("Fur Gauntlets", false, 12, 25),
            new Engram("Fur Cap", false, 14, 25),
            new Engram("Fur Leggings", false, 16, 25),
            new Engram("Fur Chestpiece", false, 16, 25),
            new Engram("Crossbow", false, 12, 25),
            new Engram("Tripwire Narcotic Trap", false, 9, 25),
            new Engram("Pulmonoscorpius Saddle", false, 12, 25),
            new Engram("Carbronemys Saddle", false, 12, 25),
            new Engram("Beelzebufo Saddle", false, 16, 25),
            new Engram("Terror Bird Saddle", false, 15, 25),
            new Engram("Medium Crop Plot", false, 12, 25),
            new Engram("Metal Sign", false, 10, 25),
            new Engram("Stone Pillar", false, 8, 25),
            new Engram("Stone Hatchframe", false, 8, 25),
            new Engram("Stone Windowframe", false, 11, 25),
            new Engram("Wooden Window", false, 6, 25),
            new Engram("Bear Trap", false, 9, 25),
            new Engram("Large Bear Trap", false, 12, 25),
            new Engram("Handcuffs", false, 16, 25),
            new Engram("Radio", false, 8, 25),
            new Engram("Smoke Grenade", false, 18, 25),
            new Engram("Ballista Turret", false, 25, 25),
            new Engram("Ballista Bolt", false, 10, 25),
            new Engram("Wall Torch", false, 8, 25),

            // Level 30
            new Engram("Behemoth Stone Dinosaur Gateway", false, 12, 30),
            new Engram("Behemoth Reinforced Dinosaur Gate", false, 16, 30),
            new Engram("Chitin Leggings", false, 15, 30),
            new Engram("Chitin Chestpiece", false, 18, 30),
            new Engram("Chitin Helmet", false, 18, 30),
            new Engram("Catapult Turret", false, 25, 30),
            new Engram("Water Jar", false, 12, 30),
            new Engram("Simple Pistol", false, 15, 30),
            new Engram("Simple Bullet", false, 6, 30),
            new Engram("Scope Attachment", false, 13, 30),
            new Engram("Metal Sickle", false, 12, 30),
            new Engram("Stego Saddle", false, 15, 30),
            new Engram("Doedicurus Saddle", false, 20, 30),
            new Engram("Paracer Saddle", false, 18, 30),
            new Engram("Megaloceros Saddle", false, 20, 30),
            new Engram("Grenade", false, 20, 30),
            new Engram("Reinforced Trapdoor", false, 10, 30),
            new Engram("Reinforced Window", false, 10, 30),
            new Engram("Metal Wall Sign", false, 6, 30),
            new Engram("Metal Foundation", false, 24, 30),
            new Engram("Metal Wall", false, 15, 30),
            new Engram("Sloped Metal Wall (Left)", false, 7, 30),
            new Engram("Sloped Metal Wall (Right)", false, 7, 30),
            new Engram("Metal Doorframe", false, 24, 30),
            new Engram("Metal Railing", false, 7, 30),
            new Engram("Metal Sword", false, 11, 30),
            new Engram("Metal Shield", false, 9, 30),
            new Engram("Stone Fireplace", false, 15, 30),

            // Level 35
            new Engram("Chitin Gauntlets", false, 15, 35),
            new Engram("Chitin Boots", false, 15, 35),
            new Engram("Longneck Rifle", false, 18, 35),
            new Engram("Simple Rifle Ammo", false, 6, 35),
            new Engram("Large Crop Plot", false, 15, 35),
            new Engram("Pteranodon Saddle", false, 15, 35),
            new Engram("Sarco Saddle", false, 15, 35),
            new Engram("Shotgun", false, 18, 35),
            new Engram("Simple Shotgun Ammo", false, 6, 35),
            new Engram("Metal Pillar", false, 18, 35),
            new Engram("Metal Ceiling", false, 15, 35),
            new Engram("Sloped Metal Roof", false, 10, 35),
            new Engram("Metal Door", false, 12, 35),
            new Engram("Metal Ramp", false, 12, 35),
            new Engram("Re-Fertilizer", false, 20, 35),
            new Engram("Ghillie Chestpiece", false, 11, 35),
            new Engram("Ghillie Leggings", false, 11, 35),
            new Engram("Ghillie Mask", false, 13, 35),
            new Engram("Beer Barrel", false, 24, 35),

            // Level 40
            new Engram("Poison Grenade", false, 18, 40),
            new Engram("Fabricator", false, 24, 40),
            new Engram("Silencer Attachment", false, 13, 40),
            new Engram("Ankylo Saddle", false, 18, 40),
            new Engram("Araneo Saddle", false, 18, 40),
            new Engram("Mammoth Saddle", false, 18, 40),
            new Engram("Intake Metal Pipe", false, 15, 40),
            new Engram("Straight Metal Pipe", false, 12, 40),
            new Engram("Metal Hatchframe", false, 18, 40),
            new Engram("Metal Trapdoor", false, 14, 40),
            new Engram("Metal Fence Foundation", false, 12, 40),
            new Engram("Metal Dinosaur Gateway", false, 12, 40),
            new Engram("Metal Dinosaur Gate", false, 8, 40),
            new Engram("Polymer", false, 6, 40),
            new Engram("Electronics", false, 6, 40),
            new Engram("Ghillie Boots", false, 11, 40),
            new Engram("Ghillie Gauntlets", false, 11, 40),

            // Level 45
            new Engram("Flak Leggings", false, 15, 45),
            new Engram("Flak Chestpiece", false, 18, 45),
            new Engram("Improvised Explosive Device", false, 30, 45),
            new Engram("Intersection Metal Pipe", false, 18, 45),
            new Engram("Inclined Metal Pipe", false, 12, 45),
            new Engram("Vertical Metal Pipe", false, 12, 45),
            new Engram("Tap Metal Pipe", false, 18, 45),
            new Engram("Metal Water Reservoir", false, 20, 45),
            new Engram("Megalodon Saddle", false, 18, 45),
            new Engram("Sabertooth Saddle", false, 18, 45),
            new Engram("Paracer Platform Saddle", false, 24, 45),
            new Engram("Industrial Grill", false, 40, 45),
            new Engram("Metal Windowframe", false, 18, 45),
            new Engram("Metal Ladder", false, 21, 45),
            new Engram("Flashlight Attachment", false, 18, 45),
            new Engram("GPS", false, 21, 45),
            new Engram("Greenhouse Wall", false, 30, 45),
            new Engram("Greenhouse Ceiling", false, 30, 45),
            new Engram("Greenhouse Doorframe", false, 15, 45),
            new Engram("Greenhouse Door", false, 15, 45),
            new Engram("Greenhouse Window", false, 15, 45),

            // Level 50
            new Engram("Flak Boots", false, 16, 50),
            new Engram("Flak Gauntlets", false, 16, 50),
            new Engram("Flak Helmet", false, 20, 50),
            new Engram("Metal Billboard", false, 15, 50),
            new Engram("Metal Window", false, 18, 50),
            new Engram("Metal Catwalk", false, 18, 50),
            new Engram("Carno Saddle", false, 21, 50),
            new Engram("Procoptodon Saddle", false, 35, 50),
            new Engram("Gallimimus Saddle", false, 20, 50),
            new Engram("Canteen", false, 24, 50),
            new Engram("Electrical Generator", false, 24, 50),
            new Engram("Straight Electrical Cable", false, 16, 50),
            new Engram("Electrical Outlet", false, 16, 50),
            new Engram("Fabricated Pistol", false, 18, 50),
            new Engram("Advanced Bullet", false, 8, 50),
            new Engram("Pump-Action Shotgun", false, 18, 50),
            new Engram("Grappling Hook", false, 40, 50),
            new Engram("Remote Keypad", false, 18, 50),
            new Engram("Omni-Directional Lamppost", false, 20, 50),
            new Engram("Lamppost", false, 20, 50),
            new Engram("War Map", false, 15, 50),
            new Engram("Sloped Greenhouse Roof", false, 30, 50),
            new Engram("Sloped Greenhouse Wall (Left)", false, 15, 50),
            new Engram("Sloped Greenhouse Wall (Right)", false, 15, 50),

            // Level 55
            new Engram("Inclined Electrical Cable", false, 16, 55),
            new Engram("Vertical Electrical Cable", false, 16, 55),
            new Engram("Intersection Electrical Cable", false, 24, 55),
            new Engram("Argentavis Saddle", false, 21, 55),
            new Engram("Bronto Saddle", false, 21, 55),
            new Engram("Casteroides Saddle", false, 50, 55),
            new Engram("Refrigerator", false, 20, 55),
            new Engram("Air Conditioner", false, 21, 55),
            new Engram("C4 Remote Detonator", false, 24, 55),
            new Engram("C4 Charge", false, 12, 55),
            new Engram("Assault Rifle", false, 24, 55),
            new Engram("Advanced Rifle Bullet", false, 8, 55),
            new Engram("Laser Attachment", false, 24, 55),
            new Engram("Holoscope Attachment", false, 24, 55),
            new Engram("Behemoth Gateway", false, 28, 55),
            new Engram("Behemoth Gate", false, 15, 55),

            // Level 60
            new Engram("Rex Saddle", false, 40, 60),
            new Engram("Spino Saddle", false, 40, 60),
            new Engram("Rocket Launcher", false, 32, 60),
            new Engram("Rocket Propelled Grenade", false, 8, 60),
            new Engram("Auto Turret", false, 40, 60),
            new Engram("Spray Painter", false, 30, 60),
            new Engram("Quetz Saddle", false, 44, 60),
            new Engram("Bunk Bed", false, 28, 60),

            // Level 65
            new Engram("Heavy Miner's Helmet", false, 35, 65),
            new Engram("Transponder Tracker", false, 30, 65),
            new Engram("Transponder Node", false, 20, 65),
            new Engram("Vault", false, 30, 65),
            new Engram("Plesiosaur Saddle", false, 40, 65),
            new Engram("Elevator Track", false, 40, 65),
            new Engram("Small Elevator Platform", false, 40, 65),
            new Engram("Medium Elevator Platform", false, 40, 65),
            new Engram("Large Elevator Platform", false, 40, 65),
            new Engram("Tranquilizer Dart", false, 30, 65),

            // Level 70
            new Engram("Compound Bow", false, 40, 70),
            new Engram("Metal Arrow", false, 35, 70),
            new Engram("Bronto Platform Saddle", false, 35, 70),
            new Engram("Fabricated Sniper Rifle", false, 36, 70),
            new Engram("Advanced Sniper Bullet", false, 16, 70),

            // Level 75
            new Engram("SCUBA Mask", false, 25, 75),
            new Engram("SCUBA Tank", false, 35, 75),
            new Engram("SCUBA Leggings", false, 35, 75),
            new Engram("SCUBA Flippers", false, 20, 75),
            new Engram("Riot Shield", false, 45, 75),
            new Engram("Homing Underwater Mine", false, 30, 75),
            new Engram("Mosasaurus Saddle", false, 60, 75),

            // Level 80
            new Engram("Riot Helmet", false, 40, 80),
            new Engram("Riot Chestpiece", false, 40, 80),
            new Engram("Riot Gauntlets", false, 40, 80),
            new Engram("Riot Leggings", false, 40, 80),
            new Engram("Riot Boots", false, 40, 80),
            new Engram("Electric Prod", false, 60, 80),
            new Engram("Plesiosaur Platform Saddle", false, 50, 80),
            new Engram("Quetz Platform Saddle", false, 80, 80),
            new Engram("Industrial Cooker", false, 60, 80),

            // Level 85
            new Engram("Mosasaurus Platform Saddle", false, 80, 85),
            new Engram("Giganotosaurus Saddle", false, 75, 85),
            new Engram("Minigun Turret", false, 80, 85),
            new Engram("Industrial Forge", false, 90, 85),

            // Level 90
            new Engram("Rocket Turret", false, 100, 90)
        };

        public String engramTag { get; set; }

        public Boolean hideEngram { get; set; }

        public int epCost { get; set; }
        public int levelRequired { get; set; }

        public Engram(String engramTag, Boolean hideEngram, int epCost, int levelRequired)
        {
            this.engramTag = engramTag;
            this.hideEngram = hideEngram;
            this.epCost = epCost;
            this.levelRequired = levelRequired;
        }

        /// <summary>
        ///     Gets the engram tag for this engram
        /// </summary>
        /// 
        /// <returns>This engram's tag</returns>
        public String getEngramTag()
        {
            return engramTag;
        }

        /// <summary>
        ///     Gets whether to hide the engram
        /// </summary>
        /// 
        /// <returns>Whether this engram should be hidden</returns>
        public Boolean getHideEngram()
        {
            return hideEngram;
        }

        /// <summary>
        ///     Gets the ep cost of this engram
        /// </summary>
        /// 
        /// <returns>The ep cost of the engram</returns>
        public int getEpCost()
        {
            return epCost;
        }

        /// <summary>
        ///     Gets the level required to unlock this engram
        /// </summary>
        /// 
        /// <returns>The level required for unlocking</returns>
        public int getLevelRequired()
        {
            return levelRequired;
        }
    }
}
