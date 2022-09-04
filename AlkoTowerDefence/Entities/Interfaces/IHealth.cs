namespace AlkoTowerDefence.Interfaces
{

    /// <summary>
    /// Определение здоровья объекта
    /// </summary>
    public interface IHealth
    {

        /// <summary>
        /// Текущее значение здоровья
        /// </summary>
        int HealthPoint { get; set; }

        /// <summary>
        /// Максимальное значение здоровья
        /// </summary>
        int MaxHealthPoint { get; set; }

        bool IsDead { get; }

    }

}
