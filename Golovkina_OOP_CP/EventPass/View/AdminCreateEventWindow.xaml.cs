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

        public AdminCreateEventWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Image_EmptyImage.Visibility = Visibility.Visible;
            Rectangle_Gray.Visibility = Visibility.Visible;
            Image_Event.Source = null;
        }

        private void TextBox_EventName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_EventName.Text == "Event name")
                TextBox_EventName.Text = string.Empty;
        }

        private void TextBox_Date_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date.Text == "Date")
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

        private void TextBox_Singer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBox_Singer.Text == string.Empty || TextBox_Singer.Text == " ")
                TextBox_Singer.Text = "Singer";
        }

        private void Button_CreateEvent_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_EventName.Text == "Event name" || TextBox_Date.Text == "Date" || TextBox_Price.Text == "Price" || TextBox_NumTickets.Text == "Count of tickets")
            {
                Label_Exception.Content = "Please fill in all fields";
                Label_Exception.Visibility = Visibility.Visible;
            }
            else if (imagePath == null)
            {
                Label_Exception.Content = "Please choose an image";
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
                    EventType eventType = (EventType)Enum.Parse(typeof(EventType), ComboBox_EventType.Text + "Event");
                    string? singer = TextBox_Singer.Text;
                    if (singer == "No")
                        singer = null;
                    short numberOfActs = short.Parse(ComboBox_Acts.Text);
                    bool includeDrink = ComboBox_Drinks.Text == "Yes";
                    string mes;
                    Admin.Instance.CreateEvent(name, dateAndTime, price, city, imagePath, countFreeTickets, eventType, out mes, singer, includeDrink, numberOfActs);
                    if (mes != null)
                        throw new Exception(mes);
                }
                catch (Exception ex)
                {
                    Label_Exception.Content = ex.Message;
                    Label_Exception.Visibility = Visibility.Visible;
                }
                FormReset();
                MessageBox.Show("The event was created!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
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
            TextBox_Date.Text = "Date";
            TextBox_Price.Text = "Price";
            TextBox_NumTickets.Text = "Count of tickets";
            TextBox_Singer.Text = "Singer";
            Image_EmptyImage.Visibility = Visibility.Visible;
            Rectangle_Gray.Visibility = Visibility.Visible;
            Image_Event.Source = null;
            Label_Exception.Visibility = Visibility.Hidden;
            ComboBox_EventType.Text = "Concert";
            ComboBox_City.Text = "kharkiv";
            ComboBox_Acts.Text = "1";
            ComboBox_Drinks.Text = "No";
        }
    }
}
