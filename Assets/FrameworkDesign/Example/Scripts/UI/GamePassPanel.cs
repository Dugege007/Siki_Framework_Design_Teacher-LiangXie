using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace QFramework.Example
{
    public class GamePassPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private ICountDownSystem mCountDownSystem;

        private Text mRemainTimeText;
        private Text mFinalScoreText;
        private Text mBestScoreText;
        private Button mBackBtn;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            mCountDownSystem = this.GetSystem<ICountDownSystem>();
            mGameModel = this.GetModel<IGameModel>();

            mRemainTimeText = transform.Find("InfoPanel/RemainTimeText").GetComponent<Text>();
            mFinalScoreText = transform.Find("InfoPanel/FinalScoreText").GetComponent<Text>();
            mBestScoreText = transform.Find("InfoPanel/BestScoreText").GetComponent<Text>();
            mBackBtn = transform.Find("InfoPanel/BackBtn").GetComponent<Button>();
        }

        private void Start()
        {
            mRemainTimeText.text = "剩余时间：" + mCountDownSystem.CurrentRemainSeconds + "s";
            mFinalScoreText.text = "分数：" + mGameModel.Score.Value;
            mBestScoreText.text = "最高分数：" + mGameModel.BestScore.Value;

            mBackBtn.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);

                // 使用命令
                this.SendCommand<ReStartCommand>();
            });
        }
    }
}
