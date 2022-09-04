using AlkoTowerDefence.Interfaces;
using System.Windows.Forms;

namespace AlkoTowerDefence
{
    /// <summary>
    /// Представленеи сервиса контроллера (мыши)
    /// </summary>
    public class ControllService
    {

        private IPlayer currentPlayer;

        public void Init (IPlayer currentPlayer)
        {
            this.currentPlayer = currentPlayer;
        }

        public void UpdatePositionPlayer(MouseEventArgs e)
        {
            currentPlayer.X = e.X - currentPlayer.Width / 2;
            currentPlayer.Y = e.Y - currentPlayer.Height / 2;
        }
    }
}
