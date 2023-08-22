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
        //private static IOCContainer mContainer;

        //private static void MakeSureContainer()
        //{
        //    if (mContainer == null)
        //    {
        //        mContainer = new IOCContainer();
        //        Init();
        //    }
        //}

        //private static void Init()
        //{
        //    mContainer.Register(new CounterModel());
        //}

        //public static T Get<T>() where T : class
        //{
        //    MakeSureContainer();
        //    return mContainer.Get<T>();
        //}

        protected override void Init()
        {
            // System 层
            RegisterSystem<IAchievementSystem>(new AchievementSystem());

            // Model 层
            RegisterModel<ICounterModel>(new CounterModel());

            // Utility （工具、基础设施）层
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
            //Register<IStorage>(new EditorPrefsStorage());
        }
    }
}
