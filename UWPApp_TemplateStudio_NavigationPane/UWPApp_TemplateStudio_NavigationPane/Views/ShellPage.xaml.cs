using System;

using UWPApp_TemplateStudio_NavigationPane.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPApp_TemplateStudio_NavigationPane.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
        }
    }
}
