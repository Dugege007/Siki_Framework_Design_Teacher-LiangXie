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
    public class Enemy : MonoBehaviour,IController
    {
        IArchitecture IBelongToArchitecture.GetArchiteccture()
        {
            return PointGame.Interface;
        }

        private void OnMouseDown()
        {
            Destroy(gameObject);

            // 表现逻辑
            //new KillEnemyCommand().Execute();
            this.SendCommand<KillEnemyCommand>();
        }
    }

    //public class Enemy_Old : MonoBehaviour
    //{
    //    // 通过事件来通知
    //    //public GameObject GmePassPanel;
    //    // 数据在 GameModel 中管理
    //    //public static int mKilledEnemyCount = 0;

    //    private void OnMouseDown()
    //    {
    //        // 获取场景内所有的顶端节点游戏物体
    //        //SceneManager.GetActiveScene().GetRootGameObjects();

    //        Destroy(gameObject);

    //        //KilledAnEnemyEvent.Trigger();
    //        // 表现逻辑
    //        GameModel.KillCount.Value++;
    //    }

    //    //// 游戏结束条件不应该写在这里，Enemy 不应该负责判断游戏结束条件，这样不符合逻辑，不是面向对象的，不是对真实世界的抽象描述
    //    //private void GamePass()
    //    //{
    //    //    // 通过事件来通知
    //    //    //GmePassPanel.SetActive(true);

    //    //    // 触发游戏结束事件
    //    //    GamePassEvent.Trigger();
    //    //}
    //}
}