using System;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign
{
    // 增加事件的使用规则后，这里可以全部删掉了
    //public class Event<T> where T : Event<T>
    //{
    //    private static Action mOnEvent;

    //    public static void Register(Action onEvent)
    //    {
    //        mOnEvent += onEvent;
    //    }

    //    public static void UnRegister(Action onEvent)
    //    {
    //        mOnEvent -= onEvent;
    //    }

    //    public static void Trigger()
    //    {
    //        // mOnEvent 如果不为空，就调用
    //        mOnEvent?.Invoke();
    //    }
    //}
}
