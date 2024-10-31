using PumpkinCatch.Abstract;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PumpkinCatch.Objects
{
    /// <summary>
    /// Логика взаимодействия для Pumpkin.xaml
    /// </summary>
    public partial class Pumpkin : UserControl, ICollectableBase
    {

        public double X { get => Canvas.GetLeft(this); set => Canvas.SetLeft(this, value); }
        public double Y { get => Canvas.GetTop(this); set => Canvas.SetTop(this, value); }
        RotateTransform rotateTransform = new RotateTransform();

        public int Score => 100;

        public int Speed => 5;
        public bool Disposed { get; set; } = false;

        public Rectangle HitBox => hitBoxPumpkin;

        public Pumpkin()
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
