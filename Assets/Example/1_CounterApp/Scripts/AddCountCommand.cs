using QFramework;

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
        protected override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value++;
        }
    }
}
