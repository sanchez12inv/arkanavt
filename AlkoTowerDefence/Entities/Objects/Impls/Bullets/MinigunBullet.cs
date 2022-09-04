using AlkoTowerDefence.Services;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Представление патрона, пули, снаряда
    /// </summary>
    public class MinigunBullet : BulletBase
    {
        public MinigunBullet()
        {
            Width = 2;
            Height = 5;

            Speed = 5;
            Damage = 10;

            Bitmap = ImageService.Instance.Get("bullets/minigun_bullet");
        }
    }
}
