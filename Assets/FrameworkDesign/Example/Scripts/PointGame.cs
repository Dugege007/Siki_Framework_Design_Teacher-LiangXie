
/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            // 可以很方便地在这里查阅游戏中的模块都有哪些
            // 程序在初始化时顺序可能与下方代码不一致
            // 但是我们下方代码按照架构层次来排序

            // System 层
            RegisterSystem<IScoreSystem>(new ScoreSystem());
            RegisterSystem<ICountDownSystem>(new CountDownSystem());
            RegisterSystem<IAchievementSystem>(new AchievementSystem());

            // Model 层
            RegisterModel<IGameModel>(new GameModel());


            // Utility 层
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}
