using BeeCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeCore.Services
{
    /// <summary>
    /// Utility for adding Worker bees
    /// </summary>
    public class WorkerService 
    {
        public WorkerService(BeeService beeService)
        {
            BeeService = beeService;
        }

        public BeeService BeeService { get; }

        public List<Worker> AddBeeDetails()
        {
            List<Worker> lists = new List<Worker>();           
            for (var i = BeeService.Bees.Count + 1; i <= BeeService.Bees.Count + 10; i++)
            {
                lists.Add(new Worker { Dead = false, Id = i, Type = nameof(Worker) });
            }
            return lists;
        }
    }
}
