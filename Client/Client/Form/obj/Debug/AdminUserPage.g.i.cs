﻿#pragma checksum "..\..\AdminUserPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1A467B6A140E0E7B5A37FA39B99B79EADDBA8C92"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Form;
using MaterialDesignThemes.Wpf;
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


namespace Form {
    
    
    /// <summary>
    /// AdminUserPage
    /// </summary>
    public partial class AdminUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock State;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateBtn;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InsertBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GameGrid;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\AdminUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Form;
        
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
            System.Uri resourceLocater = new System.Uri("/Form;component/adminuserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminUserPage.xaml"
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
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\AdminUserPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.State = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AdminUserPage.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UpdateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\AdminUserPage.xaml"
            this.UpdateBtn.Click += new System.Windows.RoutedEventHandler(this.UpdateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.InsertBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\AdminUserPage.xaml"
            this.InsertBtn.Click += new System.Windows.RoutedEventHandler(this.InsertBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SubmitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\AdminUserPage.xaml"
            this.SubmitBtn.Click += new System.Windows.RoutedEventHandler(this.SubmitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 40 "..\..\AdminUserPage.xaml"
            this.DataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 42 "..\..\AdminUserPage.xaml"
            this.DataGrid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.DataGrid_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GameGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 87 "..\..\AdminUserPage.xaml"
            this.GameGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Form = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

