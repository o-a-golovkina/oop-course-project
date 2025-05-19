using EventPass.Models;
using EventPass.Models.Users;
using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for dminOrdersWindow.xaml
    /// </summary>
    public partial class AdminOrdersWindow : Window
    {
        Admin admin = Admin.Instance;
        string searchQuery = "";

        public AdminOrdersWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            DownloadOrders();
        }

        private void Button_AdminExit_Click(object sender, RoutedEventArgs e)
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

        private void DownloadOrders()
        {
            var orders = GetOrders();
            if (UserRepository.Users.Count == 0 || orders.Count == 0)
            {
                Label_No.Visibility = Visibility.Visible;
                DataGrid_Orders.Visibility = Visibility.Hidden;
                return;
            }

            foreach (var item in orders)
                DataGrid_Orders.Items.Add(CreatingView(item));
            Label_No.Visibility = Visibility.Hidden;
            DataGrid_Orders.Visibility = Visibility.Visible;
        }

        private AdminOrderView CreatingView(Order order)
        {
            var view = new AdminOrderView
            {
                Id = order.Id.ToString(),
                EventName = order.OrderedEvent.Name! + " - " + order.OrderedEvent.Id,
                EventDate = order.OrderedEvent.DateAndTime.ToString(),
                Price = order.Price.ToString(),
                City = order.OrderedEvent.City!,
                Login = order.UserLogin,
            };
            return view;
        }

        private List<Order> GetOrders()
        {
            var orders = new List<Order>();
            foreach (var user in UserRepository.Users)
            {
                foreach (var order in user)
                    orders.Add(order);
            }
            return orders;
        }

        private void Button_AddEvent_Click(object sender, RoutedEventArgs e)
        {
            var currentMain = Application.Current.MainWindow;
            var main = new AdminCreateEventWindow();
            main.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != main)
                    window.Close();
            }
        }
    }
}
