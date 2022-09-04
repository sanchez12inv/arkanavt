
namespace AlkoTowerDefence.Interfaces
{

    /// <summary>
    /// Интерфейс противников
    /// </summary>
    public interface IEnemy : ISprite,
                              IHealth
    {
        float ShootSpeed { get; set; }
        int Speed { get; set; }
    }

}
