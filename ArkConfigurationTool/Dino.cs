using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class Dino
    {
        public static Dino[] dinos =
        {
            new Dino("Anky"),
            new Dino("Argent"),
            new Dino("Bat"),
            new Dino("Bronto"),
            new Dino("Carno"),
            new Dino("Coel"),
            new Dino("Dilo"),
            new Dino("Dodo"),
            new Dino("Mammoth"),
            new Dino("Mega"),
            new Dino("Para"),
            new Dino("Phiomia"),
            new Dino("Piranha"),
            new Dino("Ptera"),
            new Dino("Raptor"),
            new Dino("Rex"),
            new Dino("Sabertooth"),
            new Dino("Sarco"),
            new Dino("Scorpion"),
            new Dino("Stego"),
            new Dino("Spino"),
            new Dino("Spider"),
            new Dino("Titanboa"),
            new Dino("Trike"),
            new Dino("Turtle")
        };

        public String tag { get; set; }
        public Boolean allowSpawn { get; set; }
        public Boolean allowTame { get; set; }
        public float spawnRate { get; set; }
        public float spawnLimit { get; set; }
        public String overrideAiTag { get; set; }

        /// <summary>
        ///     Builds a default dino from it's tag
        /// </summary>
        /// 
        /// <param name="tag">The tag of the dino</param>
        public Dino(String tag)
        {
            // set default values here
            this.tag = tag;
            allowSpawn = true;
            allowTame = true;
            spawnRate = 1.0f;
            spawnLimit = 1.0f;
            overrideAiTag = tag;
        }

        public Dino(/* Row data here? */)
        {
            // set values from row here
        }

        /// <summary>
        ///     Determines if a dino is set to default settings
        ///     (so we can ignore it if it is when outputting)
        /// </summary>
        /// 
        /// <returns>true if dino is default settings</returns>
        public Boolean isDefault()
        {
            Boolean result = true;

            // Check here
            result = tag.Equals(overrideAiTag) ? result : false;
            result = allowSpawn == true ? result : false;
            result = allowTame == true ? result : false;
            result = spawnRate == 1.0f ? result : true;
            result = spawnLimit == 1.0f ? result : true;

            return result;
        }

        public static String getDinoClassName(String tag)
        {
            String name = "";

            switch(tag.ToLower())
            {
                case "anky":
                    name = "Ankylo_Character_BP_C";
                    break;
                case "argent":
                    name = "Argent_Character_BP_C";
                    break;
                case "bat":
                    name = "Bat_Character_BP_C";
                    break;
                case "bronto":
                    name = "Sauropod_Character_BP_C";
                    break;
                case "carno":
                    name = "Carno_Character_BP_C";
                    break;
                case "coel":
                    name = "Coel_Character_BP_C";
                    break;
                case "dilo":
                    name = "Dilo_Character_BP_C";
                    break;
                case "dodo":
                    name = "Dimetro_Character_BP_C";
                    break;
                case "mammoth":
                    name = "Mammoth_Character_BP_C";
                    break;
                case "mega":
                    name = "Megalodon_Character_BP_C";
                    break;
                case "para":
                    name = "Para_Character_BP_C";
                    break;
                case "phiomia":
                    name = "Phiomia_Character_BP_C";
                    break;
                case "piranha":
                    name = "Piranha_Character_BP_C";
                    break;
                case "ptera":
                    name = "Ptero_Character_BP_C";
                    break;
                case "raptor":
                    name = "Raptor_Character_BP_C";
                    break;
                case "rex":
                    name = "Rex_Character_BP_C";
                    break;
                case "sabertooth":
                    name = "Saber_Character_BP_C";
                    break;
                case "sarco":
                    name = "Sarco_Character_BP_C";
                    break;
                case "scorpion":
                    name = "Scorpion_Character_BP_C";
                    break;
                case "stego":
                    name = "Stego_Character_BP_C";
                    break;
                case "spino":
                    name = "";
                    break;
                case "spider":
                    name = "SpiderS_Character_BP_C";
                    break;
                case "titanboa":
                    name = "BoaFrill_Character_BP_C";
                    break;
                case "trike":
                    name = "Trike_Character_BP_C";
                    break;
                case "turtle":
                    name = "Turtle_Character_BP_C";
                    break;
            }

            return name;
        }
    }
}
