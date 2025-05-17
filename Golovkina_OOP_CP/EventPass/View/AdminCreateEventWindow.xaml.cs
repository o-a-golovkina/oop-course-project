using EventPass.Models.Events;
using EventPass.Models.Users;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace EventPass.View
{
    /// <summary>
    /// Interaction logic for AdminCreateEventWindow.xaml
    /// </summary>
    public partial class AdminCreateEventWindow : Window
    {
        string? imagePath;
        string? singer = null;
        short numberOfActs = 1;
        bool includeDrink = false;

        public AdminCreateEventWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Image_EmptyImage.Visibility = Visibility.Visible;
            Rectangle_Gray.Visibility = Visibility.Visible;
            Image_Event.Source = null;
            TextBox_Singer.IsEnabled = true;
            ComboBox_Acts.IsEnabled = false;
            ComboBox_Drinks.IsEnabled = false;
        }

        private void TextBox_EventName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_EventName.Text == "Event name")
                TextBox_EventName.Text = string.Empty;
        }

        private void TextBox_Date_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == "Date and time")
                TextBox_Date.Text = string.Empty;
        }

        private void TextBox_Price_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Price.Text == "Price")
                TextBox_Price.Text = string.Empty;
        }

        private void TextBox_NumTickets_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_NumTickets.Text == "Count of tickets")
                TextBox_NumTickets.Text = string.Empty;
        }

        private void TextBox_Singer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Singer.Text == "Singer")
                TextBox_Singer.Text = string.Empty;
        }

        private void TextBox_EventName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_EventName.Text == string.Empty || TextBox_EventName.Text == " ")
                TextBox_EventName.Text = "Event name";
        }

        private void TextBox_Date_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == string.Empty || TextBox_Date.Text == " ")
                TextBox_Date.Text = "Date and time";
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

        private void TextBox_Singer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Singer.Text == string.Empty || TextBox_Singer.Text == " ")
                TextBox_Singer.Text = "Singer";
        }

        private void Button_CreateEvent_Click(object sender, RoutedEventArgs e)
        {
            Label_Exception.Visibility = Visibility.Hidden;

            if (TextBox_EventName.Text == "Event name"
                || TextBox_Date.Text == "Date and time"
                || TextBox_Price.Text == "Price"
                || TextBox_NumTickets.Text == "Count of tickets")
            {
                Label_Exception.Content = "Please fill in all fields";
                Label_Exception.Visibility = Visibility.Visible;
                return;
            }
            if (imagePath == null)
            {
                Label_Exception.Content = "Please choose an image";
                Label_Exception.Visibility = Visibility.Visible;
                return;
            }

            try
            {
                string? name = TextBox_EventName.Text;
                string? city = ComboBox_City.Text.ToString();

                if (!DateTime.TryParse(TextBox_Date.Text, out var dateAndTime))
                    throw new FormatException("Incorrect format of date and time");

                if (!decimal.TryParse(TextBox_Price.Text, out var price))
                    throw new FormatException("Incorrect format of price");

                if (!int.TryParse(TextBox_NumTickets.Text, out var countFreeTickets))
                    throw new FormatException("Incorrect format of ticket count");

                Enum.TryParse<EventType>(ComboBox_EventType.Text + "Event", out var eventType);
                numberOfActs = short.Parse(ComboBox_Acts.Text);
                includeDrink = ComboBox_Drinks.Text == "Yes";

                string? singer = !string.IsNullOrWhiteSpace(TextBox_Singer.Text) && TextBox_Singer.Text != "Singer"
                    ? TextBox_Singer.Text
                    : null;

                bool create = Admin.Instance.CreateEvent(name, dateAndTime, price, city, imagePath, countFreeTickets, eventType, out string mes, singer, includeDrink, numberOfActs);
                if (!string.IsNullOrEmpty(mes) || create != true)
                    throw new Exception(mes);

                MessageBox.Show("The event was created!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                FormReset();
            }
            catch (Exception ex)
            {
                Label_Exception.Content = ex.Message;
                Label_Exception.Visibility = Visibility.Visible;
            }
        }


        private void Button_PlaceImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Choose image",
                Filter = "Image (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                Multiselect = false
            };

            if (dialog.ShowDialog() == true)
            {
                imagePath = dialog.FileName;

                Image_Event.Source = new BitmapImage(new Uri(imagePath));
                Image_EmptyImage.Visibility = Visibility.Hidden;
                Rectangle_Gray.Visibility = Visibility.Hidden;
            }
        }

        private void TextBox_NumTickets_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            bool isDigit = e.Text.All(char.IsDigit);

            bool willExceedLength = textBox!.Text.Length - textBox.SelectionLength + e.Text.Length > 6;

            e.Handled = !isDigit || willExceedLength;
        }

        private void TextBox_Price_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            string newText = GetTextAfterInput(textBox!, e.Text);

            bool isValidChars = newText.All(c => char.IsDigit(c) || c == ',');
            bool onlyOneComma = newText.Count(c => c == ',') <= 1;
            bool notTooLong = newText.Length <= 7;

            e.Handled = !(isValidChars && onlyOneComma && notTooLong);
        }

        private string GetTextAfterInput(TextBox textBox, string input)
        {
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;

            string oldText = textBox.Text;
            string newText = oldText.Remove(selectionStart, selectionLength)
                                    .Insert(selectionStart, input);
            return newText;
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

        private void FormReset()
        {
            TextBox_EventName.Text = "Event name";
            TextBox_Date.Text = "Date and time";
            TextBox_Price.Text = "Price";
            TextBox_NumTickets.Text = "Count of tickets";
            TextBox_Singer.Text = "Singer";
            Image_EmptyImage.Visibility = Visibility.Visible;
            Rectangle_Gray.Visibility = Visibility.Visible;
            Label_Exception.Visibility = Visibility.Hidden;
            Image_Event.Source = null;
            ComboBox_EventType.Text = "Concert";
            ComboBox_City.Text = "Kharkiv";
            ComboBox_Acts.Text = "1";
            ComboBox_Drinks.Text = "No";
            TextBox_Singer.IsEnabled = true;
            ComboBox_Acts.IsEnabled = false;
            ComboBox_Drinks.IsEnabled = false;
        }

        private void ComboBox_EventType_GotFocus(object sender, RoutedEventArgs e)
        {
            switch (ComboBox_EventType.Text)
            {
                case "Concert":
                    TextBox_Singer.IsEnabled = true;
                    ComboBox_Acts.IsEnabled = false;
                    ComboBox_Drinks.IsEnabled = false;
                    break;

                case "Theater":
                    TextBox_Singer.IsEnabled = false;
                    ComboBox_Acts.IsEnabled = true;
                    ComboBox_Drinks.IsEnabled = false;
                    break;

                case "StandUp":
                    TextBox_Singer.IsEnabled = false;
                    ComboBox_Acts.IsEnabled = false;
                    ComboBox_Drinks.IsEnabled = true;
                    break;
            }
        }
    }
}
