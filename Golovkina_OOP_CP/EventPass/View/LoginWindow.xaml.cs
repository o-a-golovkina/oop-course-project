using EventPass.Models.Users;
using System.Windows;
using System.Windows.Input;

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
            Label_Exception.Visibility = Visibility.Hidden;
        }

        private void TextBox_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text == "Login")
                TextBox_Login.Text = string.Empty;
        }

        private void TextBox_Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text == string.Empty || TextBox_Login.Text == " ")
                TextBox_Login.Text = "Login";
        }

        private void Button_NotHaveAccount_Click(object sender, RoutedEventArgs e)
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
            Window currentMain;
            string login = TextBox_Login.Text;
            string password = PasswordBox_Password.Password;
            Label_Exception.Visibility = Visibility.Hidden;

            if (login == "Login" || string.IsNullOrEmpty(password))
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "Please fill all fields";
                return;
            }

            if (!RegisteredUser.SignIn(login, password, out RegisteredUser user))
            {
                if (Admin.Instance.IsAuthenticated(login, password))
                {
                    currentMain = Application.Current.MainWindow;
                    var adminWindow = new AdminCreateEventWindow();
                    adminWindow.Show();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window != adminWindow)
                            window.Close();
                    }
                    return;
                }
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "User not found";
                return;
            }

            currentMain = Application.Current.MainWindow;
            var userWindow = new UserWindow(user);
            userWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != userWindow)
                    window.Close();
            }
            return;
        }

        private void PasswordBox_Password_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Password.Text = "Password";
            TextBox_Password.Text = string.Empty;
        }

        private void PasswordBox_Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox_Password.Password == string.Empty || PasswordBox_Password.Password == " ")
                TextBox_Password.Text = "Password";
        }

        private void TextBox_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                PasswordBox_Password.Focus();
        }

        private void PasswordBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Button_Login_Click(Button_Login, new RoutedEventArgs());
        }
    }
}
