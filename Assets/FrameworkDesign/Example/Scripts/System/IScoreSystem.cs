using UnityEngine;
using QFramework;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public interface IScoreSystem : ISystem
    {

    }

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();

            // 监听事件
            this.RegisterEvent<GamePassEvent>(e =>
            {
                var countDownSystem = this.GetSystem<ICountDownSystem>();
                var timeScore = countDownSystem.CurrentRemainSeconds * 10;
                gameModel.Score.Value += timeScore;

                if (gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    gameModel.BestScore.Value = gameModel.Score.Value;
                    Debug.Log("新纪录");
                }
            });

            this.RegisterEvent<OnKillEnemyEvent>(e =>
            {
                gameModel.Score.Value += 10;
                //Debug.Log("得分: 10");
                Debug.Log("当前分数: " + gameModel.Score.Value);
            });

            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
                //Debug.Log("得分: -5");
                Debug.Log("当前分数: " + gameModel.Score.Value);
            });
        }
    }
}
