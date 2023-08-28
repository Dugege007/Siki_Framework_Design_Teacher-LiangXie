using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：接口阉割示例
 * 
 * 核心技术为接口的显式实现
 * 这种技巧一般会在两种情况下使用：
 * 一种是：接口 - 抽象类 - 实现类 不想被乱调用一些方法时，可以使用接口阉割技术
 * 另一种：接口 - 静态扩展 时，想要通过实现某个接口来获得具体方法的访问权限时，可以使用此技术
 * 
 * 原本的用法是：当需要实现多个签名一致的方法时，可以通过接口的显式声明来区分到底打个方法是属于哪个接口的
 * 
 * 创建时间：
 */

namespace QFramework
{
    public interface ICanSayHello
    {
        void SayHello();
        void SayOther();
    }

    public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
    {
        // 隐试实现
        public void SayHello()
        {
            Debug.Log("Hello");
        }

        // 接口阉割，可以不让其他地方直接调用
        // 显式实现
        void ICanSayHello.SayOther()
        {
            Debug.Log("Other");
        }

        private void Start()
        {
            // 可以直接调用 SayHello()
            SayHello();

            // 显式实现的接口方法不能通过对象直接调用
            // 需要先强转成 ICanSayHello 对象才可以调用 SayOther()
            (this as ICanSayHello).SayOther();
        }
    }
}
