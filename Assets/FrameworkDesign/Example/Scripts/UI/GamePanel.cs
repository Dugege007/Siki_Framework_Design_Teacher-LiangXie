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
    public class GamePanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        private ICountDownSystem mCountDownSystem;

        private Text mCurrentScoreText;
        private Text mLifeText;
        private Text mGoldText;
        private Text mRemainTimeText;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            mCountDownSystem = this.GetSystem<ICountDownSystem>();
            mGameModel = this.GetModel<IGameModel>();

            mCurrentScoreText = transform.Find("InfoPanel/CurrentScoreText").GetComponent<Text>();
            mLifeText = transform.Find("InfoPanel/LifeText").GetComponent<Text>();
            mGoldText = transform.Find("InfoPanel/GoldText").GetComponent<Text>();
            mRemainTimeText = transform.Find("InfoPanel/RemainTimeText").GetComponent<Text>();
        }

        private void Start()
        {
            mGameModel.Score.Register(OnScoreValueChanged);
            mGameModel.Life.Register(OnLifeValueChanged);
            mGameModel.Gold.Register(OnGoldValueChanged);

            OnScoreValueChanged(mGameModel.Score.Value);
            OnLifeValueChanged(mGameModel.Life.Value);
            OnGoldValueChanged(mGameModel.Gold.Value);
        }

        private void Update()
        {
            // 每 20 帧更新一次
            if (Time.frameCount % 20 == 0)
            {
                mRemainTimeText.text = mCountDownSystem.CurrentRemainSeconds + "s";

                // 计时
                mCountDownSystem.Update();
            }
        }

        private void OnScoreValueChanged(int score)
        {
            mCurrentScoreText.text = "分数：" + score;
        }

        private void OnLifeValueChanged(int life)
        {
            mLifeText.text = "生命：" + life;
        }

        private void OnGoldValueChanged(int gold)
        {
            mGoldText.text = "金币：" + gold;
        }

        private void OnDestroy()
        {
            mGameModel.Score.UnRegister(OnScoreValueChanged);
            mGameModel.Life.UnRegister(OnLifeValueChanged);
            mGameModel.Gold.UnRegister(OnGoldValueChanged);

            mGameModel = null;
            mCountDownSystem = null;
        }
    }
}
