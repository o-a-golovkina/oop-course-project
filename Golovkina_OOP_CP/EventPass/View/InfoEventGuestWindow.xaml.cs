using EventPass.Models.Events;
using EventPass.Models.Tickets;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for InfoEventGuestWindow.xaml
    /// </summary>
    ///
    public partial class InfoEventGuestWindow : Window
    {
        Event currentEvent;

        public InfoEventGuestWindow(Event currentEvent)
        {
            InitializeComponent();
            this.currentEvent = currentEvent;
            FillAllFields();
        }

        private void Button_LoginToBuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
            LoginWindow modalWindow = new LoginWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            modalWindow.ShowDialog();
        }

        private void FillAllFields()
        {
            Label_EventName.Content = currentEvent.Name!.ToUpper();
            ImageBrush_EventPic.ImageSource = new BitmapImage(new Uri(currentEvent.ImagePath!));
            Label_Date.Content += currentEvent.DateAndTime.ToString("dd.MM.yyyy");
            string time = currentEvent.DateAndTime.ToString("HH:mm");
            if (time == "00:00")
                Label_Time.Content += "all day";
            else
                Label_Time.Content += currentEvent.DateAndTime.ToString("HH:mm");
            Label_City.Content += currentEvent.City;
            Label_Price.Content += currentEvent.Tickets[0].GetPrice().ToString();
            Label_FreePlaces.Content += currentEvent.CountFreeTickets.ToString();
            Label_EventType.Content += currentEvent.EventType.ToString().Replace("Event", "");
            switch (currentEvent.EventType)
            {
                case EventType.ConcertEvent:
                    Label_Extra.Content = "Singer: " + currentEvent.Tickets
                        .OfType<ConcertTicket>()
                        .FirstOrDefault()?.Singer;
                    break;

                case EventType.TheaterEvent:
                    Label_Extra.Content = "The number of acts: " + currentEvent.Tickets
                        .OfType<TheaterTicket>()
                        .FirstOrDefault()?.NumberOfActs;
                    break;

                case EventType.StandUpEvent:
                    bool drinks = currentEvent.Tickets
                        .OfType<StandUpTicket>()
                        .FirstOrDefault()?.IsDrinkIncluded ?? false;
                    if (drinks)
                        Label_Extra.Content = "Drinks are included";
                    else
                        Label_Extra.Content = "Drinks are not included";
                    break;
            }
        }
    }
}
