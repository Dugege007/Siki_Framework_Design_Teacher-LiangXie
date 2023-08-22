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
    public class StartGameCommand : AbstractCommand
    {
        //public void Execute()
        //{
        //    GameStartEvent.Trigger();
        //}

        protected override void OnExecute()
        {
            //GameStartEvent.Trigger();
            this.SendEvent<GameStartEvent>();
        }
    }
}
