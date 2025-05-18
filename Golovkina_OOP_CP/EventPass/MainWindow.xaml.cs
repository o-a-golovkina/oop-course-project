using EventPass.Models.Events;
using EventPass.Models.Users;
using EventPass.View;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EventPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Event> createdEvents;
        EventType? selectedEventType = null;
        string selectedCity = "All cities";
        DateTime? selectedDate = null;
        string searchQuery = "";

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            createdEvents = Admin.Instance.CreatedEvents;
            DownloadEvents(createdEvents);
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
            if (TextBox_Search.Text == "Search event...")
                TextBox_Search.Text = string.Empty;
        }

        private void TextBox_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text == string.Empty || TextBox_Search.Text == " ")
                TextBox_Search.Text = "Search event...";
        }

        private void DownloadEvents(List<Event> Events)
        {
            if (Events.Count == 0)
                return;
            Label_NoEvents.Visibility = Visibility.Hidden;
            List<EventControl> Controls = HiddenControls();

            for (int i = 0; i < Events.Count; i++)
            {
                Controls[i].CurrentEvent = Events[i];
                Controls[i].Visibility = Visibility.Visible;
                Controls[i].Label_EventName.Content = Events[i].Name;
                Controls[i].Label_EventType.Content = Events[i].EventType.ToString().Replace("Event", "");
                Controls[i].Image_EventImage.Source = new BitmapImage(new Uri(Events[i].ImagePath!));
            }
        }

        private void EventControl_1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoEventGuestWindow modalWindow = new InfoEventGuestWindow(EventControl_1.CurrentEvent)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            modalWindow.ShowDialog();
        }

        private void EventControl_2_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoEventGuestWindow modalWindow = new InfoEventGuestWindow(EventControl_2.CurrentEvent)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            modalWindow.ShowDialog();
        }

        private void EventControl_3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoEventGuestWindow modalWindow = new InfoEventGuestWindow(EventControl_3.CurrentEvent)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            modalWindow.ShowDialog();
        }

        private void EventControl_4_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoEventGuestWindow modalWindow = new InfoEventGuestWindow(EventControl_4.CurrentEvent)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            modalWindow.ShowDialog();
        }

        private void EventControl_5_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoEventGuestWindow modalWindow = new InfoEventGuestWindow(EventControl_5.CurrentEvent)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            modalWindow.ShowDialog();
        }

        private void EventControl_6_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoEventGuestWindow modalWindow = new InfoEventGuestWindow(EventControl_6.CurrentEvent)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            modalWindow.ShowDialog();
        }

        private void Button_Concert_Click(object sender, RoutedEventArgs e)
        {
            selectedEventType = EventType.ConcertEvent;
            Label_Poster.Content = "Concert posters";
            ApplyFilters();
        }

        private void Button_Theater_Click(object sender, RoutedEventArgs e)
        {
            Label_Poster.Content = "Theater posters";
            selectedEventType = EventType.TheaterEvent;
            ApplyFilters();
        }

        private void Button_StandUp_Click(object sender, RoutedEventArgs e)
        {
            Label_Poster.Content = "StandUp posters";
            selectedEventType = EventType.StandUpEvent;
            ApplyFilters();
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            DownloadEvents(createdEvents);
            selectedEventType = null;
            selectedCity = "All cities";
            selectedDate = null;
            searchQuery = "";
            ComboBox_City.Text = "All cities";
            Calendar_MyCalendar.SelectedDate = null;
            TextBox_Search.Text = "Search event...";
            Label_Poster.Content = "Events posters";
        }

        private List<EventControl> HiddenControls()
        {
            List<EventControl> Controls = new List<EventControl>
            {
                EventControl_1, EventControl_2, EventControl_3, EventControl_4, EventControl_5, EventControl_6
            };

            for (int i = 0; i < 5; i++)
                Controls[i].Visibility = Visibility.Hidden;
            return Controls;
        }

        private void TextBox_Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            searchQuery = TextBox_Search.Text.Trim();
            ApplyFilters();
        }

        private void TextBox_Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                TextBox_Search.Text = "Search event...";
                Keyboard.ClearFocus();
            }
        }

        private void ApplyFilters()
        {
            if (createdEvents == null)
                return;

            var filtered = createdEvents.AsEnumerable();

            if (selectedEventType != null)
                filtered = filtered.Where(ev => ev.EventType == selectedEventType);

            if (!string.IsNullOrWhiteSpace(selectedCity) && selectedCity != "All cities")
                filtered = filtered.Where(ev => ev.City == selectedCity);

            if (selectedDate.HasValue)
                filtered = filtered.Where(ev => ev.DateAndTime.Date == selectedDate.Value);

            if (!string.IsNullOrWhiteSpace(searchQuery) && searchQuery != "Search event...")
                filtered = filtered.Where(ev => ev.Name!.ToLower().Contains(searchQuery.ToLower()));

            var list = filtered.ToList();

            if (list.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
            }
            else
            {
                Label_NoEvents.Visibility = Visibility.Hidden;
                DownloadEvents(list);
            }
        }

        private void ComboBox_City_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCity = ComboBox_City.Text;
            ApplyFilters();
        }

        private void Calendar_MyCalendar_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedDate = Calendar_MyCalendar.SelectedDate;
            ApplyFilters();
        }
    }
}