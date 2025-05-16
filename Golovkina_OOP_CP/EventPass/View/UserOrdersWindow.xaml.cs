using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for UserOrdersWindow.xaml
    /// </summary>
    public partial class UserOrdersWindow : Window
    {
        public UserOrdersWindow()
        {
            InitializeComponent();
        }

        private void TextBox_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Search.Text = string.Empty;
        }

        private void TextBox_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text == string.Empty || TextBox_Search.Text == " ")
                TextBox_Search.Text = "Search event...";
        }

        private void Button_Balance_Click(object sender, RoutedEventArgs e)
        {
            BalanceWindow modalWindow = new BalanceWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void Button_UserLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow modalWindow = new AccountWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            var currentActiveWindow = Application.Current.Windows
                .OfType<Window>()
                .SingleOrDefault(w => w.IsActive);

            var userWindow = new UserWindow();

            if (currentActiveWindow != null && currentActiveWindow.WindowState == WindowState.Maximized)
            {
                userWindow.WindowState = WindowState.Maximized;
            }

            userWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != userWindow)
                    window.Close();
            }
        }
    }
}
