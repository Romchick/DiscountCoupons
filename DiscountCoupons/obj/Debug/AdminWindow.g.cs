﻿#pragma checksum "..\..\AdminWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "84E4989BC02266766440BFC299569803"
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


namespace DiscountCoupons {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameOfProduct;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceOfProduct;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox couponNumber;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem All;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Lower;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Higher;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Discount;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceSet;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DiscountCoupons;component/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminWindow.xaml"
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
            this.nameOfProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.priceOfProduct = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\AdminWindow.xaml"
            this.priceOfProduct.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.priceOfProduct_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.couponNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\AdminWindow.xaml"
            this.couponNumber.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.couponNumber_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.comboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.All = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 6:
            this.Lower = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.Higher = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.Discount = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\AdminWindow.xaml"
            this.Discount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Discount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 19 "..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Coupon_Add_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 20 "..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Product_Add_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.priceSet = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\AdminWindow.xaml"
            this.priceSet.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.priceSet_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 23 "..\..\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Set_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\AdminWindow.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

