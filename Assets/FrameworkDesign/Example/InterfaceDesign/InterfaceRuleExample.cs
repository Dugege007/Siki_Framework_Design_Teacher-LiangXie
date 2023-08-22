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
    public class InterfaceRuleExample : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDoSomeThing1
        {
            //public CanDoEverything CanDoEverything { get; }
            CanDoEverything IHaveEvrything.CanDoEverything { get; } = new CanDoEverything();
        }

        public class OnlyCanDo23 : ICanDoSomeThing2, ICanDoSomeThing3
        {
            //public CanDoEverything CanDoEverything { get; }
            CanDoEverything IHaveEvrything.CanDoEverything { get; } = new CanDoEverything();
        }

        private void Start()
        {
            var onlyCanDo1 = new OnlyCanDo1();
            // 如果想调用Do其他事情，可以像下面一样写
            //IHaveEvrything onlyCanDo1 = new OnlyCanDo1();
            onlyCanDo1.DoSomething1();

            var onlyCanDo23 = new OnlyCanDo23();
            onlyCanDo23.DoSomething2();
            onlyCanDo23.DoSomething3();
        }
    }

    public class CanDoEverything
    {
        public void DoSomething1()
        {
            Debug.Log("DoSomething1");
        }

        public void DoSomething2()
        {
            Debug.Log("DoSomething2");
        }

        public void DoSomething3()
        {
            Debug.Log("DoSomething3");
        }
    }

    public interface IHaveEvrything
    {
        CanDoEverything CanDoEverything { get; }
    }

    public interface ICanDoSomeThing1 : IHaveEvrything
    {

    }

    public interface ICanDoSomeThing2 : IHaveEvrything
    {

    }

    public interface ICanDoSomeThing3 : IHaveEvrything
    {

    }

    // 针对上方的 ICanDoSomeThing1 接口，做一个静态扩展
    // 扩展是 C# 的一个语法特性
    public static class ICanDoSomething1Extension
    {
        public static void DoSomething1(this ICanDoSomeThing1 self)
        {
            self.CanDoEverything.DoSomething1();
        }
    }

    public static class ICanDoSomething2Extension
    {
        public static void DoSomething2(this ICanDoSomeThing2 self)
        {
            self.CanDoEverything.DoSomething2();
        }
    }

    public static class ICanDoSomething3Extension
    {
        public static void DoSomething3(this ICanDoSomeThing3 self)
        {
            self.CanDoEverything.DoSomething3();
        }
    }
}
