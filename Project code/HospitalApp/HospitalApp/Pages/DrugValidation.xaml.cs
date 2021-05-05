﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// Interaction logic for DrugValidation.xaml
/// </summary>
public partial class DrugValidation : Page
{
    private DrugController _drugController;
    public static ObservableCollection<Drug> Drugs { get; set; }

    public void UpdateDrugs()
    {
        List<Drug> DrugsForApproval = ControllerMapper.Instance.DrugController.GetDrugsForApproval();
        Drugs.Clear();
        foreach (Drug d in DrugsForApproval)
            Drugs.Add(d);
    }

    public DrugValidation()
    {
        InitializeComponent();

        this.DataContext = this;

        Drugs = new ObservableCollection<Drug>();
        List<Drug> DrugDrugs = ControllerMapper.Instance.DrugController.GetDrugs();
        foreach (Drug d in DrugDrugs)
        {
            if (d.DrugStatus.Equals(Enums.DrugStatus.PENDING))
                Drugs.Add(d);
        }
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ApproveDrug_Click(object sender, RoutedEventArgs e)
    {
        Drug drug = dataGridValidateDrugs.SelectedItem as Drug;
        ControllerMapper.Instance.DrugController.ApproveDrug(drug);
        UpdateDrugs();
    }

    private void RejectDrug_Click(object sender, RoutedEventArgs e)
    {
        Drug drug = dataGridValidateDrugs.SelectedItem as Drug;
        ControllerMapper.Instance.DrugController.RejectDrug(drug);
        UpdateDrugs();
    }
}
