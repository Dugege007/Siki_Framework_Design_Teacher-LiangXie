using FrameworkDesign;

/*
 * 创建人：杜
 * 功能说明：增加命令实现
 * 创建时间：
 */

namespace CounterApp
{
    // 使用结构体，效率更高一点
    //public struct AddCountCommand : ICommand
    // 结构体只能继承接口，所以下面修改要改成类
    public class AddCountCommand : AbstractCommand
    {
        //public void Execute()
        //{
        //    //CounterModel.Instance.Count.Value--;
        //    CounterApp.Get<ICounterModel>().Count.Value++;
        //}

        protected override void OnExecute()
        {
            //CounterModel.Instance.Count.Value++;
            //CounterApp.Get<ICounterModel>().Count.Value++;
            
            //GetArchiteccture().GetModel<ICounterModel>().Count.Value++; // 不用走单例那样的流程了
            this.GetModel<ICounterModel>().Count.Value++;
        }
    }
}
