
/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class ReStartCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<ReStartEvent>();
        }
    }
}
