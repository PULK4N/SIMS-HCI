using System.Windows;
using System.Windows.Controls;

namespace HospitalApp.View
{

    public partial class Anamnesis : Page
    {
        private ViewModel.Anamnesis AnamnesisViewModel;
        public Anamnesis()
        {
            InitializeComponent();
            AnamnesisViewModel = new ViewModel.Anamnesis();
            this.DataContext = AnamnesisViewModel;
        }

    }
}
