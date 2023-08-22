using System;

/*
 * 创建人：杜
 * 功能说明：BindableProperty 可绑定的属性的简单实现
 * 
 * 用于可比较的值的更新
 * 数据 + 数据变更事件 的合体，既存储数据，又充当C#中的属性角色，也可以让别的地方监听它数据的变更事件，这样会大量减少样板代码
 * 如再加个金币功能就要写一套一模一样的代码，比如增加一个 mGold、OnGoldChanged 委托、Gold 的数值比较逻辑，这种样板代码
 * 所以很多框架都会用代码生成或者泛型方式去减少样板代码的编写时间
 * 
 * 自底向上（如子节点通知父节点）的逻辑关系可以使用委托或事件，自顶向下（如父节点调用子节点）的逻辑关系可以使用方法调用
 * 
 * 创建时间：
 */

namespace FrameworkDesign
{
    // IEquatable 值可比较的
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue = default(T);
        public T Value
        {
            get => mValue;

            set
            {
                if (!value.Equals(mValue))
                {
                    mValue = value;

                    OnValueChanged?.Invoke(mValue);
                    // 自身数值发生变化时，通知观察者更新界面
                    // 数值驱动
                }
            }
        }

        public Action<T> OnValueChanged;
    }
}
