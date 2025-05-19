using EventPass.Models.Users;
using System.Windows;
using System.Windows.Controls;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for BalanceWindow.xaml
    /// </summary>
    public partial class BalanceWindow : Window
    {
        RegisteredUser user;

        public BalanceWindow(RegisteredUser user)
        {
            InitializeComponent();
            this.user = user;
            Label_SUM.Content = user.Balance.ToString();
            Label_Exception.Visibility = Visibility.Hidden;
        }

        private void TextBox_SUM_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_SUM.Text == "Enter the amount")
                TextBox_SUM.Text = string.Empty;
        }

        private void TextBox_SUM_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_SUM.Text == string.Empty || TextBox_SUM.Text == " ")
                TextBox_SUM.Text = "Enter the amount";
        }

        private void Button_PutMoney_Click(object sender, RoutedEventArgs e)
        {
            Label_Exception.Visibility = Visibility.Hidden;
            bool result = decimal.TryParse(TextBox_SUM.Text, out var sum);
            if (!result || !user.PutMoney(sum))
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "Operation is impossible";
                return;
            }
            TextBox_SUM.Text = "Enter the amount";
            Label_SUM.Content = user.Balance.ToString();
        }

        private void Button_WithdrawMoney_Click(object sender, RoutedEventArgs e)
        {
            Label_Exception.Visibility = Visibility.Hidden;
            bool result = decimal.TryParse(TextBox_SUM.Text, out var sum);
            if (!result || !user.WithdrawMoney(sum))
            {
                Label_Exception.Visibility = Visibility.Visible;
                Label_Exception.Content = "Operation is impossible";
                return;
            }
            TextBox_SUM.Text = "Enter the amount";
            Label_SUM.Content = user.Balance.ToString();
        }

        private void TextBox_SUM_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            bool isDigit = e.Text.All(char.IsDigit);

            bool willExceedLength = textBox!.Text.Length - textBox.SelectionLength + e.Text.Length > 5;

            e.Handled = !isDigit || willExceedLength;
        }
    }
}
