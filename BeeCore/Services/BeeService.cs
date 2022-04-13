using BeeCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeCore.Services
{
    /// <summary>
    /// Core logic to check Damage of the Bee
    /// </summary>
    public class BeeService
    {
        //List of all bees for the test
        public List<Bee> Bees = new List<Bee>();

        //Selected bee index
        public int SelectedBeeIndex = -1;


        /// <summary>
        /// Calualte the Damage for the selected bee
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Bee Damage(double input)
        {
            if(SelectedBeeIndex <1)
            {
                return null;
            }

            var bee = Bees.Where(x => x.Id == SelectedBeeIndex).FirstOrDefault();
            if(bee == null)
            {
                return null;
            }
            
            if (input >= 0 && input <= 100 && !bee.Dead)
            {
                bee.Health = bee.Health - input;
                if(bee.Health < 0)
                {
                    bee.Health = 0;
                }
                bee.Dead = CheckToPronounceDead(bee.Health, bee.PronounceDeadValue);
            }
            return bee;
        }

        /// <summary>
        /// Checking for bee is dead or not
        /// </summary>
        /// <param name="Health"></param>
        /// <param name="pronunceDead"></param>
        /// <returns></returns>
        public bool CheckToPronounceDead(double Health, int pronunceDead)
        {
            return Health < pronunceDead;
        }        
    }
}
