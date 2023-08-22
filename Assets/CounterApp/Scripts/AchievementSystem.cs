using FrameworkDesign;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace CounterApp
{
    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        public IArchitecture Architeccture { get; set; }

        // 这里实现成就系统的逻辑
        protected override void OnInit()
        {
            // 获取点击次数
            var counterModel = this.GetModel<ICounterModel>();
            // 上一次的数字
            var previousCount = counterModel.Count.Value;

            bool count9Unlock = false;
            bool count18Unlock = false;
            // 成就是否解锁还可以用 storage 存储起来

            // 监听一下点击次数的变更事件
            counterModel.Count.RegisterOnValueChanged(newCount =>
            {
                if (previousCount < 9 && newCount >= 9 && !count9Unlock)
                {
                    count9Unlock = true; Debug.Log("解锁点击 9 次成就！");
                }
                else if (previousCount < 18 && newCount >= 18 && !count18Unlock)
                {
                    count18Unlock = true; Debug.Log("解锁点击 18 次成就！");
                }
                previousCount = newCount;
            });
        }
    }
}
