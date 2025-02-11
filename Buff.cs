using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIEIE_Project
{
    internal class Buff
    {
        private GameManager gameManager;
        public Buff(Action<GameManager> onEnd, GameManager gameManager, int duration)
        {
            int nowTurn = gameManager.TurnCount;
            EndTurn = nowTurn + duration;
            this.gameManager = gameManager;
            onEndBuff = onEnd;

            gameManager.onChangeTurnCount += CheckBuffEnd;
        }

        public event Action<GameManager> onEndBuff;
        public int EndTurn {  get; set; }
        public void CheckBuffEnd()
        {
            if (gameManager.TurnCount >= EndTurn || gameManager.TurnCount == 0)
            {
                onEndBuff?.Invoke(gameManager);
                gameManager.onChangeTurnCount -= CheckBuffEnd;
            }
        }
    }
}
