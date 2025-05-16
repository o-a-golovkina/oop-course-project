using EventPass.View;
using System.Windows;
using System.Windows.Controls;

namespace EventPass
{
    /// <summary>
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        public EventControl()
        {
            InitializeComponent();
        }

        private void Button_View_Click(object sender, RoutedEventArgs e)
        {
            Window modalWindow;
            Window currentMainWindow = Application.Current.MainWindow;
            if (currentMainWindow is MainWindow)
            {
                modalWindow = new InfoEventGuestWindow
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
            }
            else
            {
                modalWindow = new InfoEventUserWindow
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
            }

            modalWindow.ShowDialog();
        }
    }
}
