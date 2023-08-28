using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：IOC容器
 * 创建时间：
 */

namespace QFramework.Example
{
    public class IOCExample : MonoBehaviour
    {
        private void Start()
        {
            // 创建一个 IOC 容器
            var container = new IOCContainer();

            // 注册一个蓝牙管理器的实例
            container.Register<IBluetoothManager>(new BluetoothManager());  // 程序要依赖于抽象接口，不要依赖于具体实现。这里符合依赖倒置原则
            // 比如要更改实现，只需要 new 一个其他的实现 IBluetoothManager 接口的实例即可

            // 根据类型获取蓝牙管理器实例
            var bluetoothManager = container.Get<IBluetoothManager>();

            // 连接蓝牙
            bluetoothManager.Connect();
        }
    }

    public interface IBluetoothManager
    {
        void Connect();

    }

    public class BluetoothManager:IBluetoothManager
    {
        public void Connect()
        {
            Debug.Log("蓝牙连接成功！");
        }
    }
}
