using System;
using System.Collections.Generic;
using System.Text;

namespace BeeCore.Entity
{
    public class Queen:Bee
    {
        internal override int PronounceDeadValue { get; set; } = 20;
    }
}
