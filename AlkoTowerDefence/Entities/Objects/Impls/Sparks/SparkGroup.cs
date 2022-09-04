using System;
using System.Collections.Generic;

namespace AlkoTowerDefence.Objects
{
    /// <summary>
    /// Представление группы визуальных эффектов
    /// </summary>
    public class SparkGroup : TimedObjectBase
    {

        private static Random random = new Random();

        public IEnumerable<Spark> Sparks { get; }
        private int counter;

        public override bool IsDead
        {
            get
            {
                return counter <= 0;
            }
        }

        public override void Tick()
        {
            this.counter--;

            foreach (var spark in Sparks)
            {
                spark.X1 += spark.DirectionX;
                spark.Y1 += spark.DirectionY;
            }
        }

        public SparkGroup(int x, int y)
        {
            this.X = x;
            this.Y = y;

            this.counter = 50;
            
            this.Sparks = new Spark[]
            {
                new Spark() { X1 = x, Y1 = y, DirectionX = random.Next(12) - 6, DirectionY = random.Next(12) - 6 },
                new Spark() { X1 = x, Y1 = y, DirectionX = random.Next(12) - 6, DirectionY = random.Next(12) - 6 },
                new Spark() { X1 = x, Y1 = y, DirectionX = random.Next(12) - 6, DirectionY = random.Next(12) - 6 }
            };
        }
    }
}
