using EventPass.View;
using System.Windows;

namespace EventPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Account_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow modalWindow = new LoginWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
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
    }
}