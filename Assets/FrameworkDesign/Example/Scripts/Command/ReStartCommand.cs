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
    public class ReStartCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<ReStartEvent>();
        }
    }
}
