﻿#pragma checksum "..\..\GamePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36F797650AE8E5670BD778249A94424747924BDC"
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
using Form.UserControls;
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
    /// GamePage
    /// </summary>
    public partial class GamePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitGameButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Form.UserControls.Player1UC uc1;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Form.UserControls.Player2UC uc2;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Form.UserControls.Player3UC uc3;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Form.UserControls.Player4UC uc4;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Form.UserControls.TableUC uctable;
        
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
            System.Uri resourceLocater = new System.Uri("/Form;component/gamepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GamePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.ExitGameButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\GamePage.xaml"
            this.ExitGameButton.Click += new System.Windows.RoutedEventHandler(this.ExitGameButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.uc1 = ((Form.UserControls.Player1UC)(target));
            return;
            case 3:
            this.uc2 = ((Form.UserControls.Player2UC)(target));
            return;
            case 4:
            this.uc3 = ((Form.UserControls.Player3UC)(target));
            return;
            case 5:
            this.uc4 = ((Form.UserControls.Player4UC)(target));
            return;
            case 6:
            this.uctable = ((Form.UserControls.TableUC)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

