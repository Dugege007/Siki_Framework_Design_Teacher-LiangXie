using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public interface IGameModel:IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BestScore { get; }
    }

    //public class GameModel : Singleton<GameModel>
    public class GameModel : AbstractModel, IGameModel
    {
        //private GameModel() { }

        BindableProperty<int> IGameModel.KillCount { get; } = new BindableProperty<int>() { Value = 0 };

        BindableProperty<int> IGameModel.Gold { get; } = new BindableProperty<int>() { Value = 0 };

        BindableProperty<int> IGameModel.Score { get; } = new BindableProperty<int>() { Value = 0 };

        BindableProperty<int> IGameModel.BestScore { get; } = new BindableProperty<int>() { Value = 0 };

        protected override void OnInit()
        {
            // 以后这里可以写存储的代码
        }
    }
}
