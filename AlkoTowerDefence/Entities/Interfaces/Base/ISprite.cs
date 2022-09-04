using System.Drawing;

namespace AlkoTowerDefence.Interfaces
{

    /// <summary>
    /// Определяет объект спрайта:
    /// прямоугольный объект который рисуется на полотне
    /// </summary>
    public interface ISprite : ISize, IPoint
    {
        Bitmap Bitmap { get; set; }
    }

}
