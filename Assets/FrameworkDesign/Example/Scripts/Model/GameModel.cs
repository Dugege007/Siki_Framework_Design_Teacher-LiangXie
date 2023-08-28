using QFramework;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BestScore { get; }
        BindableProperty<int> Life { get; }
    }

    public class GameModel : AbstractModel, IGameModel
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> Gold { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> Score { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> BestScore { get; } = new BindableProperty<int>() { Value = 0 };

        public BindableProperty<int> Life { get; } = new BindableProperty<int>() { Value = 0 };

        protected override void OnInit()
        {
            // 以后这里可以写存储的代码
            var storage = this.GetUtility<IStorage>();

            // 读取存储的数据
            BestScore.Value = storage.LoadInt(nameof(BestScore), 0);
            // 注册事件
            BestScore.Register(v => storage.SaveInt(nameof(BestScore), v));

            Life.Value = storage.LoadInt(nameof(Life), 3);
            Life.Register(v => storage.SaveInt(nameof(Life), v));

            Gold.Value = storage.LoadInt(nameof(Gold), 0);
            Gold.Register(v => storage.SaveInt(nameof(Gold), v));
        }
    }
}
