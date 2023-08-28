using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class InterfaceStructExample : MonoBehaviour
    {
        private void Start()
        {
            // 一般情况下这里是底层代码
            ICustomScript myScript = new MyScript();
            myScript.Start();
            myScript.Update();
            myScript.Destory();
        }
    }

    public interface ICustomScript
    {
        void Start();
        void Update();
        void Destory();
    }

    public abstract class CustomScript : ICustomScript
    {
        void ICustomScript.Start()
        {
            OnStart();
        }

        void ICustomScript.Update()
        {
            OnUpdate();
        }

        void ICustomScript.Destory()
        {
            OnDestroy();
        }

        protected abstract void OnStart();
        protected abstract void OnUpdate();
        protected abstract void OnDestroy();
    }

    public class MyScript : CustomScript
    {
        protected override void OnStart()
        {
            // 这种情况下如果不小心调用了 Start() 就会进入死循环
            // 此时就可以使用接口阉割，这样就不容易访问到父类中的 Start() 了，没有代码提示
            // 如果自己写框架的话，这种方式的代码是很常见的
            Debug.Log("On Start");
        }

        protected override void OnUpdate()
        {
            Debug.Log("On Update");
        }

        protected override void OnDestroy()
        {
            Debug.Log("On Destroy");
        }
    }
}
