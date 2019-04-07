using System;
using System.Collections.Generic;
using System.Windows.Input;

using UWPApp_TemplateStudio_MenuBar.Helpers;
using UWPApp_TemplateStudio_MenuBar.Services;
using UWPApp_TemplateStudio_MenuBar.Views;

using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace UWPApp_TemplateStudio_MenuBar.ViewModels
{
    public class ShellViewModel : Observable
    {
        private readonly KeyboardAccelerator _altLeftKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu);
        private readonly KeyboardAccelerator _backKeyboardAccelerator = BuildKeyboardAccelerator(VirtualKey.GoBack);
        private IList<KeyboardAccelerator> _keyboardAccelerators;

        private ICommand _loadedCommand;
        private ICommand _menuViewsMainCommand;
        private ICommand _menuFileExitCommand;

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand MenuViewsMainCommand => _menuViewsMainCommand ?? (_menuViewsMainCommand = new RelayCommand(OnMenuViewsMain));

        public ICommand MenuFileExitCommand => _menuFileExitCommand ?? (_menuFileExitCommand = new RelayCommand(OnMenuFileExit));

        public ShellViewModel()
        {
        }

        public void Initialize(Frame shellFrame, SplitView splitView, Frame rightFrame, IList<KeyboardAccelerator> keyboardAccelerators)
        {
            NavigationService.Frame = shellFrame;
            MenuNavigationHelper.Initialize(splitView, rightFrame);
            _keyboardAccelerators = keyboardAccelerators;
        }

        private void OnLoaded()
        {
            // Keyboard accelerators are added here to avoid showing 'Alt + left' tooltip on the page.
            // More info on tracking issue https://github.com/Microsoft/microsoft-ui-xaml/issues/8
            _keyboardAccelerators.Add(_altLeftKeyboardAccelerator);
            _keyboardAccelerators.Add(_backKeyboardAccelerator);
        }

        private void OnMenuViewsMain() => MenuNavigationHelper.UpdateView(typeof(MainPage));

        private void OnMenuFileExit()
        {
            Application.Current.Exit();
        }

        private static KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
        {
            var keyboardAccelerator = new KeyboardAccelerator() { Key = key };
            if (modifiers.HasValue)
            {
                keyboardAccelerator.Modifiers = modifiers.Value;
            }

            keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;
            return keyboardAccelerator;
        }

        private static void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            var result = NavigationService.GoBack();
            args.Handled = result;
        }
    }
}
