using AlkoTowerDefence.Interfaces;
using AlkoTowerDefence.Objects;
using System.Collections.Generic;

namespace AlkoTowerDefence.Services.TimerService
{
    /// <summary>
    /// Представление сервиса коллизииы
    /// </summary>
    public class CollisionService
    {
        private ICollection<IBullet> bullets;
        private ICollection<IPlayer> players;
        private ICollection<IEnemy> enemies;
        private ICollection<ITimedObject> fxs;

        public IScore score;
        private ISize screen;

        public void Init(ICollection<ITimedObject> sparkGroup,
                         ICollection<IBullet> bullets,
                         ICollection<IPlayer> players,
                         ICollection<IEnemy> enemies,
                         IScore score,
                         ISize screen)
        {
            this.bullets = bullets;
            this.players = players;
            this.enemies = enemies;
            this.score = score;
            this.screen = screen;
            this.fxs = sparkGroup;
        }

        public void DoCheck()
        {
            EnemyFly();
            BulletFly();
            CheckHits();
            ClearFxs();
        }

        private void BulletFly()
        {
            foreach (IBullet bullet in bullets.Safe())
            {
                if (bullet.Y >= 0)
                    bullet.Y = (int)(bullet.Y - bullet.Speed);
                else
                    bullets.Remove(bullet);
            }
        }

        private void EnemyFly()
        {
            foreach (IEnemy enemy in enemies.Safe())
            {
                if (enemy.Y + enemy.Height < screen.Height && enemy.HealthPoint > 0)
                    enemy.Y = enemy.Y + enemy.Speed;
                else
                    enemies.Remove(enemy);
            }
        }

        private void CheckHits()
        {

            foreach (IBullet bullet in bullets.Safe())
                foreach (IEnemy enemy in enemies.Safe())
                {
                    if (!Intersection(bullet.X,
                                      bullet.Y,
                                      bullet.X,
                                      bullet.Y,
                                      enemy.X,
                                      enemy.Y,
                                      enemy.X + enemy.Width,
                                      enemy.Y + enemy.Height))
                        continue;

                    fxs.Add(new SparkGroup(bullet.X, bullet.Y));

                    Damage(bullet, enemy);

                    if (enemy.IsDead)
                        KillEnemy(enemy);

                    bullets.Remove(bullet);
                }
        }

        private bool Intersection(float x11,
                                  float y11,
                                  float x12,
                                  float y12,
                                  float x21,
                                  float y21,
                                  float x22,
                                  float y22)
        {
            return y11 >= y21
                && x11 >= x21
                && y12 <= y22
                && x12 <= x22;
        }

        private void Damage(IDamage damaged, IHealth target)
        {
            target.HealthPoint -= damaged.Damage;
        }

        private void KillEnemy(IEnemy enemy)
        {
            enemies.Remove(enemy);
            score.ScoreKill = score.ScoreKill + 1;
        }

        private void ClearFxs()
        {
            foreach (var item in fxs.Safe())
            {
                if (item.IsDead)
                    fxs.Remove(item);
            }
        }
    }
}
