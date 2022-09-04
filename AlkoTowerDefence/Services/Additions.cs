using System.Collections.Generic;

namespace AlkoTowerDefence
{

    public static class Additions
    {
        /// <summary>
        /// Добавление коллекции
        /// </summary>
        public static IEnumerable<T> Safe<T>(this ICollection<T> collection)
        {
            var tmp = (IList<T>)collection;
            for (int i = tmp.Count - 1; i >= 0; i--)
            {
                yield return tmp[i];
            }
        }
    }
}
