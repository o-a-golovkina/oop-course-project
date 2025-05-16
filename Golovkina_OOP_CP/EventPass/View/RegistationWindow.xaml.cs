using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for RegistationWindow.xaml
    /// </summary>
    public partial class RegistationWindow : Window
    {
        public RegistationWindow()
        {
            InitializeComponent();
        }

        private void Button_HaveAccount_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LoginWindow modalWindow = new LoginWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void TextBox_Name_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Name.Text = string.Empty;
        }

        private void TextBox_Date_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Date.Text = string.Empty;
        }

        private void TextBox_Number_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Number.Text = "(+380)";
        }

        private void TextBox_Email_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Email.Text = string.Empty;
        }

        private void TextBox_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Login.Text = string.Empty;
        }

        private void TextBox_Password_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Password.Text = string.Empty;
        }

        private void TextBox_Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Name.Text == string.Empty || TextBox_Name.Text == " ")
                TextBox_Name.Text = "Your full name";
        }

        private void TextBox_Date_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == string.Empty || TextBox_Date.Text == " ")
                TextBox_Date.Text = "Date of birth";
        }

        private void TextBox_Number_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Number.Text == string.Empty || TextBox_Number.Text == "(+380)" || TextBox_Number.Text == "(+380) ")
                TextBox_Number.Text = "Phone number";
        }

        private void TextBox_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Email.Text == string.Empty || TextBox_Email.Text == " ")
                TextBox_Email.Text = "Email";
        }

        private void TextBox_Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text == string.Empty || TextBox_Login.Text == " ")
                TextBox_Login.Text = "Create login";

        }

        private void TextBox_Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Password.Text == string.Empty || TextBox_Password.Text == " ")
                TextBox_Password.Text = "Password";
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            var currentMain = Application.Current.MainWindow;
            var adminWindow = new AdminCreateEventWindow();

            if (currentMain != null && currentMain.WindowState == WindowState.Maximized)
            {
                adminWindow.WindowState = WindowState.Maximized;
            }
            adminWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != adminWindow)
                    window.Close();
            }
        }
    }
}
