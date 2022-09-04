using AlkoTowerDefence.Interfaces;
using System.Collections.Generic;

namespace AlkoTowerDefence.Services.TimerService
{
    //Представление сервиса пуль, патронов
    public class BulletService
    {
        private ICollection<IBullet> bullets;

        public void Init(ICollection<IBullet> bullets)
        {
            this.bullets = bullets;
        }

        public void BulletShoot(IPlayer player)
        {
            var bullet = player.Bullet;

            bullet.X = player.X + player.Width / 2;
            bullet.Y = player.Y;

            bullets.Add(bullet);
        }

    }
}
