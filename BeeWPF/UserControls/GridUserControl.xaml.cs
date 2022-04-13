using BeeCore.Entity;
using BeeWPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BeeWPF.UserControls
{
    /// <summary>
    /// Interaction logic for GridUserControl.xaml
    /// </summary>
    public partial class GridUserControl : UserControl
    {
        public GridUserControl()
        {
            InitializeComponent();
            this.DataContext = BeeViewModel.Instance;
        }

        private void Click_Damage(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            var selectedItem = b.CommandParameter as Bee;

            BeeViewModel.Instance.Service.SelectedBeeIndex = selectedItem.Id;
       
            var bee = BeeViewModel.Instance.Service.Damage(BeeViewModel.Instance.RandomValue);
            if (bee == null)
            {
                Console.WriteLine("Selected Bee not found");
                return;
            }

            BeeViewModel.Instance.BeeInfo = new ObservableCollection<Bee>(BeeViewModel.Instance.Service.Bees);

        }
    }
}
