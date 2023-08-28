using System;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    [Serializable]
    public class IntProperty : BindableProperty<int>
    {
        public IntProperty(int value = 0) : base(value)
        {

        }
    }

    public class BindablePropertyExample : MonoBehaviour
    {
        public IntProperty Age = new IntProperty(10);
        public IntProperty Counter = new IntProperty();

        private void Start()
        {
            Age.Register(age =>
            {
                Debug.Log(nameof(age) + ": " + age);

                Counter.Value = 10 * age;
            }).UnRegisterWhenDestroyed(gameObject);

            Counter.RegisterWithInitValue(counter =>
            {
                Debug.Log(nameof(counter) + ": " + counter);
            }).UnRegisterWhenDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Age.Value++;
            }
        }
    }
}
