using BeeCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeCore.Services
{
    /// <summary>
    /// Utility for adding Queen bees
    /// </summary>
    public class QueenService 
    {
        public QueenService(BeeService beeService)
        {
            BeeService = beeService;
        }

        public BeeService BeeService { get; }

        public List<Queen> AddBeeDetails()
        {
            List<Queen> lists = new List<Queen>();           
            for (var i = BeeService.Bees.Count + 1; i <= BeeService.Bees.Count + 10; i++)
            {
                lists.Add(new Queen { Dead = false, Id = i, Type = nameof(Queen) });
            }
            return lists;
        }

    }
}
