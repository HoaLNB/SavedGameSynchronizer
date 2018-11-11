using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavedGameSynchronizer.common;

namespace SavedGameSynchronizer.model
{
    class Pc
    {
        public string Id { get; set; }

        public string PcName { get; set; }

        public string OneDrvFolderPath { get; set; }

        public Pc()
        {
            initializeId();
        }

        public Pc(string pcName, string oneDrvFolderPath)
        {
            initializeId();
            PcName = pcName;
            OneDrvFolderPath = oneDrvFolderPath;
        }

        public Pc(string id, string pcName, string oneDrvFolderPath)
        {
            Id = id;
            PcName = pcName;
            OneDrvFolderPath = oneDrvFolderPath;
        }

        private void initializeId()
        {
            string systemUuid = SystemUtils.GetSystemUuid();
            Id = !string.IsNullOrEmpty(systemUuid) ? systemUuid : Guid.NewGuid().ToString();
        }
    }
}
