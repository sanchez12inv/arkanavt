using AlkoTowerDefence.Interfaces;
using System;
using System.Collections.Generic;

namespace AlkoTowerDefence.Services.TimerService
{
    /// <summary>
    /// Представление сервиса поведения врагов
    /// </summary>
    public class AIService
    {
        private ICollection<IEnemy> enemies;

        private ISize screen;

        private static Random random = new Random();

        public void Init(ICollection<IEnemy> enemies, ISize screen)
        {
            this.enemies = enemies;
            this.screen = screen;
        }

        public void RespawnEnemy<T>() where T : IEnemy
        {
            IEnemy enemy = Activator.CreateInstance<T>();

            enemy.X = random.Next(screen.Width - enemy.Width);

            if (enemy.X <= 0)
            {
                enemy.X = enemy.Width;
            }

            enemy.Y = -enemy.Height;

            enemies.Add(enemy);
        }
    }
}
