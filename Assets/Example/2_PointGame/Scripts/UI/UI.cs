using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class UI : MonoBehaviour, IController
    {
        private GameObject mGameStartPanel;
        private GameObject mGamePanel;
        private GameObject mGamePassPanel;
        private GameObject mGameOverPanel;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            mGameStartPanel = transform.Find("Canvas/GameStartPanel").gameObject;
            mGamePanel = transform.Find("Canvas/GamePanel").gameObject;
            mGamePassPanel = transform.Find("Canvas/GamePassPanel").gameObject;
            mGameOverPanel = transform.Find("Canvas/GameOverPanel").gameObject;
        }

        private void Start()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);
            this.RegisterEvent<GamePassEvent>(OnGamePass);
            this.RegisterEvent<OnCountDownEndEvent>(OnGameOver);
            this.RegisterEvent<ReStartEvent>(OnReStart).UnRegisterWhenDestroyed(gameObject);  // 使用这种方式不用在 OnDestroy 中再注销一遍了
        }


        private void OnGameStart(GameStartEvent e)
        {
            mGamePanel.SetActive(true);
        }

        private void OnGamePass(GamePassEvent e)
        {
            mGamePassPanel.SetActive(true);
            mGamePanel.SetActive(false);
        }

        private void OnGameOver(OnCountDownEndEvent e)
        {
            mGameOverPanel.SetActive(true);
            mGamePanel.SetActive(false);
        }

        private void OnReStart(ReStartEvent e)
        {
            // 交互逻辑
            mGameStartPanel.SetActive(true);

        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEvent>(OnGameStart);
            this.UnRegisterEvent<GamePassEvent>(OnGamePass);
            this.UnRegisterEvent<OnCountDownEndEvent>(OnGameOver);
        }
    }
}
