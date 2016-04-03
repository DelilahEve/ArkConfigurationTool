using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class Level
    {

        public int level { get; set; }
        public int xpDifference { get; set; }
        public int xpForLevel { get; set; }
        public int epForLevel { get; set; }

        /// <summary>
        ///     Initializes the level object
        /// </summary>
        /// 
        /// <param name="level">the level this object represents</param>
        /// <param name="xpDifference">xp difference between this level and the previous</param>
        /// <param name="xpForLevel">xp required for this level</param>
        /// <param name="epForLevel">ep rewarded for reaching this level</param>
        public Level(int level, int xpDifference, int xpForLevel, int epForLevel)
        {
            this.level = level;
            this.xpDifference = xpDifference;
            this.xpForLevel = xpForLevel;
            this.epForLevel = epForLevel;
        }

    }
}
