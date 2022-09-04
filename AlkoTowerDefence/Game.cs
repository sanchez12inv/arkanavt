using AlkoTowerDefence.Interfaces;
using AlkoTowerDefence.Services.TimerService;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlkoTowerDefence
{    
    /// <summary>
    /// Представление класса игры
    /// </summary>
    public class Game
    {
        //Инициализация сервисов       
        private DrawService drawServices = new DrawService();
        private ControllService controllServices = new ControllService();
        private CollisionService collisionService = new CollisionService();
        private BulletService bulletService = new BulletService();
        private AIService aiService = new AIService();
        
        //Инициализация интерфейсов
        private ICollection<IBullet> bullets = new List<IBullet>();
        private ICollection<IEnemy> enemies = new List<IEnemy>();
        private ICollection<ITimedObject> fxs = new List<ITimedObject>();
        private ICollection<IPlayer> players = new List<IPlayer>();

        private IPlayer currentPlayer;

        private IScore score = new Score();
        private ISize screen;

        public void StartGame(ISize screen, IPlayer currentPlayer)
        {
            //Передача данных в сервисы, обнуление игрового счетчика
            this.currentPlayer = currentPlayer;
            this.screen = screen;
            drawServices.Init(fxs, bullets, enemies, players, score);
            controllServices.Init(currentPlayer);
            bulletService.Init(bullets);
            aiService.Init(enemies, screen);
            collisionService.Init(fxs, bullets, players, enemies, score, screen);
            score.X = 0;
            score.Y = screen.Height-30;
        }

        /// <summary>
        /// Добавления игрока
        /// </summary>
        /// <param name="player">Текущий игрок</param>
        public void AddPlayer(IPlayer player)
        {
            players.Add(player);
        }

        /// <summary>
        /// Отрисовка всей графики
        /// </summary>
        /// <param name="graphics">Поле на котором будет отрисована графика</param>
        public void UpdateDraw(Graphics graphics)
        {            
            drawServices.Draw(graphics);
        }

        /// <summary>
        /// Обновление логики игры
        /// </summary>
        public void UpdateGame()
        {
            collisionService.DoCheck();
        }

        /// <summary>
        /// Создание врага
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RespawnEnemy<T>() where T : IEnemy
        {
            aiService.RespawnEnemy<T>();
        }

        /// <summary>
        /// Обновление средств ввода (мыши)
        /// </summary>
        /// <param name="e">аршумент события</param>
        public void UpdateControll(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bulletService.BulletShoot(currentPlayer);
            }

            controllServices.UpdatePositionPlayer(e);
        }
    }
}
