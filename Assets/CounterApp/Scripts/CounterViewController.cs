using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;
using System.Runtime.InteropServices;

/*
 * 创建人：杜
 * 功能说明：计数器的简单实现
 * 
 * 使用MVC框架
 * 
 * 创建时间：
 */

namespace CounterApp
{
    // View + Controller
    public class CounterViewController : MonoBehaviour, IController
    {
        private ICounterModel mCounterModel;

        private void Start()
        {
            mCounterModel = this.GetModel<ICounterModel>();

            // 订阅委托
            mCounterModel.Count.RegisterOnValueChanged(OnCountChanged);

            // 运行开始要更新一下数据
            OnCountChanged(mCounterModel.Count.Value);

            transform.Find("AddBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑 View -> Model
                this.SendCommand<AddCountCommand>();
            });

            transform.Find("SubBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑
                this.SendCommand<SubCountCommand>();
            });
        }

        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            // 取消订阅
            mCounterModel.Count.UnRegisterOnValueChanged(OnCountChanged);
        }

        IArchitecture IBelongToArchitecture.GetArchiteccture()
        {
            return CounterApp.Interface;
        }
    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    // Model
    public class CounterModel : AbstractModel, ICounterModel
    {
        public BindableProperty<int> Count { get; } = new BindableProperty<int>() { Value = 0 };

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

            Count.RegisterOnValueChanged(count => { storage.SaveInt("COUNTER_COUNT", count); });
        }
    }
}
