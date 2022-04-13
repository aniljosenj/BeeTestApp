using BeeCore.Entity;
using BeeCore.Services;
using BeeWPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BeeWPF.UserControls
{
    /// <summary>
    /// Interaction logic for HeaderUserControl.xaml
    /// </summary>
    public partial class HeaderUserControl : UserControl
    {
        public HeaderUserControl()
        {
            InitializeComponent();
            this.DataContext = BeeViewModel.Instance;
            this.Start.IsEnabled = true;
            this.Refresh.IsEnabled = false;
            this.Random.IsEnabled = false;
            this.Textbox.IsEnabled = false;
        }

        private void Click_Start(object sender, RoutedEventArgs e)
        {
            BeeService beeService = BeeViewModel.Instance.Service;
            var queenservice = new QueenService(beeService);
            var queen = queenservice.AddBeeDetails();
            beeService.Bees.AddRange(queen);
            var workerservice = new WorkerService(beeService);
            var worker = workerservice.AddBeeDetails();
            beeService.Bees.AddRange(worker);
            var droneservice = new DroneService(beeService);
            var drone = droneservice.AddBeeDetails();
            beeService.Bees.AddRange(drone);

            BeeViewModel.Instance.BeeInfo = new ObservableCollection<Bee>(beeService.Bees);
            this.Start.IsEnabled = false;
            this.Refresh.IsEnabled = true;
            this.Random.IsEnabled = true;
            this.Textbox.IsEnabled = true;
        }

        private void Click_Random(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 80);
            BeeViewModel.Instance.RandomValue = number;
        }

        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            var beeService = new BeeService();
            BeeViewModel.Instance.Service = beeService;
            var queenservice = new QueenService(beeService);
            var queen = queenservice.AddBeeDetails();
            beeService.Bees.AddRange(queen);
            var workerservice = new WorkerService(beeService);
            var worker = workerservice.AddBeeDetails();
            beeService.Bees.AddRange(worker);
            var droneservice = new DroneService(beeService);
            var drone = droneservice.AddBeeDetails();
            beeService.Bees.AddRange(drone);

            BeeViewModel.Instance.BeeInfo = new ObservableCollection<Bee>(beeService.Bees);

        }
    }
}
