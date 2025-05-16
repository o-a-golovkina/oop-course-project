using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for BalanceWindow.xaml
    /// </summary>
    public partial class BalanceWindow : Window
    {
        public BalanceWindow()
        {
            InitializeComponent();
        }

        private void TextBox_SUM_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_SUM.Text = string.Empty;
        }

        private void TextBox_SUM_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_SUM.Text == string.Empty || TextBox_SUM.Text == " ")
                TextBox_SUM.Text = "Enter the amount";
        }
    }
}
