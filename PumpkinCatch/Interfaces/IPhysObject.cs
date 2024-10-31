using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PumpkinCatch.Interfaces
{
    interface IPhysObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Rectangle HitBox { get; }
    }
}
