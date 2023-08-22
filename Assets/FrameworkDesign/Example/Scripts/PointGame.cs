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
    public class PointGame : Architecture<PointGame>
    {
        //private static IOCContainer mContainer;

        //private static void  MakeSureContainer()
        //{
        //    if (mContainer == null)
        //    {
        //        mContainer = new IOCContainer();
        //        Init();
        //    }
        //}

        //private static void Init()
        //{
        //    mContainer.Register(new GameModel());
        //}

        //public static T Get<T>()where T : class
        //{
        //    MakeSureContainer();
        //    return mContainer.Get<T>();
        //}
        protected override void Init()
        {
            // 可以很方便地在这里查阅游戏中的模块都有哪些
            Register<IGameModel>(new GameModel());
        }
    }
}
