using AlkoTowerDefence.Services;
using System.Drawing;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Предстваление врага
    /// </summary>
    public class Enemy1 : EnemyBase
    {
        public override Bitmap Bitmap
        {
            get
            {
                return ImageService.Instance.Get("enemies/enemy1");
            }
            set { }
        }
    }
}
