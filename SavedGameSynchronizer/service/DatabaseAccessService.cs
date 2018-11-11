using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavedGameSynchronizer.common;
using SavedGameSynchronizer.Properties;

namespace SavedGameSynchronizer.service
{
    class DatabaseAccessService
    {
        SQLiteConnection con = new SQLiteConnection(Constant.TXT_DB_CONNECTION_STRING);
        /// <summary>
        /// Execute SQLite Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int executeQuery(string query)
        {
            con.Open();
            int resultCode = (int)SQLiteErrorCode.Ok;
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, con);
                int queryResult = command.ExecuteNonQuery();
                Console.WriteLine(Resources.txt_DatabaseAccessService_executeQuery_Affected_row + queryResult);
            }
            catch (SQLiteException sqlEx)
            {
                resultCode = sqlEx.ErrorCode;
                Console.WriteLine(Resources.DatabaseAccessService_SQLite_Error_Code_ + sqlEx.ErrorCode);
            }
            con.Close();
            return resultCode;
        }

        /// <summary>
        /// Get select query result
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable getSelectResult(string query)
        {
            DataTable resultDataTable = new DataTable();
            con.Open();
            SQLiteCommand command = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(resultDataTable);
            con.Close();
            return resultDataTable;
        }
    }
}
