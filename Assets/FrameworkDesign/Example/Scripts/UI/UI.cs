using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public class UI : MonoBehaviour,IController
    {
        private void Start()
        {
            //GamePassEvent.Register(OnGamePass);
            this.RegisterEvent<GamePassEvent>(OnGamePass);
        }

        private void OnGamePass(GamePassEvent e)
        {
            // 交互逻辑
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            //GamePassEvent.UnRegister(OnGamePass);
            this.UnRegisterEvent<GamePassEvent>(OnGamePass);
        }

        public IArchitecture GetArchiteccture()
        {
            return PointGame.Interface;
        }
    }
}
