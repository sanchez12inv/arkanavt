using AlkoTowerDefence.Interfaces;
using AlkoTowerDefence.Objects;
using System.Collections.Generic;
using System.Drawing;

namespace AlkoTowerDefence
{
    /// <summary>
    /// Представление сервиса по отрисовке
    /// </summary>
    public class DrawService
    {
        private ICollection<IBullet> bullets;
        private ICollection<ITimedObject> sparkGroup;
        private ICollection<IEnemy> enemies;
        private ICollection<IPlayer> players;

        private IScore score;

        public void Init(ICollection<ITimedObject> fxs,
                         ICollection<IBullet> bullets,
                         ICollection<IEnemy> enemies,
                         ICollection<IPlayer> players,
                         IScore score)
        {
            this.bullets = bullets;
            this.enemies = enemies;
            this.players = players;
            this.score = score;
            this.sparkGroup = fxs;
        }

        public void Draw(Graphics graphics)
        {
            DrawField(graphics);
            DrawScore(graphics);
            DrawPlayers(graphics, players);
            DrawBullets(graphics, bullets);
            DrawEnemies(graphics, enemies);
            DrawSparkGroups(graphics, sparkGroup);
        }

        public void DrawField(Graphics graphics)
        {
            graphics.Clear(Color.Black);
        }

        private void DrawSprite(Graphics graphics, ISprite sprite)
        {
            graphics.DrawImage(sprite.Bitmap, sprite.X, sprite.Y, sprite.Width, sprite.Height);
        }

        private void DrawPlayers(Graphics graphics, ICollection<IPlayer> players)
        {
            foreach (IPlayer player in players.Safe())
                DrawPlayer(graphics, player);
        }

        private void DrawPlayer(Graphics graphics, IPlayer player)
        {
            DrawSprite(graphics, player);
        }

        private void DrawBullets(Graphics graphics, ICollection<IBullet> bullets)
        {
            foreach (IBullet bullet in bullets.Safe())
                DrawBullet(graphics, bullet);
        }

        private void DrawBullet(Graphics graphics, IBullet bullet)
        {
            DrawSprite(graphics, bullet);
        }

        private void DrawSparkGroups(Graphics graphics, ICollection<ITimedObject> fxs)
        {
            foreach (ITimedObject fx in fxs.Safe())
                if(fx is SparkGroup)
                    DrawSparkGroup(graphics, fx as SparkGroup);
        }

        private void DrawSparkGroup(Graphics graphics, SparkGroup group)
        {
            group.Tick();

            foreach (var spark in group.Sparks)
            {
                var x1 = spark.X1;
                var y1 = spark.Y1;
                var x2 = spark.X1 + spark.DirectionX * 3f;
                var y2 = spark.Y1 + spark.DirectionY * 3f;

                graphics.DrawLine(new Pen(new SolidBrush(Color.Yellow)), x1,y1,x2,y2);
            }
        }

        private void DrawEnemy(Graphics graphics, IEnemy enemy)
        {
            DrawSprite(graphics, enemy);
        }

        private void DrawEnemies(Graphics graphics, ICollection<IEnemy> enemies)
        {
            foreach (IEnemy enemy in enemies.Safe())
                DrawEnemy(graphics, enemy);
        }


        private static Font font = new Font("Arial", 26, FontStyle.Regular, GraphicsUnit.Pixel);

        public void DrawScore(Graphics graphics)
        {
            var text = "Убито: " + score.ScoreKill.ToString();
            graphics.DrawString(text, font, new SolidBrush(Color.Green), score.X, score.Y);
        }
    }
}
