using EventPass.Models.Users;
using EventPass.View;
using System.Windows;
using System.Windows.Media.Imaging;

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
            WindowState = WindowState.Maximized;
            DownloadEvents();
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

        private void DownloadEvents()
        {
            var CreatedEvents = Admin.Instance.CreatedEvents;
            if (CreatedEvents.Count == 0)
                return;
            Label_NoEvents.Visibility = Visibility.Hidden;
            List<EventControl> Controls = new List<EventControl>
            {
                EventControl_1, EventControl_2, EventControl_3, EventControl_4, EventControl_5, EventControl_6
            };

            for (int i = 0; i < CreatedEvents.Count; i++)
            {
                Controls[i].Visibility = Visibility.Visible;
                Controls[i].Label_EventName.Content = CreatedEvents[i].Name;
                Controls[i].Image_EventImage.Source = new BitmapImage(new Uri(CreatedEvents[i].ImagePath!));
            }
        }
    }
}