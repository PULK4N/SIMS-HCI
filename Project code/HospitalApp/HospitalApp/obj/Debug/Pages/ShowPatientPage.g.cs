﻿#pragma checksum "..\..\..\Pages\ShowPatientPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A56EB45206D7B7FE525AF47BDDEFB76AC24EC5A40E69D4B393C5923235E6E9AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;




/// <summary>
/// ShowPatientPage
/// </summary>
public partial class ShowPatientPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
    
    
    #line 9 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Ime;
    
    #line default
    #line hidden
    
    
    #line 10 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Prezime;
    
    #line default
    #line hidden
    
    
    #line 11 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Bday;
    
    #line default
    #line hidden
    
    
    #line 12 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Sex;
    
    #line default
    #line hidden
    
    
    #line 13 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Adress;
    
    #line default
    #line hidden
    
    
    #line 14 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Email;
    
    #line default
    #line hidden
    
    
    #line 15 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Phone;
    
    #line default
    #line hidden
    
    
    #line 16 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox JMBG;
    
    #line default
    #line hidden
    
    
    #line 17 "..\..\..\Pages\ShowPatientPage.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.Button WritePrescriptionButton;
    
    #line default
    #line hidden
    
    private bool _contentLoaded;
    
    /// <summary>
    /// InitializeComponent
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent() {
        if (_contentLoaded) {
            return;
        }
        _contentLoaded = true;
        System.Uri resourceLocater = new System.Uri("/HospitalApp;component/pages/showpatientpage.xaml", System.UriKind.Relative);
        
        #line 1 "..\..\..\Pages\ShowPatientPage.xaml"
        System.Windows.Application.LoadComponent(this, resourceLocater);
        
        #line default
        #line hidden
    }
    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
    void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
        this.Ime = ((System.Windows.Controls.TextBox)(target));
        return;
            case 2:
        this.Prezime = ((System.Windows.Controls.TextBox)(target));
        return;
            case 3:
        this.Bday = ((System.Windows.Controls.TextBox)(target));
        return;
            case 4:
        this.Sex = ((System.Windows.Controls.TextBox)(target));
        return;
            case 5:
        this.Adress = ((System.Windows.Controls.TextBox)(target));
        return;
            case 6:
        this.Email = ((System.Windows.Controls.TextBox)(target));
        return;
            case 7:
        this.Phone = ((System.Windows.Controls.TextBox)(target));
        return;
            case 8:
        this.JMBG = ((System.Windows.Controls.TextBox)(target));
        return;
            case 9:
        this.WritePrescriptionButton = ((System.Windows.Controls.Button)(target));
        
        #line 17 "..\..\..\Pages\ShowPatientPage.xaml"
        this.WritePrescriptionButton.Click += new System.Windows.RoutedEventHandler(this.WritePrescriptionButton_Click);
        
        #line default
        #line hidden
        return;
            }
        this._contentLoaded = true;
    }
}

