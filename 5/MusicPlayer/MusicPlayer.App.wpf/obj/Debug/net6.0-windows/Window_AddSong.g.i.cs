﻿#pragma checksum "..\..\..\Window_AddSong.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4A6A4B58C17ADC80AF15574208C98B3A1077469E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MusicPlayer.App.wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace MusicPlayer.App.wpf {
    
    
    /// <summary>
    /// Window_AddSong
    /// </summary>
    public partial class Window_AddSong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Window_AddSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Title;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Window_AddSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Artist;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Window_AddSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Cancel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Window_AddSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Add;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Window_AddSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_FileName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Window_AddSong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Open;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MusicPlayer.App.wpf;component/window_addsong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Window_AddSong.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBox_Title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBox_Artist = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Btn_Cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.Btn_Add = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Window_AddSong.xaml"
            this.Btn_Add.Click += new System.Windows.RoutedEventHandler(this.Btn_Add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBox_FileName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Btn_Open = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Window_AddSong.xaml"
            this.Btn_Open.Click += new System.Windows.RoutedEventHandler(this.Btn_Open_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

