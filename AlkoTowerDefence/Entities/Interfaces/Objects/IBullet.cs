
namespace AlkoTowerDefence.Interfaces
{

    /// <summary>
    /// Интерфейс снаряда/пули
    /// </summary>
    public interface IBullet : ISprite, // Является спрайтом
                               IDamage // Может наносить урон
    {

        /// <summary>
        /// Скорость полёта
        /// </summary>
        float Speed { get; set; }

    }

}
