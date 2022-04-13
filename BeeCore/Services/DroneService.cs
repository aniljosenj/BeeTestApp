using BeeCore.Entity;
using BeeCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeCore.Services
{
    /// <summary>
    /// Utility for adding Drone bees
    /// </summary>
    public class DroneService 
    {
        public DroneService(BeeService beeService)
        {
            BeeService = beeService;
        }

        public BeeService BeeService { get; }

        public List<Drone> AddBeeDetails()
        {
            List<Drone> lists = new List<Drone>();           
            for (var i = BeeService.Bees.Count + 1; i <= BeeService.Bees.Count + 10; i++)
            {
                lists.Add(new Drone { Dead = false, Id = i, Type = nameof(Drone) }); ;
            }
            return lists;
        }
    }
}
