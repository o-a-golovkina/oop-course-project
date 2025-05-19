using EventPass.Models.Users;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for RegistationWindow.xaml
    /// </summary>
    public partial class RegistationWindow : Window
    {
        RegisteredUser newUser = null!;

        public RegistationWindow()
        {
            InitializeComponent();
            Label_Exception.Visibility = Visibility.Hidden;
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
            if (TextBox_Name.Text == "Your full name")
                TextBox_Name.Text = string.Empty;
        }

        private void TextBox_Date_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == "Date of birth")
                TextBox_Date.Text = string.Empty;
        }

        private void TextBox_Number_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Number.Text == "Phone number")
                TextBox_Number.Text = "(+380)";
        }

        private void TextBox_Email_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Email.Text == "Email")
                TextBox_Email.Text = string.Empty;
        }

        private void TextBox_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text == "Create login")
                TextBox_Login.Text = string.Empty;
        }

        private void TextBox_Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Password.Text == "Password")
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
            Label_Exception.Visibility = Visibility.Hidden;
            if (TextBox_Name.Text == "Your full name" ||
                TextBox_Date.Text == "Date of birth" ||
                TextBox_Number.Text == "Phone number" ||
                TextBox_Email.Text == "Email" ||
                TextBox_Login.Text == "Create login" ||
                TextBox_Password.Text == "Password")
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "Please fill all fields";
                return;
            }
            string name = TextBox_Name.Text;
            if (!DateOnly.TryParse(TextBox_Date.Text, out DateOnly date))
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "Invalid date";
                return;
            }
            string phone = TextBox_Number.Text.Replace("(+380)", "");
            string email = TextBox_Email.Text;
            string login = TextBox_Login.Text;
            string password = TextBox_Password.Text;


            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password))
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "Please fill all fields";
                return;
            }

            try
            {
                newUser = new(name, date, phone, email, login, password);
                if (!UserRepository.AddUser(newUser))
                    throw new Exception("Login already exists");
                var currentMain = Application.Current.MainWindow;
                var userWindow = new UserWindow(newUser);
                userWindow.Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window != userWindow)
                        window.Close();
                }
            }
            catch (Exception ex)
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = ex.Message;
            }
        }

        private void TextBox_Number_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            bool isDigit = e.Text.All(char.IsDigit);

            bool willExceedLength = textBox!.Text.Length - textBox.SelectionLength + e.Text.Length > 15;

            e.Handled = !isDigit || willExceedLength;
        }

        private void TextBox_Date_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            bool isAllowed = e.Text.All(c => char.IsDigit(c) || c == '.' || c == '/');

            bool willExceedLength = textBox!.Text.Length - textBox.SelectionLength + e.Text.Length > 10;

            e.Handled = !isAllowed || willExceedLength;
        }

        private void TextBox_Name_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                TextBox_Date.Focus();
        }

        private void TextBox_Date_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                TextBox_Number.Focus();
        }

        private void TextBox_Number_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                TextBox_Email.Focus();
        }

        private void TextBox_Email_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                TextBox_Login.Focus();

        }

        private void TextBox_Login_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
                TextBox_Password.Focus();
        }

        private void TextBox_Password_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Register_Click(Button_Register, new RoutedEventArgs());
                Keyboard.ClearFocus();
            }
        }
    }
}
