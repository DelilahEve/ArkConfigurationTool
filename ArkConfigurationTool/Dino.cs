using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class Dino
    {
        public Dino[] dinos =
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

        private String tag;
        private Boolean allowSpawn;
        private Boolean allowTame;
        private float spawnRate;
        private float spawnLimit;
        private String overrideAiTag;

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
        ///     Gets the dino tag
        /// </summary>
        /// 
        /// <returns>Dino's tag</returns>
        public String getTag()
        {
            return tag;
        }

        /// <summary>
        ///  Gets whether to allow this dino to spawn
        /// </summary>
        /// 
        /// <returns>true if spawn allowed</returns>
        public Boolean getAllowSpawn()
        {
            return allowSpawn;
        }

        /// <summary>
        ///     Gets whether to allow taming this dino
        /// </summary>
        /// 
        /// <returns>true if tame allowed</returns>
        public Boolean getAllowTame()
        {
            return allowTame;
        }

        /// <summary>
        ///     Gets the spawn rate for the dino
        /// </summary>
        /// 
        /// <returns>the multiplier for the dino's spawn rate</returns>
        public float getSpawnRate()
        {
            return spawnRate;
        }

        /// <summary>
        ///     Gets the spawn limit percentage
        /// </summary>
        /// 
        /// <returns>the percentage multiplier of the spawn limit</returns>
        public float getSpawnLimit()
        {
            return spawnLimit;
        }

        /// <summary>
        ///     Gets the dino to override this one with
        /// </summary>
        /// 
        /// <returns>The tag of the dino to override this one's AI</returns>
        public String getOVerrideAiTag()
        {
            return overrideAiTag;
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
    }
}
