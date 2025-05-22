using EventPass.Models.Events;
using EventPass.Models.Tickets;
using EventPass.Models.Users;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for InfoEventUserWindow.xaml
    /// </summary>
    public partial class InfoEventUserWindow : Window
    {
        Event currentEvent;
        RegisteredUser currentUser;

        public InfoEventUserWindow(Event currentEvent, RegisteredUser currentUser)
        {
            InitializeComponent();
            this.currentEvent = currentEvent;
            FillAllFields();
            this.currentUser = currentUser;
            if (currentEvent.CountFreeTickets == 0)
            {
                Button_Buy.IsEnabled = false;
                Button_Buy.Content = "Sold out";
                Button_Buy.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A6A6A6"));
                Button_Buy.Cursor = Cursors.Arrow;
            }
            else
                Button_Buy.Content = "Buy";
        }

        private void Button_Buy_Click(object sender, RoutedEventArgs e)
        {
            if (!currentUser.MakeOrderAndBuy(currentEvent, currentEvent.First(), out int id))
            {
                MessageBox.Show("Not enough money in the balance", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Button_Buy.IsEnabled = false;
            Button_Buy.Content = "Bought";
            Button_Buy.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A6A6A6"));
            Button_Buy.Cursor = Cursors.Arrow;
            Label_FreePlaces.Content = $"Free: {currentEvent.CountFreeTickets.ToString()}";
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
