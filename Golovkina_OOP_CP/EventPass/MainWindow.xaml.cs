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
            var concerts = createdEvents.Where(c => c.EventType == EventType.ConcertEvent).ToList();
            if (concerts.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            Label_Poster.Content = "Consert posters";
            DownloadEvents(concerts);
        }

        private void Button_Theater_Click(object sender, RoutedEventArgs e)
        {
            var theaters = createdEvents.Where(c => c.EventType == EventType.TheaterEvent).ToList();
            if (theaters.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            Label_Poster.Content = "Theater posters";
            DownloadEvents(theaters);
        }

        private void Button_StandUp_Click(object sender, RoutedEventArgs e)
        {
            var standUps = createdEvents.Where(c => c.EventType == EventType.StandUpEvent).ToList();
            if (standUps.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            Label_Poster.Content = "StandUp posters";
            DownloadEvents(standUps);
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            DownloadEvents(createdEvents);
            Label_Poster.Content = "Event posters";
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

        private void ComboBox_City_GotFocus(object sender, RoutedEventArgs e)
        {
            switch (ComboBox_City.Text.ToString())
            {
                case "All cities":
                    DownloadEvents(createdEvents);
                    break;

                case "Kharkiv":
                    KharkivEvents();
                    break;

                case "Odesa":
                    OdesaEvents();
                    break;

                case "Dnipro":
                    DniproEvents();
                    break;

                case "Kyiv":
                    KyivEvents();
                    break;
            }
        }

        private void KharkivEvents()
        {
            var ev = createdEvents.Where(c => c.City == "Kharkiv").ToList();
            if (ev.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            DownloadEvents(ev);
        }

        private void OdesaEvents()
        {
            var ev = createdEvents.Where(c => c.City == "Odesa").ToList();
            if (ev.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            DownloadEvents(ev);
        }

        private void DniproEvents()
        {
            var ev = createdEvents.Where(c => c.City == "Dnipro").ToList();
            if (ev.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            DownloadEvents(ev);
        }

        private void KyivEvents()
        {
            var ev = createdEvents.Where(c => c.City == "Kyiv").ToList();
            if (ev.Count == 0)
            {
                Label_NoEvents.Visibility = Visibility.Visible;
                HiddenControls();
                return;
            }

            Label_NoEvents.Visibility = Visibility.Hidden;
            DownloadEvents(ev);
        }

        private void Calendar_MyCalendar_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Calendar_MyCalendar.SelectedDate is DateTime date)
            {
                var ev = createdEvents.Where(c => c.DateAndTime.Date == date).ToList();
                if (ev.Count == 0)
                {
                    Label_NoEvents.Visibility = Visibility.Visible;
                    HiddenControls();
                    return;
                }

                Label_NoEvents.Visibility = Visibility.Hidden;
                DownloadEvents(ev);
            }
        }

        private void TextBox_Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string query = TextBox_Search.Text.Trim().ToLower();
            List<Event> filteredEvents = null!;
            if (query != "Search event..." && createdEvents != null)
            {
                filteredEvents = createdEvents.Where(ev => ev.Name!.ToLower().Contains(query)).ToList();
                if (filteredEvents.Count == 0)
                {
                    Label_NoEvents.Visibility = Visibility.Visible;
                    HiddenControls();
                    return;
                }
                DownloadEvents(filteredEvents);
            }
            else
                return;
        }

        private void TextBox_Search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                TextBox_Search.Text = "Search event...";
                Keyboard.ClearFocus();
            }
        }
    }
}