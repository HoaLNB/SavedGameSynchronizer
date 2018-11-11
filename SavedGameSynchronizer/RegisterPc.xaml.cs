using System;
using System.IO;
using System.Windows.Controls;
using SavedGameSynchronizer.common;
using SavedGameSynchronizer.model;
using SavedGameSynchronizer.service;

namespace SavedGameSynchronizer
{
    /// <summary>
    /// Interaction logic for RegisterPC.xaml
    /// </summary>
    public partial class RegisterPc : Page
    {
        public string PageTitle { get; set; }
        PcService pcService = new PcService();
        public string RegisterUpdateFormMode = Constant.MODE_PCFORM_REGISTER;
        
        public RegisterPc()
        {
            InitializeComponent();
            InitPageData();
        }

        public void InitPageData()
        {
            ReturnResult getPcInfoResult = pcService.getPcById(new Pc().Id);
            switch (getPcInfoResult.Code)
            {
                case PcService.RC_GET_PC_NOT_EXIST:
                    RegisterUpdateFormMode = Constant.MODE_PCFORM_REGISTER;
                    PageTitle = Properties.Resources.txt_Title_Page_RegPc;
                    Btn_RegPC_RegisterPc.Content = Properties.Resources.lbl_Btn_RegPC_RegButton_Reg;

                    fillFormWithPcInfo(pcService.getCurrentPcInformation());
                    break;
                case PcService.RC_GET_PC_OK:
                    RegisterUpdateFormMode = Constant.MODE_PCFORM_UPDATE;
                    PageTitle = Properties.Resources.txt_Title_Page_UpdatePc;
                    Btn_RegPC_RegisterPc.Content = Properties.Resources.lbl_Btn_RegPC_RegButton_Update;

                    fillFormWithPcInfo((Pc)getPcInfoResult.Content);
                    break;
            }
        }

        /// <summary>
        /// Handle Register/Update button's click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RegPC_RegisterPc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!pcService.doesThisPcExist())
            {
                executeRegisterPc();
            }
            else
            {
                executeUpdatePcInfo();
            }
        }
        /// <summary>
        /// Register this Pc information to database. 
        /// Used in register Pc mode only.
        /// </summary>
        private void executeRegisterPc()
        {
            Pc newPc = new Pc(TbPcName.Text, TbOneDrvPath.Text);
            pcService.RegisterPc(newPc);
        }
        /// <summary>
        /// Update pc information to database. 
        /// Used in update Pc mode only.
        /// </summary>
        private void executeUpdatePcInfo()
        {

        }

        /// <summary>
        /// Fill register/update form with input Pc object's information
        /// </summary>
        /// <param name="pc"></param>
        private void fillFormWithPcInfo(Pc pc)
        {
            TbPcName.Text = pc.PcName;
            TbOneDrvPath.Text = pc.OneDrvFolderPath;
        }
    }
}
