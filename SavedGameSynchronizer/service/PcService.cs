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
    internal class PcService
    {
        //Constant related to PC
        public const string RC_GENERIC_OK = "dis is fine";
        public const string RC_GET_PC_OK = "get pc ok~";
        public const string RC_GET_PC_NOT_EXIST = "pc does not exist";

        private DatabaseAccessService das = new DatabaseAccessService();

        public void RegisterPc(Pc newPc)
        {
            string registerPcQuery = "insert into PC(pcId,pcName,oneDrvFolderPath) values('"+ newPc.Id + "','" + newPc.PcName + "','" + newPc.OneDrvFolderPath +"');";
            int resultCode = das.executeQuery(registerPcQuery);
            HandleRegisterPcResultCode(newPc, resultCode);
        }

        public void HandleRegisterPcResultCode(Pc pc, int resultCode)
        {
            switch (resultCode)
            {
                case (int)SQLiteErrorCode.Ok:
                    MessageBox.Show(pc.PcName + "has been added.");
                    break;
                case (int)SQLiteErrorCode.Constraint:
                    MessageBox.Show("This PC has already been registered.");
                    break;
            }
        }

        /// <summary>
        /// Check if input pc has already been in the database
        /// </summary>
        /// <param name="pc"></param>
        /// <returns></returns>
        public bool doesPcExist(Pc pc)
        {
            bool pcExist = false;
            string getPCQuery = "select * from PC where pcId='" + pc.Id + "';";
            DataTable resultTable = das.getSelectResult(getPCQuery);
            pcExist = resultTable != null;
            return pcExist;
        }

        /// <summary>
        /// Check if current pc is in the database
        /// </summary>
        /// <returns></returns>
        public bool doesThisPcExist()
        {
            return doesPcExist(new Pc());
        }

        /// <summary>
        /// Get Pc by pcId
        /// </summary>
        /// <param name="Id">Pc Id</param>
        /// <returns>ReturnResult with content as a Pc object.</returns>
        public ReturnResult getPcById(string Id)
        {
            ReturnResult result = new ReturnResult(RC_GET_PC_NOT_EXIST);
            string getPCQuery = "select * from PC where pcId='" + Id + "';";
            DataTable resultTable = das.getSelectResult(getPCQuery);
            if (resultTable != null)
            {
                result.Code = RC_GET_PC_OK;
                string resultPcId = resultTable.Rows[0]["pcId"].ToString();
                string resultPcName = resultTable.Rows[0]["pcName"].ToString();
                string resultPcOneDrvPath = resultTable.Rows[0]["oneDrvFolderPath"].ToString();
                Pc returnPc = new Pc(resultPcId,resultPcName, resultPcOneDrvPath);
                result.Content = returnPc;
            }
            return result;
        }

        /// <summary>
        /// Get current Pc's Id and Name
        /// </summary>
        /// <returns></returns>
        public Pc getCurrentPcInformation()
        {
            string thisPcId = SystemUtils.GetSystemUuid();
            string thisPcName = Environment.MachineName;
            Pc thisPc = new Pc(thisPcId, thisPcName);
            return thisPc;
        }
    }
}
