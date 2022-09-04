using AlkoTowerDefence.Interfaces;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Базовое представление элементов эффекта
    /// </summary>
    public abstract class TimedObjectBase : IPoint,
                                            ISize,
                                            ITimedObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        
        public virtual bool IsDead { get; }
        public virtual void Tick() { }        
    }
}
