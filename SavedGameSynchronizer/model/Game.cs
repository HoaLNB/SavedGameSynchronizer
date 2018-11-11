using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavedGameSynchronizer.model
{
    class Game
    {
        private string id;
        private string name;
        private string oneDrvFolderName;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string OneDrvFolderName
        {
            get { return oneDrvFolderName; }
            set { oneDrvFolderName = value; }
        }

        public Game()
        {
            id = Guid.NewGuid().ToString();
        }

        public Game(string name)
        {
            this.name = name;
            id = Guid.NewGuid().ToString();
        }

        public Game(string name, string oneDrvFolderName)
        {
            this.name = name;
            this.oneDrvFolderName = oneDrvFolderName;
            id = Guid.NewGuid().ToString();
        }

        public Game(string id, string name, string oneDrvFolderName)
        {
            this.id = id;
            this.name = name;
            this.oneDrvFolderName = oneDrvFolderName;
        }
    }
}
