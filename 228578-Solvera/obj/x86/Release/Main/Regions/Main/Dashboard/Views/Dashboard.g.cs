﻿#pragma checksum "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E74700A12409EFE8A515E4B52DDD59B1E2163573B68D9EF69B432FDDA0EDA01"
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
using System.Windows.Forms.Integration;
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
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Extensions;
using VisiWin.Shapes;


namespace HMI.MainRegion.Dashboard.Views {
    
    
    /// <summary>
    /// Dashboard
    /// </summary>
    public partial class Dashboard : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HMI.MainRegion.Dashboard.Views.Dashboard DB;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Dashboard dashboard;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.RepeatButton btn;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel editmode;
        
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
            System.Uri resourceLocater = new System.Uri("/228578-Solvera;component/main/regions/main/dashboard/views/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
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
            this.DB = ((HMI.MainRegion.Dashboard.Views.Dashboard)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.dashboard = ((VisiWin.Controls.Dashboard)(target));
            return;
            case 4:
            this.btn = ((VisiWin.Controls.RepeatButton)(target));
            
            #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
            this.btn.Click += new System.Windows.RoutedEventHandler(this.btn_Click);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
            this.btn.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.btn_PreviewMouseUp);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\..\..\..\..\Main\Regions\Main\Dashboard\Views\Dashboard.xaml"
            this.btn.PreviewTouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btn_PreviewTouchUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.editmode = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

