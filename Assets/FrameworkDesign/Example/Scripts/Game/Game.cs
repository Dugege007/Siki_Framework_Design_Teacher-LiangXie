using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：游戏管理
 * 
 * View Controller 层
 * 判断游戏结束条件
 * 
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour,IController
    {
        private void Start()
        {
            //GameStartEvent.Register(OnGameStart);
            this.RegisterEvent<GameStartEvent>(OnGameStart);
        }

        private void OnGameStart(GameStartEvent e)
        {
            transform.Find("Enemys").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            //GameStartEvent.UnRegister(OnGameStart);
            this.UnRegisterEvent<GameStartEvent>(OnGameStart);
        }

        public IArchitecture GetArchiteccture()
        {
            return PointGame.Interface;
        }
    }

    //public class Game_Old : MonoBehaviour
    //{
    //    private void Start()
    //    {
    //        //KilledAnEnemyEvent.Register(OnEnemyKilled);
    //        GameModel.KillCount.OnValueChanged += OnEnemyKilled;
    //    }

    //    private void OnEnemyKilled(int killCount)
    //    {
    //        GameModel.KillCount.Value++;
    //        // 通过 BindableProperty 创建的 KillCount 在 Enemy 类中的 OnMouseDown 方法中已经++

    //        //if (GameModel.KillCount.Value == 9)

    //        // Game 为表现层，下方代码放到底层更好，可以放到 KillEnemyCommand 中
    //        if (killCount == 9)
    //        {
    //            // 触发游戏结束事件
    //            //GamePassEvent.Trigger();
    //            // 使用命令
    //            //new PassGameCommand().Execute();
    //        }
    //    }

    //    private void OnGameStart()
    //    {
    //        transform.Find("Enemys").gameObject.SetActive(true);
    //    }

    //    private void OnDestroy()
    //    {
    //        //KilledAnEnemyEvent.UnRegister(OnEnemyKilled);
    //        GameModel.KillCount.OnValueChanged -= OnEnemyKilled;
    //    }
    //}
}
