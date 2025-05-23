using EventPass.Models;
using EventPass.Models.Events;
using EventPass.Models.Users;
using Microsoft.Win32;
using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for AminRemoveEventWindow.xaml
    /// </summary>
    public partial class AminRemoveEventWindow : Window
    {
        public AminRemoveEventWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            DownloadEvents();
        }

        private void DownloadEvents()
        {
            var events = Admin.Instance.CreatedEvents;
            if (events.Count == 0)
            {
                Label_No.Visibility = Visibility.Visible;
                DataGrid_Events.Visibility = Visibility.Hidden;
                return;
            }

            foreach (var item in events)
                DataGrid_Events.Items.Add(CreatingView(item));
            Label_No.Visibility = Visibility.Hidden;
            DataGrid_Events.Visibility = Visibility.Visible;
        }

        private AdminEventView CreatingView(Event e)
        {
            var view = new AdminEventView
            {
                Id = e.Id.ToString(),
                Type = e.EventType.ToString().Replace("Event", ""),
                EventName = e.Name!,
                EventDate = e.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                Price = e.Tickets.First().Price.ToString(),
                City = e.City!,
                Free = e.CountFreeTickets.ToString(),
            };
            return view;
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

        private void Button_Orders_Click(object sender, RoutedEventArgs e)
        {
            var currentMain = Application.Current.MainWindow;
            var main = new AdminOrdersWindow();
            main.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != main)
                    window.Close();
            }
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

        private void DataGrid_Events_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DataGrid_Events.SelectedItem is AdminEventView selectedView)
            {
                if (selectedView.Free != "0")
                {
                    MessageBox.Show("You cannot delete the event because the tickets haven't been sold out", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int eventId = int.Parse(selectedView.Id);
                Admin.Instance.DeleteEvent(eventId);
            }
        }

        private void Button_LoadUsers_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    UserRepository.LoadFromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading users", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_SaveUsers_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FileName = "users.json"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    UserRepository.SaveToFile(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error saving users", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
