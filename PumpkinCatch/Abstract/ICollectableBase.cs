using PumpkinCatch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PumpkinCatch.Abstract
{
    interface ICollectableBase : ICollectable, IMovable, IDisposable
    {
        public bool Disposed { get; set; }
    }
}
