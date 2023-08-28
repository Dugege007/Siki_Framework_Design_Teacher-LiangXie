using UnityEngine;
using QFramework;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.KillCount.Value++;

            if (Random.Range(0, 10) < 3)
            {
                gameModel.Gold.Value += Random.Range(1, 3);
            }

            this.SendEvent<OnKillEnemyEvent>();

            if (gameModel.KillCount.Value == 9)
            {
                this.SendEvent<GamePassEvent>();
            }
        }
    }
}
