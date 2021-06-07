using System.Windows;
using System.Windows.Controls;


namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private Frame mainFrame;
        public Home(Frame frame)
        {
            mainFrame = frame;
            InitializeComponent();
        }

    }
}
