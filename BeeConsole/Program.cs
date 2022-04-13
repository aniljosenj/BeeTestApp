using BeeCore.Entity;
using BeeCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeCore
{
    class Program
    {
        static void Main(string[] args)
        {       
            BeeService beeService = new BeeService();
            var queenservice = new QueenService(beeService);
            var queen = queenservice.AddBeeDetails();
            beeService.Bees.AddRange(queen);
            var workerservice = new WorkerService(beeService);
            var worker = workerservice.AddBeeDetails();
            beeService.Bees.AddRange(worker);
            var droneservice = new DroneService(beeService);
            var drone = droneservice.AddBeeDetails();
            beeService.Bees.AddRange(drone);

            PerformHealthCheck(beeService, beeService.Bees);

            Console.ReadLine();

        }

        private static void PerformHealthCheck(BeeService beeService, List<Bee> bees)
        {        
            bees.ForEach(x =>
            {
                Console.WriteLine($"Beeid = {x.Id} , Bee Health = {x.Health} , Dead = {x.Dead}, type = {x.Type}");
            });

            Random rnd = new Random();
            int number = rnd.Next(0, bees.Count);
            Console.WriteLine($"Random bee selected {number}");
            var selectedBee = bees.Where(x => x.Id == number).FirstOrDefault();
            beeService.SelectedBeeIndex = selectedBee.Id;
            if (selectedBee == null)
            {
                Console.WriteLine("Selected Bee not found");
                return;
            }

            //inject damage
            int damage = rnd.Next(0,100);
            Console.WriteLine($"Random damage value selected {damage}");           
           
            var bee = beeService.Damage(damage);
            if(bee == null)
            {
                Console.WriteLine("Selected Bee not found");
                return;
            }

            bees.ForEach(x =>
            {
                Console.WriteLine($"Beeid = {x.Id} , Bee Health = {x.Health} , Dead = {x.Dead} , type = {x.Type}");
            });
        }
    }
}
