﻿#pragma checksum "..\..\..\Pages\PrescriptionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "57FBBBAEAF5C3720F710C3C0E039DA44D0130042141C6EEEC705032F7A60CFD5"
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;




/// <summary>
/// PrescriptionWindow
/// </summary>
public partial class PrescriptionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
    
    
    #line 9 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.Grid PrescribeMedicineButton;
    
    #line default
    #line hidden
    
    
    #line 10 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Medicine;
    
    #line default
    #line hidden
    
    
    #line 11 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Dosage;
    
    #line default
    #line hidden
    
    
    #line 12 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Usage;
    
    #line default
    #line hidden
    
    
    #line 13 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.Button CreatePrescriptionButton;
    
    #line default
    #line hidden
    
    
    #line 14 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal System.Windows.Controls.TextBox Period;
    
    #line default
    #line hidden
    
    
    #line 16 "..\..\..\Pages\PrescriptionWindow.xaml"
    [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
    internal Xceed.Wpf.Toolkit.DateTimePicker SelectPrescriptionTime;
    
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
        System.Uri resourceLocater = new System.Uri("/HospitalApp;component/pages/prescriptionwindow.xaml", System.UriKind.Relative);
        
        #line 1 "..\..\..\Pages\PrescriptionWindow.xaml"
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
        this.PrescribeMedicineButton = ((System.Windows.Controls.Grid)(target));
        return;
            case 2:
        this.Medicine = ((System.Windows.Controls.TextBox)(target));
        return;
            case 3:
        this.Dosage = ((System.Windows.Controls.TextBox)(target));
        return;
            case 4:
        this.Usage = ((System.Windows.Controls.TextBox)(target));
        return;
            case 5:
        this.CreatePrescriptionButton = ((System.Windows.Controls.Button)(target));
        
        #line 13 "..\..\..\Pages\PrescriptionWindow.xaml"
        this.CreatePrescriptionButton.Click += new System.Windows.RoutedEventHandler(this.CreatePrescriptionButton_Click);
        
        #line default
        #line hidden
        return;
            case 6:
        this.Period = ((System.Windows.Controls.TextBox)(target));
        return;
            case 7:
        this.SelectPrescriptionTime = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
        return;
            }
        this._contentLoaded = true;
    }
}

