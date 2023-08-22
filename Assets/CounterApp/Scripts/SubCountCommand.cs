using FrameworkDesign;

/*
 * 创建人：杜
 * 功能说明：减少命令实现
 * 创建时间：
 */

namespace CounterApp
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value--;
        }
    }
}
