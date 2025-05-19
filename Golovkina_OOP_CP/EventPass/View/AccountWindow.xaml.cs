using EventPass.Models.Users;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        RegisteredUser user;

        public AccountWindow(RegisteredUser user)
        {
            InitializeComponent();
            this.user = user;
            TextBox_Name.Text = user.FullName;
            TextBox_Date.Text = user.BirthDate.ToString();
            TextBox_Number.Text = user.PhoneNumber;
            TextBox_Email.Text = user.Email;
            Label_Exception.Visibility = Visibility.Hidden;
        }

        private void TextBox_Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Name.Text == string.Empty || TextBox_Name.Text == " ")
                TextBox_Name.Text = user.FullName;
        }

        private void TextBox_Date_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == string.Empty || TextBox_Date.Text == " ")
                TextBox_Date.Text = user.BirthDate.ToString();
        }

        private void TextBox_Number_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Number.Text == string.Empty || TextBox_Number.Text == "(+380)" || TextBox_Number.Text == "(+380) ")
                TextBox_Number.Text = user.PhoneNumber;
        }

        private void TextBox_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Email.Text == string.Empty || TextBox_Email.Text == " ")
                TextBox_Email.Text = user.Email;
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

        private void TextBox_Name_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Label_Exception.Visibility = Visibility.Hidden;
                    user.FullName = TextBox_Name.Text;
                }
                catch (Exception ex)
                {
                    Label_Exception.Visibility = Visibility.Visible;
                    Label_Exception.Content = ex.Message;
                }
            }
        }

        private void TextBox_Date_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Label_Exception.Visibility = Visibility.Hidden;
                    if (!DateOnly.TryParse(TextBox_Date.Text, out DateOnly date))
                        throw new Exception("Invalid date");
                    user.BirthDate = date;
                }
                catch (Exception ex)
                {
                    Label_Exception.Visibility = Visibility.Visible;
                    Label_Exception.Content = ex.Message;
                }
            }
        }

        private void TextBox_Number_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Label_Exception.Visibility = Visibility.Hidden;
                    user.PhoneNumber = TextBox_Number.Text.Replace("(+380)", "");
                }
                catch (Exception ex)
                {
                    Label_Exception.Visibility = Visibility.Visible;
                    Label_Exception.Content = ex.Message;
                }
            }
        }

        private void TextBox_Email_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Label_Exception.Visibility = Visibility.Hidden;
                    user.FullName = TextBox_Name.Text;
                }
                catch (Exception ex)
                {
                    Label_Exception.Visibility = Visibility.Visible;
                    Label_Exception.Content = ex.Message;
                }
            }
        }

        private void Button_DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete your account? This action is irreversible — all your data will be deleted",
                "Attention: confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                user.DeleteAccount();
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

        private void TextBox_Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            bool isAllowed = e.Text.All(c => char.IsDigit(c) || c == '.' || c == '/');

            bool willExceedLength = textBox!.Text.Length - textBox.SelectionLength + e.Text.Length > 10;

            e.Handled = !isAllowed || willExceedLength;
        }
    }
}
