using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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

        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
