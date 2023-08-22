using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * 创建人：杜
 * 功能说明：
 * 
 * View Controller 层
 * 
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    // View Controller 层
    public class Enemy : MonoBehaviour, IController
    {
        IArchitecture IBelongToArchitecture.GetArchiteccture()
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