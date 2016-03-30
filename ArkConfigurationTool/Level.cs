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

        public Level(int level, int xpDifference, int xpForLevel, int epForLevel)
        {
            this.level = level;
            this.xpDifference = xpDifference;
            this.xpForLevel = xpForLevel;
            this.epForLevel = epForLevel;
        }

    }
}
