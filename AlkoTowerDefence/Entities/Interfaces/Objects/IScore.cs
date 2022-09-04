using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkoTowerDefence.Interfaces
{
    public interface IScore : IPoint
    {
        int ScoreKill { get; set; }
        int Coins { get; set; }
    }
}
