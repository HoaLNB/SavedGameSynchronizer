using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavedGameSynchronizer.model
{
    class GameSave
    {
        private string id;
        private string pcId;
        private string gameId;
        private long saveTime;
        private string saveFolderPath;

        public GameSave()
        {
            id = Guid.NewGuid().ToString();
            saveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public GameSave(string pcId, string gameId, string saveFolderPath)
        {
            id = Guid.NewGuid().ToString();
            saveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            this.pcId = pcId;
            this.gameId = gameId;
            this.saveFolderPath = saveFolderPath;
        }

        public GameSave(string id, string pcId, string gameId, long saveTime, string saveFolderPath)
        {
            this.id = id;
            this.pcId = pcId;
            this.gameId = gameId;
            this.saveTime = saveTime;
            this.saveFolderPath = saveFolderPath;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PcId
        {
            get { return pcId; }
            set { pcId = value; }
        }

        public string GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        public long SaveTime
        {
            get { return saveTime; }
            set { saveTime = value; }
        }

        public string SaveFolderPath
        {
            get { return saveFolderPath; }
            set { saveFolderPath = value; }
        }
    }
}
