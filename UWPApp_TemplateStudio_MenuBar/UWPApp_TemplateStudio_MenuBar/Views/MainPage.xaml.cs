using System;

using UWPApp_TemplateStudio_MenuBar.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPApp_TemplateStudio_MenuBar.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
