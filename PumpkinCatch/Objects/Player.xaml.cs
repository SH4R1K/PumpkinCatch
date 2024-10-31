using PumpkinCatch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PumpkinCatch.Objects
{
    /// <summary>
    /// Логика взаимодействия для Player.xaml
    /// </summary>
    public partial class Player : UserControl, IPhysObject
    {
        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        public int Score { get; set; } = 0;

        public Rectangle HitBox => playerHitBox;

        public Player()
        {
            InitializeComponent();
        }

        internal void Collect(ICollectable collectable)
        {
            Score += collectable.Collect();  

        }
    }
}
