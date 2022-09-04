using AlkoTowerDefence.Interfaces;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Представление визуального эффекта
    /// </summary>
    public class Spark : ILine
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2
        {
            get
            {
                return (int)(X1 + DirectionX * 3f);
            }
            set { }
        }

        public int Y2
        {
            get
            {
                return (int)(Y1 + DirectionY * 3f);
            }
            set { }
        }

        public int DirectionX { get; set; }
        public int DirectionY { get; set; }
    }
}
