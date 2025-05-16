using EventPass.Models.Users;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            DownloadEvents();
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

        private void Button_Balance_Click(object sender, RoutedEventArgs e)
        {
            BalanceWindow modalWindow = new BalanceWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void Button_UserLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow modalWindow = new AccountWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void Button_Orders_Click(object sender, RoutedEventArgs e)
        {
            var currentActiveWindow = Application.Current.Windows
                .OfType<Window>()
                .SingleOrDefault(w => w.IsActive);

            var ordersWindow = new UserOrdersWindow();

            if (currentActiveWindow != null && currentActiveWindow.WindowState == WindowState.Maximized)
            {
                ordersWindow.WindowState = WindowState.Maximized;
            }

            ordersWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != ordersWindow)
                    window.Close();
            }
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            var currentActiveWindow = Application.Current.Windows
                .OfType<Window>()
                .SingleOrDefault(w => w.IsActive);

            var userWindow = new UserWindow();

            if (currentActiveWindow != null && currentActiveWindow.WindowState == WindowState.Maximized)
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
