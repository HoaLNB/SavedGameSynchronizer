using System.Windows;
using SavedGameSynchronizer.common;
using SavedGameSynchronizer.model;
using SavedGameSynchronizer.service;

namespace SavedGameSynchronizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentPage;
        private PcService pcService = new PcService();
        public MainWindow()
        {
            InitializeComponent();
            initMainPage();
            switchPageFirstTime();
        }

        /// <summary>
        /// Initialize various UI element when Main Page loads.
        /// </summary>
        private void initMainPage()
        {
            //TODO: clean up
        }

        private void Btn_MainDock_RegisterPC_Click(object sender, RoutedEventArgs e)
        {
            switchToPage(Constant.SWITCH_MAINFORM_PC);
        }
        private void BtnMainNavGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Switch to game page");
            switchToPage(Constant.SWITCH_MAINFORM_GAME);
        }

        private void switchToPage(string destPage)
        {
            switch (destPage)
            {
                case Constant.SWITCH_MAINFORM_PC:
                    switchToPcPage();
                    break;
                case Constant.SWITCH_MAINFORM_GAME:
                    //TODO: remove later. START
                    switchToPcPage();
                    //TODO: remove later. END

                    switchToGamePage();
                    break;
            }
        }

        private void switchToPcPage()
        {
            RegisterPc pageToShow = new RegisterPc();
            FrameMain.Navigate(pageToShow);
            LabelMainTitle.Content = pageToShow.PageTitle;
        }

        private void switchToGamePage()
        {
            
        }

        /// <summary>
        /// Determine which page to show when the application starts.
        /// </summary>
        private void switchPageFirstTime()
        {
            switchToPage(!pcService.doesThisPcExist() ? Constant.SWITCH_MAINFORM_PC : Constant.SWITCH_MAINFORM_GAME);
        }
    }
}
