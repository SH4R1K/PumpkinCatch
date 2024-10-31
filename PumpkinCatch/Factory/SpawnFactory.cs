using PumpkinCatch.Abstract;
using PumpkinCatch.Interfaces;
using PumpkinCatch.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PumpkinCatch.Factory
{
    class SpawnFactory
    {
        public SpawnFactory() { }
        public ICollectableBase SpawnCollectable(string name) 
        {
            switch (name)
            {
                case "bomb":
                    return new Bomb();
                case "pumpkin":
                    return new Pumpkin();
                default:
                    break;
            }
            return new Pumpkin();
        }
    }
}
