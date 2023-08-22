/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

using System.Diagnostics;

namespace FrameworkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        //public void Execute()
        //{
        //    //GameModel.Instance.KillCount.Value++;
        //    var gameModel = PointGame.Get<IGameModel>();
        //    gameModel.KillCount.Value++;
        //    //UnityEngine.Debug.Log(gameModel.KillCount.Value);

        //    //if (GameModel.Instance.KillCount.Value == 9)
        //    if (gameModel.KillCount.Value == 9)
        //    {
        //        GamePassEvent.Trigger();
        //        //new PassGameCommand().Execute();
        //    }
        //}

        protected override void OnExecute()
        {
            //var gameModel = PointGame.Get<IGameModel>();
            //var gameModel = GetArchiteccture().GetModel<IGameModel>();
            var gameModel = this.GetModel<IGameModel>();
            gameModel.KillCount.Value++;

            if (gameModel.KillCount.Value == 9)
            {
                //GamePassEvent.Trigger();
                this.SendEvent<GamePassEvent>();
            }
        }
    }
}
