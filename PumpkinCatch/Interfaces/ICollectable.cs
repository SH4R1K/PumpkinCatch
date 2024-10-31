using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpkinCatch.Interfaces
{
    interface ICollectable
    {
        public int Score { get; }
        public int Speed { get; }
        public int Collect();
    }
}
