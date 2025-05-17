using EventPass.Models.Events;
using System.Windows.Controls;

namespace EventPass
{
    /// <summary>
    /// Interaction logic for EventControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        public Event CurrentEvent { get; set; } = null!;

        public EventControl()
        {
            InitializeComponent();
        }
    }
}
