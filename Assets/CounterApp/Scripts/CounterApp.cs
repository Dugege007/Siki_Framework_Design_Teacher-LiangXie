using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            // System 层
            RegisterSystem<IAchievementSystem>(new AchievementSystem());

            // Model 层
            RegisterModel<ICounterModel>(new CounterModel());

            // Utility （工具、基础设施）层
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}
