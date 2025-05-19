using EventPass.Models;
using EventPass.Models.Users;
using System.Windows;
using System.Windows.Input;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for UserOrdersWindow.xaml
    /// </summary>
    public partial class UserOrdersWindow : Window
    {
        string searchQuery = "";
        RegisteredUser currentUser;
        List<Order> userOrders;
        List<UserOrderView> downloadOrders = new();

        public UserOrdersWindow(RegisteredUser currentUser)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.currentUser = currentUser;
            userOrders = currentUser.Orders;
            Label_YourOrders.Content = "Your orders";
            DownloadOrders();
        }

        private void DownloadOrders()
        {
            if (currentUser.Orders.Count == 0)
            {
                Label_No.Visibility = Visibility.Visible;
                DataGrid_Orders.Visibility = Visibility.Hidden;
                return;
            }

            foreach (Order order in userOrders)
                DataGrid_Orders.Items.Add(CreatingView(order));

            Label_No.Visibility = Visibility.Hidden;
            DataGrid_Orders.Visibility = Visibility.Visible;
        }

        private UserOrderView CreatingView(Order order)
        {
            var view = new UserOrderView
            {
                Id = order.Id.ToString(),
                EventName = order.OrderedEvent.Name! + " - " + order.OrderedEvent.Id,
                EventDate = order.OrderedEvent.DateAndTime.ToString(),
                Price = order.Price.ToString(),
                City = order.OrderedEvent.City!
            };
            downloadOrders.Add(view);
            return view;
        }

        private void TextBox_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text == "Search event...")
                TextBox_Search.Text = string.Empty;
        }

        private void TextBox_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text == string.Empty || TextBox_Search.Text == " ")
                TextBox_Search.Text = "Search event...";
            Label_YourOrders.Content = "Your orders";
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            var currentMain = Application.Current.MainWindow;
            var userWindow = new UserWindow(currentUser);
            userWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != userWindow)
                    window.Close();
            }
            return;
        }

        private void TextBox_Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (downloadOrders.Count == 0)
                return;
            searchQuery = TextBox_Search.Text.Trim();
            Label_YourOrders.Content = $"Your orders with event name \"{searchQuery}\"";
            string query = TextBox_Search.Text.Trim().ToLower();

            var filtered = downloadOrders.Where(o =>
                o.EventName.ToLower().Contains(query) ||
                o.City.ToLower().Contains(query) ||
                o.Price.Contains(query) ||
                o.EventDate.Contains(query)
            ).ToList();

            DataGrid_Orders.ItemsSource = filtered;
        }

        private void TextBox_Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                TextBox_Search.Text = "Search event...";
                Label_YourOrders.Content = "Your orders";
                Keyboard.ClearFocus();
                DownloadOrders();
            }
        }

        private void Button_Balance_Click(object sender, RoutedEventArgs e)
        {
            BalanceWindow modalWindow = new BalanceWindow(currentUser)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void Button_UserLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow modalWindow = new AccountWindow(currentUser)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }
    }
}
