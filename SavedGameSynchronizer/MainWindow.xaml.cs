using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_MainDock_RegisterPC_Click(object sender, RoutedEventArgs e)
        {
            RegisterPc pageToShow = new RegisterPc();
            FrameMain.Navigate(pageToShow);
            LabelMainTitle.Content = pageToShow.PageTitle;
        }

        private void switchToPage(string destPage)
        {
            
        }
    }
}
