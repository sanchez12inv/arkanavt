using AlkoTowerDefence.Interfaces;
using System.Drawing;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Базовое представление объекта врага
    /// </summary>
    public abstract class EnemyBase : IEnemy
    {
        public bool IsDead
        {
            get
            {
                return HealthPoint <= 0;
            }
        }


        #region Abstract Section 

        public abstract Bitmap Bitmap { get; set; }
        public virtual IBullet Bullet { get; set; }

        #endregion

        #region Virtual Section

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual float ShootSpeed { get; set; }
        public virtual int HealthPoint { get; set; }
        public virtual int MaxHealthPoint { get; set; }
        public virtual int Speed { get; set; }
        #endregion

        public EnemyBase()
        {
            Width = 100;
            Height = 120;

            Speed = 1;
            HealthPoint = 30;

            ShootSpeed = 0;
            Bullet = null;
        }

    }

}
