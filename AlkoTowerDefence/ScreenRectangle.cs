using AlkoTowerDefence.Interfaces;
using System.Windows.Forms;

namespace AlkoTowerDefence
{
    /// <summary>
    /// Представление границ поля для отрисовки
    /// </summary>
    public class ScreenRectangle : ISize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public ScreenRectangle (Control component)
        {
            this.Width = component.Width;
            this.Height = component.Height;
        }
    }
}
