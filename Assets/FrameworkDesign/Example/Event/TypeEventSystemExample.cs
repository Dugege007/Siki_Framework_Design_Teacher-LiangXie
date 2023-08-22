using System;
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
    public class TypeEventSystemExample : MonoBehaviour
    {
        // 创建一个事件系统
        private TypeEventSystem mTypeEventSystem = new TypeEventSystem();

        private void Start()
        {
            // 使用“传统方式”监听事件A
            mTypeEventSystem.Register<EventA>(OnEvent);

            // 新添加的根据 TypeEventSystem 框架中的写法
            // 可以用委托的方式注册
            mTypeEventSystem.Register<EventB>(b =>
            {
                Debug.Log("OnEvent B: " + b.ParamB);

                // 注册完之后，可以使用扩展方法，将当前 gameObject 传入
                // 表示当前游戏物体销毁时会自动注销前面注册的事件
                // 非常方便！
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            mTypeEventSystem.Register<IEventGroup>(e =>
            {
                // 输出事件类型
                Debug.Log("IEventGroup: " + e.GetType());

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }

            if (Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send(new EventB()
                {
                    ParamB = 123
                });
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }

        private void OnEvent(EventA obj)
        {
            Debug.Log("OnEvent A");
        }

        private void OnDestroy()
        {
            // 使用“传统方式”监听，需要写注销方法
            mTypeEventSystem.UnRegister<EventA>(OnEvent);
            mTypeEventSystem = null;
        }
    }

    public struct EventA
    {

    }

    public struct EventB
    {
        public int ParamB;
    }

    public interface IEventGroup
    {

    }

    public struct EventC : IEventGroup
    {

    }

    public struct EventD : IEventGroup
    {

    }

}
