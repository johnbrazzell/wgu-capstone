﻿#pragma checksum "..\..\EditPlantWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2F5CC4FEF2A0FBAD630F3049A621BDC772FFB8F0591D3DEE688567F3869F21B1"
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
using plant_locator_tool;


namespace plant_locator_tool {
    
    
    /// <summary>
    /// EditPlantWindow
    /// </summary>
    public partial class EditPlantWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updatePlantbutton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox plantNameTextbox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneNumberTextbox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox productsProducedTextbox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox streetTextbox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cityTextbox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stateTextbox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox zipTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\EditPlantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/plant-locator-tool;component/editplantwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditPlantWindow.xaml"
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
            this.updatePlantbutton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\EditPlantWindow.xaml"
            this.updatePlantbutton.Click += new System.Windows.RoutedEventHandler(this.updatePlantbutton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.plantNameTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.phoneNumberTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.productsProducedTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.streetTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cityTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.stateTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.zipTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\EditPlantWindow.xaml"
            this.cancelButton.Click += new System.Windows.RoutedEventHandler(this.cancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

