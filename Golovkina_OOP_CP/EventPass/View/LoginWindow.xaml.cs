using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Login.Text = string.Empty;
        }

        private void TextBox_Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text == string.Empty || TextBox_Login.Text == " ")
                TextBox_Login.Text = "Login";
        }

        private void Button_HaveAccount_Click(object sender, RoutedEventArgs e)
        {
            Close();
            RegistationWindow modalWindow = new RegistationWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            var currentMain = Application.Current.MainWindow;
            var userWindow = new UserWindow();

            if (currentMain != null && currentMain.WindowState == WindowState.Maximized)
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

        private void PasswordBox_Password_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Password.Text = string.Empty;
        }

        private void PasswordBox_Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox_Password.Password == string.Empty || PasswordBox_Password.Password == " ")
                TextBox_Password.Text = "Password";
        }
    }
}
