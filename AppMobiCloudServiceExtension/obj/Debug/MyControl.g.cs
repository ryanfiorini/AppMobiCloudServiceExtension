﻿#pragma checksum "..\..\MyControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E3755B0163DC3BEC6444328FB7323FC1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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


namespace appMobi.AppMobiCloudServiceExtension {
    
    
    /// <summary>
    /// MyControl
    /// </summary>
    public partial class MyControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal appMobi.AppMobiCloudServiceExtension.MyControl MyToolWindow;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btnGotoApphub;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock btnWindowsLive;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grpSignin;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignin;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grpWelcome;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUserName;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUploadPackage;
        
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
            System.Uri resourceLocater = new System.Uri("/AppMobiCloudServiceExtension;component/mycontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MyControl.xaml"
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
            this.MyToolWindow = ((appMobi.AppMobiCloudServiceExtension.MyControl)(target));
            return;
            case 2:
            this.btnGotoApphub = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 40 "..\..\MyControl.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.btnGotoApphub_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnWindowsLive = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 41 "..\..\MyControl.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.btnWindowsLive_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grpSignin = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 7:
            this.txtUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.btnSignin = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\MyControl.xaml"
            this.btnSignin.Click += new System.Windows.RoutedEventHandler(this.btnSignin_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.grpWelcome = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 11:
            this.lblUserName = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.btnUploadPackage = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\MyControl.xaml"
            this.btnUploadPackage.Click += new System.Windows.RoutedEventHandler(this.btnUploadPackage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
