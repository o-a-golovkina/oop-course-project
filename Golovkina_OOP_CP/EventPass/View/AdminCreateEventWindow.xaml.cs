using EventPass.Models.Events;
using System.Windows;

namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for AdminCreateEventWindow.xaml
    /// </summary>
    public partial class AdminCreateEventWindow : Window
    {
        string? imagePath;

        public AdminCreateEventWindow()
        {
            InitializeComponent();
        }

        private void TextBox_EventName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_EventName.Text = string.Empty;
        }

        private void TextBox_Date_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Date.Text = string.Empty;
        }

        private void TextBox_Price_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Price.Text = string.Empty;
        }

        private void TextBox_NumTickets_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_NumTickets.Text = string.Empty;
        }

        private void TextBox_EventName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_EventName.Text == string.Empty || TextBox_EventName.Text == " ")
                TextBox_EventName.Text = "Event name";
        }

        private void TextBox_Date_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == string.Empty || TextBox_Date.Text == " ")
                TextBox_Date.Text = "Date";
        }

        private void TextBox_Price_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Price.Text == string.Empty || TextBox_Price.Text == " ")
                TextBox_Price.Text = "Price";
        }

        private void TextBox_NumTickets_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_NumTickets.Text == string.Empty || TextBox_NumTickets.Text == " ")
                TextBox_NumTickets.Text = "Count of tickets";
        }

        private void Button_CreateEvent_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_EventName.Text == "Event name" || TextBox_Date.Text == "Date" || TextBox_Price.Text == "Price" || TextBox_NumTickets.Text == "Count of tickets")
            {
                Label_Exception.Content = "Please fill in all fields";
                Label_Exception.Visibility = Visibility.Visible;
            }
            else
            {
                Label_Exception.Visibility = Visibility.Hidden;
                try
                {
                    string? name = TextBox_EventName.Text;
                    DateTime dateAndTime = DateTime.Parse(TextBox_Date.Text);
                    decimal price = decimal.Parse(TextBox_Price.Text);
                    string? city = ComboBox_City.Text;
                    int countFreeTickets = int.Parse(TextBox_NumTickets.Text);
                    EventType eventType = (EventType)Enum.Parse(typeof(EventType), ComboBox_EventType.Text);

                    //string? singer = null, bool includeDrink = false, short numberOfActs = 1
                }
            }

        }
    }
}
