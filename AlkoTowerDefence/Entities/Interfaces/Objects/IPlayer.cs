using AlkoTowerDefence.Types;

namespace AlkoTowerDefence.Interfaces
{

    /// <summary>
    /// Интерфейс игрока/персонажа
    /// </summary>
    public interface IPlayer : ISprite, // Является спрайтом
                               IHealth // У него есть здоровье
    {

        /// <summary>
        /// Скорость стрельбы
        /// </summary>
        float ShootSpeed { get; set; }

        /// <summary>
        /// Возвращает новый экземпляр пули
        /// </summary>
        IBullet Bullet { get; set; }
        
        /// <summary>
        /// Внешний вид корпуса
        /// </summary>
        BodyType BodyType { get; set; }

    }

}
