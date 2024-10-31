using PumpkinCatch.Interfaces;
using PumpkinCatch.Abstract;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PumpkinCatch.Objects
{
    /// <summary>
    /// Логика взаимодействия для Bomb.xaml
    /// </summary>
    public partial class Bomb : UserControl, ICollectableBase
    {

        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        RotateTransform rotateTransform = new RotateTransform();

        public int Score => -500;

        public int Speed => 5;
        public bool Disposed { get; set; } = false;

        public Rectangle HitBox => hitBoxBomb;

        public Bomb()
        {
            InitializeComponent();
            Width = 150;
            Height = 150;
            rotateTransform.CenterX = Width / 2;
            rotateTransform.CenterY = Height / 2;
            RenderTransform = rotateTransform;
        }
        public void MoveDown()
        {
            Y += Speed;
            rotateTransform.Angle = Y;
            if (Y > ((Canvas)Parent).Height)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            ((Canvas)Parent).Children.Remove(this);
            Disposed = true;
        }

        public int Collect()
        {
            Dispose();
            return Score;
        }
    }
}
