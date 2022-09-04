using AlkoTowerDefence.Interfaces;

namespace AlkoTowerDefence
{
    /// <summary>
    /// Представление игрового счетчика
    /// </summary>
    public class Score : IScore
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int ScoreKill { get; set; }
        public int Coins { get; set; }
    }
}
