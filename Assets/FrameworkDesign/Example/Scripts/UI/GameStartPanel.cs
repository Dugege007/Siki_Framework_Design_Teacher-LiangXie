using System;
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
    public class GameStartPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;

        private Button mStartBtn;

        private Text mBestScoreText;
        private Text mLifeText;
        private Text mGoldText;
        private Button mBuyLifeBtn;

        public IArchitecture GetArchiteccture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            mGameModel = this.GetModel<IGameModel>();

            mStartBtn = transform.Find("StartBtn").GetComponent<Button>();

            mBestScoreText = transform.Find("InfoPanel/BestScoreText").GetComponent<Text>();
            mLifeText = transform.Find("InfoPanel/LifeText").GetComponent<Text>();
            mGoldText = transform.Find("InfoPanel/GoldText").GetComponent<Text>();
            mBuyLifeBtn = transform.Find("InfoPanel/BuyLifeBtn").GetComponent<Button>();
        }

        private void Start()
        {
            mStartBtn.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);

                // 使用命令
                this.SendCommand<StartGameCommand>();
            });

            mBuyLifeBtn.onClick.AddListener(() =>
            {
                this.SendCommand<BuyLifeCommand>();
            });

            mGameModel.Life.RegisterOnValueChanged(OnLifeValueChanged);
            mGameModel.Gold.RegisterOnValueChanged(OnGoldValueChanged);

            // 第一次需要调先更新一下
            mBestScoreText.text = "最高分：" + mGameModel.BestScore.Value;
            OnLifeValueChanged(mGameModel.Life.Value);
            OnGoldValueChanged(mGameModel.Gold.Value);
        }

        private void OnLifeValueChanged(int life)
        {
            mLifeText.text = "生命：" + life;
        }

        private void OnGoldValueChanged(int gold)
        {
            if (gold > 0)
            {
                mBuyLifeBtn.gameObject.SetActive(true);
            }
            else
            {
                mBuyLifeBtn.gameObject.SetActive(false);
            }

            mGoldText.text = "金币：" + gold;
        }

        private void OnDestroy()
        {
            mGameModel.Gold.UnRegisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.UnRegisterOnValueChanged(OnLifeValueChanged);
            mGameModel = null;
        }
    }
}