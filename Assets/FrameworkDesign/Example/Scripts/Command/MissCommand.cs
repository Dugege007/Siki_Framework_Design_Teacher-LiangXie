using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public class MissCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            if (gameModel.Life.Value > 0)
            {
                gameModel.Life.Value--;
            }
            else
            {
                this.SendEvent<OnMissEvent>();
            }
        }
    }
}
