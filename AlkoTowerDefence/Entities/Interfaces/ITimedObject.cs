namespace AlkoTowerDefence.Interfaces
{

    /// <summary>
    /// Определение времени жизни эффектов
    /// </summary>
    public interface ITimedObject
    {
        bool IsDead { get; }
        void Tick();
    }

}
