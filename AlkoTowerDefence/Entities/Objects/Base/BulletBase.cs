using System.Drawing;
using AlkoTowerDefence.Interfaces;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Базовое представление патрона, пули, снаряда
    /// </summary>
    public abstract class BulletBase : IBullet
    {

        public float Speed { get; set; }
        public Bitmap Bitmap { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Damage { get; set; }

    }

}
