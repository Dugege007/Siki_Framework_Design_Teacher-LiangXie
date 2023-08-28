using System;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class GlobalEventExample : MonoBehaviour, 
        IOnEvent<GlobalEventExample.GlobalEventA>,
        IOnEvent<GlobalEventExample.GlobalEventB>
    {
        public struct GlobalEventA
        {

        }

        public struct GlobalEventB
        {

        }

        private void Start ()
        {
            TypeEventSystem.Global.Register<GlobalEventA>(OnGlobalEventA)
                .UnRegisterWhenDestroyed(gameObject);

            this.RegisterEvent<GlobalEventA>();
            this.RegisterEvent<GlobalEventB>();
        }

        private void OnGlobalEventA(GlobalEventA e)
        {
            Debug.Log(e.ToString());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TypeEventSystem.Global.Send<GlobalEventA>();
            }

            if (Input.GetMouseButtonDown(1))
            {
                TypeEventSystem.Global.Send<GlobalEventB>();
            }
        }

        public void OnEvent(GlobalEventA e)
        {
            Debug.Log(e.ToString());
        }

        public void OnEvent(GlobalEventB e)
        {
            Debug.Log(e.ToString());
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GlobalEventA>();
            this.UnRegisterEvent<GlobalEventB>();
        }

    }
}
