using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SavedGameSynchronizer.common;
using SavedGameSynchronizer.model;

namespace SavedGameSynchronizer.service
{
    class GameService
    {
        //Constant related to PC
        public const string RC_GENERIC_OK = "dis is fine";
        public const string RC_GET_GAME_OK = "get game ok~";
        public const string RC_GET_GAME_NOT_EXIST = "game does not exist";

        private DatabaseAccessService das = new DatabaseAccessService();

        public void RegisterGame(Game newGame)
        {
            string registerGameQuery = "insert into Game(gameid,gameName,OneDrvFolderName) values('" + newGame.Id + "','" + newGame.Name + "','" + newGame.OneDrvFolderName + "');";
            int resultCode = das.executeQuery(registerGameQuery);
            HandleRegisterGameResultCode(newGame, resultCode);
        }

        public void HandleRegisterGameResultCode(Game game, int resultCode)
        {
            switch (resultCode)
            {
                case (int)SQLiteErrorCode.Ok:
                    MessageBox.Show(game.Name + "has been added.");
                    break;
                case (int)SQLiteErrorCode.Constraint:
                    MessageBox.Show("This game has already been registered.");
                    break;
            }
        }

        /// <summary>
        /// Check if input pc has already been in the database
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public bool doesgameExist(Game game)
        {
            bool gameExist = false;
            string getgameQuery = "select * from Game where gameId='" + game.Id + "';";
            DataTable resultTable = das.getSelectResult(getgameQuery);
            gameExist = resultTable != null;
            return gameExist;
        }

        /// <summary>
        /// Check if game Id is in the database
        /// </summary>
        /// <returns></returns>
        public bool doesThisGameIdExist(string gameId)
        {
            Game game = new Game();
            game.Id = gameId;
            return doesgameExist(game);
        }

        /// <summary>
        /// Get game by game Id
        /// </summary>
        /// <param name="Id">game Id</param>
        /// <returns>ReturnResult with content as a Game object.</returns>
        public ReturnResult getGameById(string Id)
        {
            ReturnResult result = new ReturnResult(RC_GET_GAME_NOT_EXIST);
            string getGameQuery = "select * from Game where gameId='" + Id + "';";
            DataTable resultTable = das.getSelectResult(getGameQuery);
            if (resultTable != null)
            {
                result.Code = RC_GET_GAME_OK;
                string resultGameId = resultTable.Rows[0]["gameId"].ToString();
                string resultGameName = resultTable.Rows[0]["gameName"].ToString();
                string resultGameOneDrvPath = resultTable.Rows[0]["OneDrvFolderName"].ToString();
                Game returnGame = new Game(resultGameId, resultGameName, resultGameOneDrvPath);
                result.Content = returnGame;
            }
            return result;
        }
    }
}
