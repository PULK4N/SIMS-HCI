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
    public Patient thisPatient { get; set; }
    public PrescriptionWindow(Patient patient)
    {
        InitializeComponent();
        thisPatient = patient;
    }

    private void CreatePrescriptionButton_Click(object sender, RoutedEventArgs e)
    {
<<<<<<< Updated upstream
        Prescription newPrescription = new Prescription();
        Drug newMedicine = new Drug();
        newMedicine.Name = Medicine.Text;
        newPrescription.Drug = newMedicine;
        newPrescription.Dosage = int.Parse(Dosage.Text);
        newPrescription.Usage = Usage.Text;
        newPrescription.Date = SelectPrescriptionTime.Value.Value;
        newPrescription.Period = Period.Text;
        ControllerMapper.Instance.PrescriptionController.CreatePrescription(newPrescription);
=======
        if (isAlergicTo(Medicine.Text))
        {
            MessageBox.Show("This drug is not safe for the patient");
        }
        else
        {
            Prescription newPrescription = new Prescription();
            Drug newMedicine = new Drug();
            newMedicine.Name = Medicine.Text;
            newPrescription.Drug = newMedicine;
            newPrescription.Dosage = int.Parse(Dosage.Text);
            newPrescription.Usage = Usage.Text;
            newPrescription.Date = SelectPrescriptionTime.Value.Value;
            newPrescription.Period = Period.Text;
            Map.PrescriptionController.Create(newPrescription);
        }
    }

    public bool isAlergicTo(string drug)
    {
        if (thisPatient.alergies.Equals(drug))
            return true;
        return false;
>>>>>>> Stashed changes
    }
}
