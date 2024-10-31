using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpkinCatch.Interfaces
{
    interface IMovable : IPhysObject
    {
        public void MoveDown();
    }
}
