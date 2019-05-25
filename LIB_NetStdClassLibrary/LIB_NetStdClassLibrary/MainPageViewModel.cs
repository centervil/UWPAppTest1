using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LIB_NetStdClassLibrary
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private String bindText_ = "TestText";
        public String BindText {
            get
            {
                return this.bindText_;
            }
            set {
                this.bindText_ = value;
                this.OnPropertyChanged(nameof(BindText));

                return;
            }
        }
        public ICommand InvokeTest { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public MainPageViewModel()
        {
            InvokeTest = new InvokeDll(this);
        }

        private class InvokeDll : ICommand
        {
            private MainPageViewModel vm;
            public event EventHandler CanExecuteChanged;

            public InvokeDll(MainPageViewModel viewModel)
            {
                vm = viewModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                string Text = NetStdClass.TestMethod();
                Text += "\n" + NativeMethods.InvokeCppDLL();
                Text += "\n" + NativeMethods.InvokeCppUwpDLL();
                Text += "\n" + NativeMethods.InvokeCsDLL();
                vm.BindText = Text;
            }
        }
    }
}
