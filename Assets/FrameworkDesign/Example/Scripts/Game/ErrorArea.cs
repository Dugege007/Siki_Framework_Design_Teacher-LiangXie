using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：背景（点错区域）
 * 创建时间：
 */

namespace QFramework.Example
{
    public class ErrorArea : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
            Debug.Log("点错了");
        }
    }
}
