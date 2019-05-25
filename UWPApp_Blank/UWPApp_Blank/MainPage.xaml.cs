﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using LIB_NetStdClassLibrary;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace UWPApp_Blank
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void TestButton_Click(object sender, RoutedEventArgs e)
        {
            string Text = Class1.TestMethod();
            MessageDialog md = new MessageDialog(Text);
            await md.ShowAsync();

            Text = NativeMethods.InvokeCppDLL();
            MessageDialog md2 = new MessageDialog(Text);
            await md2.ShowAsync();

            Text = NativeMethods.InvokeCppUwpDLL();
            MessageDialog md3 = new MessageDialog(Text);
            await md3.ShowAsync();

            Text = NativeMethods.InvokeCsDLL();
            MessageDialog md4 = new MessageDialog(Text);
            await md4.ShowAsync();
        }
    }
}
