namespace AlkoTowerDefence.Interfaces
{
    /// <summary>
    /// Определяет что объект может наносить урон
    /// </summary>
    public interface IDamage
    {
        /// <summary>
        /// Урон, который наносится
        /// </summary>
        int Damage { get; set; }
    }

}
