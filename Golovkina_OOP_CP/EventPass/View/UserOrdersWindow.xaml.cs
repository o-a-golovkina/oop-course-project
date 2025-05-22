using EventPass.Models;
using EventPass.Models.Users;
using System.Windows;

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
                EventDate = order.OrderedEvent.DateAndTime.ToString("dd/MM/yyyy hh:mm"),
                Price = order.Price.ToString(),
                City = order.OrderedEvent.City!
            };
            downloadOrders.Add(view);
            return view;
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
