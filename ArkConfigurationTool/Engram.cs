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
            new Engram("Campfire", false, 3, 2, 0),
            new Engram("Stone Hatchet", false, 3, 2, 1),
            new Engram("Spear", false, 3, 2, 3),
            new Engram("Note", false, 3, 2, 4),
            new Engram("Cloth Pants", false, 3, 2, 5),
            new Engram("Cloth Shirt", false, 3, 2, 6),
            new Engram("Thatch Foundation", false, 3, 2, 7),
            new Engram("Thatch Doorframe", false, 3, 2, 8),

            // Level 3
            new Engram("Wooden Club", false, 4, 3, 2),
            new Engram("Waterskin", false, 6, 3, 9),
            new Engram("Cloth Gloves", false, 3, 3, 10),
            new Engram("Cloth Boots", false, 3, 3, 11),
            new Engram("Cloth Hat", false, 3, 3, 12),
            new Engram("Wooden Sign", false, 3, 3, 13),
            new Engram("Hide Sleeping Bag", false, 3, 3, 14),
            new Engram("Thatch Roof", false, 3, 3, 15),
            new Engram("Thatch Wall", false, 3, 3, 16),
            new Engram("Thatch Door", false, 3, 3, 17),

            // Level 5
            new Engram("Slingshot", false, 6, 5, 18),
            new Engram("Storage Box", false, 6, 5, 19),
            new Engram("Simple Bed", false, 8, 5, 20),
            new Engram("Phiomia Saddle", false, 6, 5, 21),
            new Engram("Mortar & Pestle", false, 6, 5, 22),
            new Engram("Sparkpowder", false, 3, 5, 23),
            new Engram("Blood Extraction Syringe", false, 6, 5, 24),
            new Engram("Narcotic", false, 6, 5, 25),
            new Engram("Paintbrush", false, 3, 5, 26),
            new Engram("Single Panel Flag", false, 6, 5, 27),
            new Engram("Multi-Panel Flag", false, 6, 5, 28),
            new Engram("Standing Torch", false, 6, 5, 29),
            new Engram("Sloped Thatch Wall (Left)", false, 3, 5, 30),
            new Engram("Sloped Thatch Wall (Right)", false, 3, 5, 31),
            new Engram("Sloped Thatch Roof", false, 3, 5, 32),
            new Engram("Wooden Foundation", false, 6, 5, 33),
            new Engram("Wooden Wall", false, 7, 5, 34),

            // Level 10
            new Engram("Cooking Pot", false, 9, 10, 36),
            new Engram("Cementing Paste", false, 3, 10, 37),
            new Engram("Stimulant", false, 6, 10, 38),
            new Engram("Gunpowder", false, 2, 10, 39),
            new Engram("Flare Gun", false, 6, 10, 40),
            new Engram("Compass", false, 5, 10, 43),
            new Engram("Spyglass", false, 2, 10, 44),
            new Engram("Small Crop Plot", false, 9, 10, 45),
            new Engram("Basic Gravestone", false, 8, 10, 46),
            new Engram("Wardrums", false, 6, 10, 47),
            new Engram("Parasaur Saddle", false, 9, 10, 48),
            new Engram("Ichtyosaurus Saddle", false, 8, 10, 49),
            new Engram("Intake Stone Pipe", false, 5, 10, 50),
            new Engram("Straight Stron Pipe", false, 2, 10, 51),
            new Engram("Stone Pipe Tap", false, 5, 10, 52),
            new Engram("Wooden Spike Wall", false, 4, 10, 53),
            new Engram("Wooden Wall Sign", false, 2, 10, 55),
            new Engram("Wooden Ceiling", false, 6, 10, 56),
            new Engram("Sloped Wood Wall (Left)", false, 3, 10, 58),
            new Engram("Sloped Wood Wall (Right)", false, 3, 10, 59),
            new Engram("Sloped Wooden Roof", false, 4, 10, 60),
            new Engram("Wooden Doorframe", false, 6, 10, 61),
            new Engram("Wooden Door", false, 4, 10, 62),
            new Engram("Wooden Chair", false, 6, 10, 35),
            new Engram("Painting Canvas", false, 2, 10, 54),
            new Engram("Wooden Railing", false, 3, 10, 57),
            new Engram("Wooden Sheild", false, 7, 10, 41),
            new Engram("Wooden Cage", false, 10, 10, 42),

            // Level 15
            new Engram("Wooden Fence Foundation", false, 6, 15, 63),
            new Engram("Hide Pants", false, 9, 15, 64),
            new Engram("Hide Shirt", false, 6, 15, 65),
            new Engram("Bow", false, 11, 15, 66),
            new Engram("Stone Arrow", false, 2, 15, 67),
            new Engram("Large Storage Box", false, 9, 15, 68),
            new Engram("Wooden Raft", false, 11, 15, 71),
            new Engram("Parachute", false, 6, 15, 72),
            new Engram("Bug Repellant", false, 12, 15, 73),
            new Engram("Pachy Saddle", false, 9, 15, 74),
            new Engram("Raptor Saddle", false, 9, 15, 75),
            new Engram("Intersection Stone Pipe", false, 5, 15, 76),
            new Engram("Inclined Stone Pipe", false, 3, 15, 77),
            new Engram("Vertical Stone Pipe", false, 3, 15, 78),
            new Engram("Compost Bin", false, 6, 15, 79),
            new Engram("Stone Fence Foundation", false, 6, 15, 80),
            new Engram("Stone Wall", false, 8, 15, 81),
            new Engram("Water Reservoir", false, 7, 15, 82),
            new Engram("Wooden Billboard", false, 4, 15, 83),
            new Engram("Wooden Ramp", false, 3, 15, 84),
            new Engram("Dinosaur Gateway", false, 7, 15, 85),
            new Engram("Dinosaur Gate", false, 5, 15, 86),
            new Engram("Wooden Pillar", false, 9, 15, 87),
            new Engram("Wooden Hatchframe", false, 9, 15, 88),
            new Engram("Wooden Ladder", false, 6, 15, 89),
            new Engram("Feeding Trough", false, 12, 15, 90),
            new Engram("Wooden Bench", false, 10, 15, 69),
            new Engram("Wooden Table", false, 7, 15, 70),

            // Level 20
            new Engram("Hide Gloves", false, 7, 20, 91),
            new Engram("Hide Boots", false, 7, 20, 92),
            new Engram("Hide Hat", false, 9, 20, 93),
            new Engram("Magnifying Glass", false, 16, 20, 115),
            new Engram("Tranquilizer Arrow", false, 8, 20, 94),
            new Engram("Refining Forge", false, 21, 20, 97),
            new Engram("Trike Saddle", false, 12, 20, 98),
            new Engram("Tripwire Alarm Trap", false, 7, 20, 99),
            new Engram("Trophy Base", false, 10, 20, 100),
            new Engram("Trophy Wall Mount", false, 10, 20, 96),
            new Engram("Preserving Bin", false, 9, 20, 101),
            new Engram("Wooden Catwalk", false, 8, 20, 102),
            new Engram("Wooden Trapdoor", false, 6, 20, 103),
            new Engram("Wooden Windowframe", false, 9, 20, 104),
            new Engram("Stone Foundation", false, 6, 20, 105),
            new Engram("Stone Ceiling", false, 6, 20, 106),
            new Engram("Sloped Stone Wall (Left)", false, 3, 20, 108),
            new Engram("Sloped Stone Wall (Right)", false, 3, 20, 109),
            new Engram("Sloped Stone Roof", false, 4, 20, 110),
            new Engram("Stone Doorframe", false, 6, 20, 111),
            new Engram("Reinforced Wooden Door", false, 4, 20, 112),
            new Engram("Stone Dinosaur Gateway", false, 9, 20, 113),
            new Engram("Reinforced Dinosaur Gate", false, 6, 20, 114),
            new Engram("Bookshelf", false, 5, 20, 116),
            new Engram("Stone Railing", false, 4, 20, 107),

            // Level 25
            new Engram("Smithy", false, 16, 25, 117),
            new Engram("Metal Spike Wall", false, 11, 25, 119),
            new Engram("Metal Pick", false, 6, 25, 120),
            new Engram("Metal Hatchet", false, 6, 25, 121),
            new Engram("Pike", false, 10, 25, 122),
            new Engram("Fur Boots", false, 12, 25, 124),
            new Engram("Fur Gauntlets", false, 12, 25, 125),
            new Engram("Fur Cap", false, 14, 25, 126),
            new Engram("Fur Leggings", false, 16, 25, 127),
            new Engram("Fur Chestpiece", false, 16, 25, 128),
            new Engram("Crossbow", false, 12, 25, 129),
            new Engram("Tripwire Narcotic Trap", false, 9, 25, 130),
            new Engram("Pulmonoscorpius Saddle", false, 12, 25, 133),
            new Engram("Carbronemys Saddle", false, 12, 25, 134),
            new Engram("Beelzebufo Saddle", false, 16, 25, 95),
            new Engram("Terror Bird Saddle", false, 15, 25, 123),
            new Engram("Medium Crop Plot", false, 12, 25, 135),
            new Engram("Metal Sign", false, 10, 25, 136),
            new Engram("Stone Pillar", false, 8, 25, 138),
            new Engram("Stone Hatchframe", false, 8, 25, 139),
            new Engram("Stone Windowframe", false, 11, 25, 140),
            new Engram("Wooden Window", false, 6, 25, 141),
            new Engram("Bear Trap", false, 9, 25, 131),
            new Engram("Large Bear Trap", false, 12, 25, 132),
            new Engram("Handcuffs", false, 16, 25, 118),
            new Engram("Radio", false, 8, 25, 142),
            new Engram("Smoke Grenade", false, 18, 25, 143),
            new Engram("Ballista Turret", false, 25, 25, 144),
            new Engram("Ballista Bolt", false, 10, 25, 145),
            new Engram("Wall Torch", false, 8, 25, 137),

            // Level 30
            new Engram("Behemoth Stone Dinosaur Gateway", false, 12, 30, 146),
            new Engram("Behemoth Reinforced Dinosaur Gate", false, 16, 30, 147),
            new Engram("Chitin Leggings", false, 15, 30, 148),
            new Engram("Chitin Chestpiece", false, 18, 30, 149),
            new Engram("Chitin Helmet", false, 18, 30, 150),
            new Engram("Catapult Turret", false, 25, 30, 151),
            new Engram("Water Jar", false, 12, 30, 152),
            new Engram("Simple Pistol", false, 15, 30, 158),
            new Engram("Simple Bullet", false, 6, 30, 159),
            new Engram("Scope Attachment", false, 13, 30, 160),
            new Engram("Metal Sickle", false, 12, 30, 161),
            new Engram("Stego Saddle", false, 15, 30, 162),
            new Engram("Doedicurus Saddle", false, 20, 30, 163),
            new Engram("Paracer Saddle", false, 18, 30, 164),
            new Engram("Megaloceros Saddle", false, 20, 30, 154),
            new Engram("Grenade", false, 20, 30, 165),
            new Engram("Reinforced Trapdoor", false, 10, 30, 166),
            new Engram("Reinforced Window", false, 10, 30, 167),
            new Engram("Metal Wall Sign", false, 6, 30, 168),
            new Engram("Metal Foundation", false, 24, 30, 169),
            new Engram("Metal Wall", false, 15, 30, 170),
            new Engram("Sloped Metal Wall (Left)", false, 7, 30, 172),
            new Engram("Sloped Metal Wall (Right)", false, 7, 30, 173),
            new Engram("Metal Doorframe", false, 24, 30, 174),
            new Engram("Metal Railing", false, 7, 30, 171),
            new Engram("Metal Sword", false, 11, 30, 157),
            new Engram("Metal Shield", false, 9, 30, 155),
            new Engram("Stone Fireplace", false, 15, 30, 153),

            // Level 35
            new Engram("Chitin Gauntlets", false, 15, 35, 175),
            new Engram("Chitin Boots", false, 15, 35, 176),
            new Engram("Longneck Rifle", false, 18, 35, 181),
            new Engram("Simple Rifle Ammo", false, 6, 35, 182),
            new Engram("Large Crop Plot", false, 15, 35, 183),
            new Engram("Pteranodon Saddle", false, 15, 35, 184),
            new Engram("Sarco Saddle", false, 15, 35, 185),
            new Engram("Shotgun", false, 18, 35, 186),
            new Engram("Simple Shotgun Ammo", false, 6, 35, 187),
            new Engram("Metal Pillar", false, 18, 35, 189),
            new Engram("Metal Ceiling", false, 15, 35, 190),
            new Engram("Sloped Metal Roof", false, 10, 35, 191),
            new Engram("Metal Door", false, 12, 35, 192),
            new Engram("Metal Ramp", false, 12, 35, 193),
            new Engram("Re-Fertilizer", false, 20, 35, 194),
            new Engram("Ghillie Chestpiece", false, 11, 35, 177),
            new Engram("Ghillie Leggings", false, 11, 35, 178),
            new Engram("Ghillie Mask", false, 13, 35, 179),
            new Engram("Beer Barrel", false, 24, 35, 180),

            // Level 40
            new Engram("Poison Grenade", false, 18, 40, 188),
            new Engram("Fabricator", false, 24, 40, 197),
            new Engram("Silencer Attachment", false, 13, 40, 198),
            new Engram("Ankylo Saddle", false, 18, 40, 199),
            new Engram("Araneo Saddle", false, 18, 40, 201),
            new Engram("Mammoth Saddle", false, 18, 40, 200),
            new Engram("Intake Metal Pipe", false, 15, 40, 202),
            new Engram("Straight Metal Pipe", false, 12, 40, 203),
            new Engram("Metal Hatchframe", false, 18, 40, 204),
            new Engram("Metal Trapdoor", false, 14, 40, 205),
            new Engram("Metal Fence Foundation", false, 12, 40, 206),
            new Engram("Metal Dinosaur Gateway", false, 12, 40, 207),
            new Engram("Metal Dinosaur Gate", false, 8, 40, 208),
            new Engram("Polymer", false, 6, 40, 209),
            new Engram("Electronics", false, 6, 40, 210),
            new Engram("Ghillie Boots", false, 11, 40, 196),
            new Engram("Ghillie Gauntlets", false, 11, 40, 195),

            // Level 45
            new Engram("Flak Leggings", false, 15, 45, 211),
            new Engram("Flak Chestpiece", false, 18, 45, 212),
            new Engram("Improvised Explosive Device", false, 30, 45, 213),
            new Engram("Intersection Metal Pipe", false, 18, 45, 214),
            new Engram("Inclined Metal Pipe", false, 12, 45, 215),
            new Engram("Vertical Metal Pipe", false, 12, 45, 216),
            new Engram("Tap Metal Pipe", false, 18, 45, 217),
            new Engram("Metal Water Reservoir", false, 20, 45, 218),
            new Engram("Megalodon Saddle", false, 18, 45, 219),
            new Engram("Sabertooth Saddle", false, 18, 45, 220),
            new Engram("Paracer Platform Saddle", false, 24, 45, 221),
            new Engram("Industrial Grill", false, 40, 45, 222),
            new Engram("Metal Windowframe", false, 18, 45, 223),
            new Engram("Metal Ladder", false, 21, 45, 224),
            new Engram("Flashlight Attachment", false, 18, 45, 229),
            new Engram("GPS", false, 21, 45, 230),
            new Engram("Greenhouse Wall", false, 30, 45, 225),
            new Engram("Greenhouse Ceiling", false, 30, 45, 226),
            new Engram("Greenhouse Doorframe", false, 15, 45, 227),
            new Engram("Greenhouse Door", false, 15, 45, 228),
            new Engram("Greenhouse Window", false, 15, 45, 240),

            // Level 50
            new Engram("Flak Boots", false, 16, 50, 231),
            new Engram("Flak Gauntlets", false, 16, 50, 232),
            new Engram("Flak Helmet", false, 20, 50, 233),
            new Engram("Metal Billboard", false, 15, 50, 234),
            new Engram("Metal Window", false, 18, 50, 235),
            new Engram("Metal Catwalk", false, 18, 50, 236),
            new Engram("Carno Saddle", false, 21, 50, 241),
            new Engram("Procoptodon Saddle", false, 35, 50, 254),
            new Engram("Gallimimus Saddle", false, 20, 50, 156),
            new Engram("Canteen", false, 24, 50, 242),
            new Engram("Electrical Generator", false, 24, 50, 244),
            new Engram("Straight Electrical Cable", false, 16, 50, 245),
            new Engram("Electrical Outlet", false, 16, 50, 246),
            new Engram("Fabricated Pistol", false, 18, 50, 247),
            new Engram("Advanced Bullet", false, 8, 50, 248),
            new Engram("Pump-Action Shotgun", false, 18, 50, 249),
            new Engram("Grappling Hook", false, 40, 50, 243),
            new Engram("Remote Keypad", false, 18, 50, 250),
            new Engram("Omni-Directional Lamppost", false, 20, 50, 251),
            new Engram("Lamppost", false, 20, 50, 252),
            new Engram("War Map", false, 15, 50, 253),
            new Engram("Sloped Greenhouse Roof", false, 30, 50, 239),
            new Engram("Sloped Greenhouse Wall (Left)", false, 15, 50, 237),
            new Engram("Sloped Greenhouse Wall (Right)", false, 15, 50, 238),

            // Level 55
            new Engram("Inclined Electrical Cable", false, 16, 55, 255),
            new Engram("Vertical Electrical Cable", false, 16, 55, 256),
            new Engram("Intersection Electrical Cable", false, 24, 55, 257),
            new Engram("Argentavis Saddle", false, 21, 55, 258),
            new Engram("Bronto Saddle", false, 21, 55, 259),
            new Engram("Refrigerator", false, 20, 55, 260),
            new Engram("Air Conditioner", false, 21, 55, 261),
            new Engram("C4 Remote Detonator", false, 24, 55, 262),
            new Engram("C4 Charge", false, 12, 55, 263),
            new Engram("Assault Rifle", false, 24, 55, 264),
            new Engram("Advanced Rifle Bullet", false, 8, 55, 265),
            new Engram("Laser Attachment", false, 24, 55, 266),
            new Engram("Holoscope Attachment", false, 24, 55, 267),
            new Engram("Behemoth Gateway", false, 28, 55, 268),
            new Engram("Behemoth Gate", false, 15, 55, 269),

            // Level 60
            new Engram("Rex Saddle", false, 40, 60, 270),
            new Engram("Spino Saddle", false, 40, 60, 271),
            new Engram("Rocket Launcher", false, 32, 60, 275),
            new Engram("Rocket Propelled Grenade", false, 8, 60, 276),
            new Engram("Auto Turret", false, 40, 60, 277),
            new Engram("Spray Painter", false, 30, 60, 273),
            new Engram("Quetz Saddle", false, 44, 60, 278),
            new Engram("Bunk Bed", false, 28, 60, 272),

            // Level 65
            new Engram("Heavy Miner's Helmet", false, 35, 65, 283),
            new Engram("Transponder Tracker", false, 30, 65, 284),
            new Engram("Transponder Node", false, 20, 65, 285),
            new Engram("Vault", false, 30, 65, 286),
            new Engram("Plesiosaur Saddle", false, 40, 65, 287),
            new Engram("Elevator Track", false, 40, 65, 279),
            new Engram("Small Elevator Platform", false, 40, 65, 280),
            new Engram("Medium Elevator Platform", false, 40, 65, 281),
            new Engram("Large Elevator Platform", false, 40, 65, 282),
            new Engram("Tranquilizer Dart", false, 30, 65, 274),

            // Level 70
            new Engram("Compound Bow", false, 40, 70, 290),
            new Engram("Metal Arrow", false, 35, 70, 291),
            new Engram("Bronto Platform Saddle", false, 35, 70, 292),
            new Engram("Fabricated Sniper Rifle", false, 36, 70, 288),
            new Engram("Advanced Sniper Bullet", false, 16, 70, 289),

            // Level 75
            new Engram("SCUBA Mask", false, 25, 75, 295),
            new Engram("SCUBA Tank", false, 35, 75, 294),
            new Engram("SCUBA Leggings", false, 35, 75, 297),
            new Engram("SCUBA Flippers", false, 20, 75, 296),
            new Engram("Riot Shield", false, 45, 75, 293),
            new Engram("Homing Underwater Mine", false, 30, 75, 298),
            new Engram("Mosasaurus Saddle", false, 60, 75, 299),

            // Level 80
            new Engram("Riot Helmet", false, 40, 80, 308),
            new Engram("Riot Chestpiece", false, 40, 80, 305),
            new Engram("Riot Gauntlets", false, 40, 80, 306),
            new Engram("Riot Leggings", false, 40, 80, 304),
            new Engram("Riot Boots", false, 40, 80, 307),
            new Engram("Electric Prod", false, 60, 80, 301),
            new Engram("Plesiosaur Platform Saddle", false, 50, 80, 302),
            new Engram("Quetz Platform Saddle", false, 80, 80, 303),
            new Engram("Industrial Cooker", false, 60, 80, 300),

            // Level 85
            new Engram("Mosasaurus Platform Saddle", false, 80, 85, 311),
            new Engram("Giganotosaurus Saddle", false, 75, 85, 312),
            new Engram("Minigun Turret", false, 80, 85, 310),
            new Engram("Industrial Forge", false, 90, 85, 309),

            // Level 90
            new Engram("Rocket Turret", false, 100, 90, 313)
        };

        public String engramTag { get; set; }

        public Boolean hideEngram { get; set; }

        public int epCost { get; set; }
        public int levelRequired { get; set; }

        private int index;

        /// <summary>
        ///     Initializes the engram class
        /// </summary>
        /// 
        /// <param name="engramTag">The tag for this engram</param>
        /// <param name="hideEngram">Whether this engram should be hidden</param>
        /// <param name="epCost">The EP cost for this engram</param>
        /// <param name="levelRequired">The level required for this engram</param>
        public Engram(String engramTag, Boolean hideEngram, int epCost, int levelRequired, int index)
        {
            this.engramTag = engramTag;
            this.hideEngram = hideEngram;
            this.epCost = epCost;
            this.levelRequired = levelRequired;

            this.index = index;
        }

        /// <summary>
        ///     Retrieves the original engram for a given tag
        /// </summary>
        /// 
        /// <param name="tag">The tag of the engram to get</param>
        /// 
        /// <returns>The original copy of the engram with the given tag</returns>
        public static Engram getByTag(String tag)
        {
            Engram e = null;

            Boolean found = false;
            int i = 0;
            while (!found && i < engrams.Count())
            {
                if (tag.Equals(engrams[i].engramTag))
                {
                    e = engrams[i];
                    found = true;
                }
            }

            return e;
        }

        /// <summary>
        ///     Checks if the given engram is identical to the original
        /// </summary>
        /// 
        /// <param name="engram">The engram to compare</param>
        /// 
        /// <returns>True if same as the original</returns>
        public static Boolean isDefault(Engram engram)
        {
            Boolean defaultEngram = true;
            Engram original = getByTag(engram.engramTag);

            if(original != null)
            {
                defaultEngram = engram.hideEngram == original.hideEngram ? defaultEngram : false;
                defaultEngram = engram.epCost == original.epCost ? defaultEngram : false;
                defaultEngram = engram.levelRequired == original.levelRequired ? defaultEngram : false;
            }

            return defaultEngram;
        }

        public int getEngramIndex()
        {
            return index;
        }
    }
}
