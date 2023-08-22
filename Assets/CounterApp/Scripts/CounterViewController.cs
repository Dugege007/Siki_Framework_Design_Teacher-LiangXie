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

        //public IArchitecture Architeccture { get; set; } = CounterApp.Interface;

        private void Start()
        {
            //mCounterModel = CounterApp.Get<ICounterModel>();
            //mCounterModel = Architeccture.GetModel<ICounterModel>();
            mCounterModel = this.GetModel<ICounterModel>();

            // 订阅委托
            mCounterModel.Count.OnValueChanged += OnCountChanged;

            // 运行开始要更新一下数据
            OnCountChanged(mCounterModel.Count.Value);

            transform.Find("AddBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑 View -> Model
                //new AddCountCommand().Execute();
                this.SendCommand<AddCountCommand>();
            });

            transform.Find("SubBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑
                //new SubCountCommand().Execute();
                this.SendCommand<SubCountCommand>();
            });
        }

        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
            //transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        }

        private void OnDestroy()
        {
            // 取消订阅
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }

        IArchitecture IBelongToArchitecture.GetArchiteccture()
        {
            return CounterApp.Interface;
        }

        //private void Start()
        //{
        //    // 订阅委托
        //    //CounterModel.onCountChanged += OnCountChanged;
        //    // 注册事件
        //    //OnCountChangedEvent.Register(OnCountChanged);
        //    // 使用委托（回调）或者事件，会比主动调用表现逻辑更合适，可以显著减少代码量
        //    // 如果是单个数值变化，用委托方式更合适；如果是颗粒度较大的更新，用事件比较合适

        //    // 订阅可绑定属性中定义的更新委托
        //    //CounterModel.Count.OnValueChanged += OnCountChanged;
        //    //CounterModel.Instance.Count.OnValueChanged += OnCountChanged;

        //    // 运行开始要更新一下数据
        //    //UpdateView();
        //    //OnCountChanged(CounterModel.Count.Value);
        //    //OnCountChanged(CounterModel.Instance.Count.Value);

        //    mCoumterModel = CounterApp.Get<CounterModel>();

        //    transform.Find("AddBtn").GetComponent<Button>().onClick.AddListener(() =>
        //    {
        //        // 交互逻辑 View -> Model
        //        //CounterModel.Count++;
        //        //CounterModel.Count.Value++;
        //        new AddCountCommand().Execute();

        //        // 表现逻辑 Model -> View
        //        //UpdateView();
        //    });

        //    transform.Find("SubBtn").GetComponent<Button>().onClick.AddListener(() =>
        //    {
        //        // 交互逻辑
        //        //CounterModel.Count--;
        //        //CounterModel.Count.Value--;
        //        new SubCountCommand().Execute();

        //        // 表现逻辑
        //        //UpdateView();
        //    });
        //}


        //private void UpdateView()
        //{
        //    transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        //}


        //private void OnDestroy()
        //{
        //    // 取消订阅
        //    //CounterModel.onCountChanged -= OnCountChanged;
        //    // 取消注册
        //    //OnCountChangedEvent.UnRegister(OnCountChanged);

        //    // 取消订阅
        //    //CounterModel.Count.OnValueChanged -= OnCountChanged;
        //    //CounterModel.Instance.Count.OnValueChanged -= OnCountChanged;
        //}
    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    // Model
    //public class CounterModel : Singleton<CounterModel>
    public class CounterModel : AbstractModel, ICounterModel
    {
        //private CounterModel() { }
        //public CounterModel()
        //{
        //    //Count.Value = PlayerPrefs.GetInt("COUNTER_COUNT", 0);

        //    // 依赖注入
        //    //var storage = CounterApp.Get<IStorage>();   // 这样访问会导致堆栈溢出，因为 CounterApp.Get 有可能再次引发 Architecture 的初始化

        //    //Count.OnValueChanged += count => { PlayerPrefs.SetInt("COUNTER_COUNT", count); };
        //}

        public BindableProperty<int> Count { get; } = new BindableProperty<int>() { Value = 0 };
        //public IArchitecture Architeccture { get; set; }

        // 增加一个生命周期方法 Init() 来避免单例调用造成的堆栈溢出的问题
        //public void Init()
        //{
        //    var storage = Architeccture.GetUtility<IStorage>(); // 这样访问可以避免堆栈溢出，为了绕开单例的初始化要做很多事情
        //    Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

        //    Count.OnValueChanged += count => { storage.SaveInt("COUNTER_COUNT", count); };
        //}

        protected override void OnInit()
        {
            //var storage = GetArchiteccture().GetUtility<IStorage>();
            var storage = this.GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

            Count.OnValueChanged += count => { storage.SaveInt("COUNTER_COUNT", count); };
        }
    }

    //public static class CounterModel_Old
    //{
    //    //private static int mCounter = 0;

    //    // 通过委托通知 View 实现表现逻辑
    //    //public static Action<int> onCountChanged;

    //    //public static int Count
    //    //{
    //    //    //get { return mCounter; }
    //    //    get => mCounter;
    //    //    set
    //    //    {
    //    //        if (value != mCounter)
    //    //        {
    //    //            mCounter = value;
    //    //            OnCountChangedEvent.Trigger();

    //    //            //onCountChanged?.Invoke(value);
    //    //        }
    //    //    }
    //    //}

    //    // 使用可绑定属性定义需要更新的数据

    //    public static BindableProperty<int> Count = new BindableProperty<int>() { Value = 0 };
    //}

    //public class OnCountChangedEvent : Event<OnCountChangedEvent>
    //{

    //}
}
