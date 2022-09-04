using System.Drawing;
using AlkoTowerDefence.Interfaces;
using AlkoTowerDefence.Types;

namespace AlkoTowerDefence.Objects
{

    /// <summary>
    /// Базовое представление игрока
    /// </summary>
    public abstract class PlayerBase : IPlayer
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
        public abstract IBullet Bullet { get; set; }

        #endregion

        #region Virtual Section

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual BodyType BodyType { get; set; }
        public virtual float ShootSpeed { get; set; }
        public virtual int HealthPoint { get; set; }
        public virtual int MaxHealthPoint { get; set; }

        #endregion

    }

}
