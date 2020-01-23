﻿#pragma checksum "..\..\..\User Controls\Vendors.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51C7BB80E9F3E3855A58DE35B369411EFA69D818A39AA6434B8BFD5DCEA8B2E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Store_Demo;
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


namespace Store_Demo {
    
    
    /// <summary>
    /// Vendors
    /// </summary>
    public partial class Vendors : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox StoreGBX;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Code_txt;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Active_chbx;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name_txt;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewBtn;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBtn;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UndoBtn;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\User Controls\Vendors.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Vendors_DGV;
        
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
            System.Uri resourceLocater = new System.Uri("/Store Demo;component/user%20controls/vendors.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\User Controls\Vendors.xaml"
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
            this.StoreGBX = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 2:
            this.Code_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Active_chbx = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.Name_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.NewBtn = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\User Controls\Vendors.xaml"
            this.NewBtn.Click += new System.Windows.RoutedEventHandler(this.NewButtonClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\User Controls\Vendors.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UpdateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\User Controls\Vendors.xaml"
            this.UpdateBtn.Click += new System.Windows.RoutedEventHandler(this.UpdateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.UndoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\User Controls\Vendors.xaml"
            this.UndoBtn.Click += new System.Windows.RoutedEventHandler(this.UndoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\User Controls\Vendors.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Vendors_DGV = ((System.Windows.Controls.DataGrid)(target));
            
            #line 106 "..\..\..\User Controls\Vendors.xaml"
            this.Vendors_DGV.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.RowClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

