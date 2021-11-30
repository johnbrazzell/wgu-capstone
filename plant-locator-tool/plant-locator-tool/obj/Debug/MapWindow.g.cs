﻿#pragma checksum "..\..\MapWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A0FE4EEEB6678A87076A0882E4D79BB218887203D2AE9D4036D675EFDBDEB6B6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Maps.MapControl.WPF;
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
    /// MapWindow
    /// </summary>
    public partial class MapWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem adminOptions;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addPlantMenuItem;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem editPlantMenuItem;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addUserMenuItem;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem viewUsersMenuItem;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem changePasswordMenuItem;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem quitMenuItem;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label plantNameLabel;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MapWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Maps.MapControl.WPF.Map mainMap;
        
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
            System.Uri resourceLocater = new System.Uri("/plant-locator-tool;component/mapwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MapWindow.xaml"
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
            this.adminOptions = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 2:
            this.addPlantMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 36 "..\..\MapWindow.xaml"
            this.addPlantMenuItem.Click += new System.Windows.RoutedEventHandler(this.addPlantMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.editPlantMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.addUserMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 38 "..\..\MapWindow.xaml"
            this.addUserMenuItem.Click += new System.Windows.RoutedEventHandler(this.addUserMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.viewUsersMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 39 "..\..\MapWindow.xaml"
            this.viewUsersMenuItem.Click += new System.Windows.RoutedEventHandler(this.viewUsersMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.changePasswordMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 42 "..\..\MapWindow.xaml"
            this.changePasswordMenuItem.Click += new System.Windows.RoutedEventHandler(this.changePasswordMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.quitMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 43 "..\..\MapWindow.xaml"
            this.quitMenuItem.Click += new System.Windows.RoutedEventHandler(this.quitMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.plantNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.mainMap = ((Microsoft.Maps.MapControl.WPF.Map)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

