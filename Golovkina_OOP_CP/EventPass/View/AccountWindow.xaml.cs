using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
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

        private void Button_LogOut_Click(object sender, RoutedEventArgs e)
        {
            var currentMain = Application.Current.MainWindow;
            var main = new MainWindow();
            main.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != main)
                    window.Close();
            }
        }
    }
}
