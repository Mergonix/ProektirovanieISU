﻿#pragma checksum "..\..\Base of transactions.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "085172075403C3B789180608A3AA284651FBEED6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace Property {
    
    
    /// <summary>
    /// Base_of_transactions
    /// </summary>
    public partial class Base_of_transactions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Deal;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Filter;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Print;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DataOt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DataDo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Base of transactions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Transactions;
        
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
            System.Uri resourceLocater = new System.Uri("/Property;component/base%20of%20transactions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Base of transactions.xaml"
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
            this.Logo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.Deal = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Base of transactions.xaml"
            this.Deal.Click += new System.Windows.RoutedEventHandler(this.Deal_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Filter = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Base of transactions.xaml"
            this.Filter.Click += new System.Windows.RoutedEventHandler(this.Filter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Print = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Base of transactions.xaml"
            this.Print.Click += new System.Windows.RoutedEventHandler(this.Print_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Base of transactions.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DataOt = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.DataDo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.Transactions = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

