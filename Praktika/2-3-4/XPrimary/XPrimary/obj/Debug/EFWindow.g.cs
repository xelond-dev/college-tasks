﻿#pragma checksum "..\..\EFWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "39EA588BD540C25A75717907D873A2202436CF504A0F1E7594EB31F4AF0055C0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using XPrimary;


namespace XPrimary {
    
    
    /// <summary>
    /// EFWindow
    /// </summary>
    public partial class EFWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CurrentTableDgr;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon DeveloperFeatures_Icon;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DeveloperFeature_Debug_Text;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx1;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx2;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx3;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx1;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx2;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\EFWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CurrentTableCbx;
        
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
            System.Uri resourceLocater = new System.Uri("/XPrimary;component/efwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EFWindow.xaml"
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
            this.CurrentTableDgr = ((System.Windows.Controls.DataGrid)(target));
            
            #line 23 "..\..\EFWindow.xaml"
            this.CurrentTableDgr.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CurrentTableDgr_SelectionChanged_Event);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DeveloperFeatures_Icon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            
            #line 34 "..\..\EFWindow.xaml"
            this.DeveloperFeatures_Icon.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DisableDeveloperFeatures_Event);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeveloperFeature_Debug_Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbx1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbx2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbx3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cbx1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbx2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 61 "..\..\EFWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click_Event);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 66 "..\..\EFWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Click_Event);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 71 "..\..\EFWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Remove_Click_Event);
            
            #line default
            #line hidden
            return;
            case 12:
            this.CurrentTableCbx = ((System.Windows.Controls.ComboBox)(target));
            
            #line 95 "..\..\EFWindow.xaml"
            this.CurrentTableCbx.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CurrentTableCbx_SelectionChanged_Event);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 101 "..\..\EFWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReloadButton_Click_Event);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 110 "..\..\EFWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewTables_Click_Event);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 115 "..\..\EFWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DataSetMode_Click_Event);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
