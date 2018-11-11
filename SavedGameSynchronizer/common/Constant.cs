using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavedGameSynchronizer.common
{
    class Constant
    {
        public static string TXT_DB_CONNECTION_STRING = @"Data Source=SGS.db;Version=3;";
        public static string DB_TABLE_NAME_PC = "PC";
        public static string DB_TABLE_NAME_GAME = "Game";
        public static string DB_TABLE_NAME_GAMEPCCON = "Game_PC_Connection";
        public static string DB_TABLE_NAME_GAMESAVE = "GameSave";

        //Register/Update PC Form Mode
        public const string MODE_PCFORM_REGISTER = "Register PC";
        public const string MODE_PCFORM_UPDATE = "Update PC";
    }
}
