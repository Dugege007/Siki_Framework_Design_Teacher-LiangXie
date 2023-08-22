using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public class GameStartPanel : MonoBehaviour,IController
    {
        public IArchitecture GetArchiteccture()
        {
            return PointGame.Interface;
        }

        private void Start()
        {
            transform.Find("StartBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);

                // 使用命令
                //new StartGameCommand().Execute();

                //GetArchiteccture().SendCommand<StartGameCommand>();
                this.SendCommand<StartGameCommand>();
            });
        }
    }

    //public class GameStartPanel_Old : MonoBehaviour
    //{
    //    // 父节点
    //    // 这里直接持有 Enemy 的引用会导致 Game 和 UI 两个模块底层发生交互，需要尽量避免
    //    //public GameObject Enemys;

    //    private void Start()
    //    {
    //        transform.Find("StartBtn").GetComponent<Button>().onClick.AddListener(() =>
    //        {
    //            gameObject.SetActive(false);
    //            //Enemys.SetActive(true);

    //            //GameStartEvent.Trigger();
    //        });
    //    }
    //}
}