using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public interface IAchievementSystem : ISystem
    {

    }

    public class AchievementItem
    {
        public string Name { get; set; }
        public Func<bool> ChekComplete { get; set; }
        public bool Unlocked { get; set; }
    }

    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        private List<AchievementItem> mItems = new List<AchievementItem>();
        private bool mMissed = false;
        protected override void OnInit()
        {
            this.RegisterEvent<OnMissEvent>(e =>
            {
                mMissed = true;
            });

            this.RegisterEvent<GameStartEvent>(e =>
            {
                mMissed = false;
            });

            mItems.Add(new AchievementItem()
            {
                Name = "百分成就",
                ChekComplete = () => this.GetModel<IGameModel>().BestScore.Value > 100
            });

            mItems.Add(new AchievementItem()
            {
                Name = "手残",
                ChekComplete = () => this.GetModel<IGameModel>().Score.Value < 0
            });

            mItems.Add(new AchievementItem()
            {
                Name = "零失误成就",
                ChekComplete = () => !mMissed
            });

            // 成就系统一般是持久化的，所以如果需要持久化，也是在这个时机进行，可以让 Unlocked 变成 BindableProperty

            // 每次通关时
            this.RegisterEvent<GamePassEvent>(async e =>
            {
                // 延迟调用
                // 确保其他计算结束之后再进行下列操作
                await Task.Delay(TimeSpan.FromSeconds(0.1f));

                foreach (var item in mItems)
                {
                    if (item.Unlocked == false && item.ChekComplete())
                    {
                        item.Unlocked = true;
                        Debug.Log("解锁成就：" + item.Name);
                    }
                }
            });
        }
    }
}
