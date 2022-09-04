using System.Drawing;
using AlkoTowerDefence.Interfaces;
using AlkoTowerDefence.Services;
using AlkoTowerDefence.Types;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Представление игрока
    /// </summary>
    public class Player : PlayerBase
    {

        public Player()
        {
            Width = 70;
            Height = 80;
            BodyType = BodyType.TypeA;
        }

        public override Bitmap Bitmap
        {
            get
            {
                var key = $"players/{BodyType.ToString()}_player"; // Формируем внешний вид персонажа по типу корпуса
                return ImageService.Instance.Get(key);
            }
            set { }
        }

        public override IBullet Bullet
        {
            get
            {
                return new MinigunBullet();
            }
            set { }
        }
    }
}
