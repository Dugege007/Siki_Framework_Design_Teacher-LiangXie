using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 
 * View Controller 层
 * 
 * 创建时间：
 */

namespace QFramework.Example
{
    // View Controller 层
    public class Enemy : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            gameObject.SetActive(false);

            // 表现逻辑
            this.SendCommand<KillEnemyCommand>();
        }
    }
}