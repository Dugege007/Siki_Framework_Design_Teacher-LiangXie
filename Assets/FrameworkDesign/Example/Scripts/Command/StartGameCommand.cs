
/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class StartGameCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            // 重置数据
            gameModel.KillCount.Value = 0;
            gameModel.Score.Value = 0;

            this.SendEvent<GameStartEvent>();
        }
    }
}
