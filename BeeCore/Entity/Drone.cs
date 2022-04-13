using System;
using System.Collections.Generic;
using System.Text;

namespace BeeCore.Entity
{
    public class Drone : Bee
    {
        internal override int PronounceDeadValue { get; set; } = 50;
    }
}
