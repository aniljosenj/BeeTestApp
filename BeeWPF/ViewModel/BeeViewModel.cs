using BeeCore.Entity;
using BeeCore.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BeeWPF.ViewModel
{
    class BeeViewModel :  INotifyPropertyChanged
    {
        public BeeService Service = new BeeService();

        private static readonly Lazy<BeeViewModel> lazy =
        new Lazy<BeeViewModel>(() => new BeeViewModel());

        public static BeeViewModel Instance { get { return lazy.Value; } }

        private ObservableCollection<Bee> beeInfo;
        public ObservableCollection<Bee> BeeInfo
        {
            get
            {
                return beeInfo;
            }
            set
            {
                beeInfo = value;
                RaisePropertyChanged("beeInfo");
            }
        }

        private double randomValue;
        public Double RandomValue
        {
            get
            {
                return randomValue;
            }
            set
            {
                randomValue = value;
                RaisePropertyChanged("randomValue");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
