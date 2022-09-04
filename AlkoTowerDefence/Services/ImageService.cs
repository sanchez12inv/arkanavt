using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlkoTowerDefence.Services
{
    /// <summary>
    /// Представление сервиса подгрузки изображений
    /// </summary>
    public class ImageService
    {

        #region Singleton

        private static Lazy<ImageService> _instance = new Lazy<ImageService>(() => new ImageService(), true);

        public static ImageService Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion

        private IDictionary<string, Bitmap> _images = new Dictionary<string, Bitmap>();

        #region Ctor

        public ImageService()
        {

        }

        #endregion

        /// <summary>
        /// Возвращает изображение из локального кэша
        /// </summary>
        /// <param name="key">Ключ изображения</param>
        public Bitmap Get(string key)
        {
            Bitmap tmp = null;

            if(!_images.TryGetValue(key,out tmp))
            { // Изображение за всё время игры ещё ни разу не было загружено
                tmp = Load(key); // загружаем картинку
                _images.Add(key, tmp); // записываем в кэш
            }

            return tmp; // возвращаем изображение из кэша
        }

        /// <summary>
        /// Загружает изображение из файла
        /// </summary>
        /// <param name="key">Ключ изображения</param>
        private Bitmap Load(string key)
        {
            var path = $"resources/{key}.png";
            return new Bitmap(Image.FromFile(path, true));
        }

    }

}
