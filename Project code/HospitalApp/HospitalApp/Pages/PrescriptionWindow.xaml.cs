using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


/// <summary>
/// Interaction logic for PrescriptionWindow.xaml
/// </summary>
public partial class PrescriptionWindow : Window
{
    private PrescriptionController _prescriptionController;
    public PrescriptionWindow()
    {
        InitializeComponent();

    }

    private void CreatePrescriptionButton_Click(object sender, RoutedEventArgs e)
    {
        Prescription newPrescription = new Prescription();
        Medicine newMedicine = new Medicine();
        newMedicine.Name = Medicine.Text;
        newPrescription.Medicine.Add(newMedicine);
        newPrescription.Dosage = int.Parse(Dosage.Text);
        newPrescription.Usage = Usage.Text;
        newPrescription.Date = SelectPrescriptionTime.Value.Value;
        newPrescription.Period = Period.Text;
        ControllerMapper.Instance.PrescriptionController.CreatePrescription(newPrescription);
    }
}
