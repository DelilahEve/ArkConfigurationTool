using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkConfigurationTool
{
    class ConfigData
    {

        private String fileName;
        private String path;

        /// <summary>
        ///     Sets up interface for .act files
        /// </summary>
        /// 
        /// <param name="fileName">The name of the file</param>
        /// <param name="path">The path to the file</param>
        public ConfigData(String fileName, String path)
        {
            this.fileName = fileName + ".act";
            this.path = path;
        }

        /// <summary>
        ///     Reads the settings in the config file into a list
        /// </summary>
        /// 
        /// <returns>list of options set and their values</returns>
        public List<String> read()
        {
            List<String> settings = new List<String>();

            // read settings into list

            return settings;
        }

        /// <summary>
        ///     Writes the settings to the config file from a list
        /// </summary>
        /// 
        /// <param name="settings"></param>
        public void write(List<String> settings)
        {
            // write settings to file here
        }
    }
}
