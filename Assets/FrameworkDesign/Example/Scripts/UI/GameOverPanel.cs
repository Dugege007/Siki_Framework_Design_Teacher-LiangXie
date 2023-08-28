using UnityEngine;
using UnityEngine.UI;
using QFramework;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public class GameOverPanel : MonoBehaviour, IController
    {
        private Button mBackBtn;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            mBackBtn = transform.Find("InfoPanel/BackBtn").GetComponent<Button>();
        }

        private void Start()
        {
            mBackBtn.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);

                // 使用命令
                this.SendCommand<ReStartCommand>();
            });
        }
    }
}
