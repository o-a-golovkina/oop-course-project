using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for InfoEventGuestWindow.xaml
    /// </summary>
    public partial class InfoEventGuestWindow : Window
    {
        public InfoEventGuestWindow()
        {
            InitializeComponent();
        }

        private void Button_LoginToBuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LoginWindow modalWindow = new LoginWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }
    }
}
