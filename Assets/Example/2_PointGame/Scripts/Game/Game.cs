using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：游戏管理
 * 
 * View 层
 * 判断游戏结束条件
 * 
 * 创建时间：
 */

namespace QFramework.Example
{
    public class Game : MonoBehaviour, IController
    {
        private GameObject mEnemys;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            mEnemys = transform.Find("Enemys").gameObject;
        }

        private void Start()
        {
            // UnRegisterWhenGameObjectDestroyed 使用这种方式不用在 OnDestroy 中再注销一遍了
            this.RegisterEvent<GameStartEvent>(OnGameStart).UnRegisterWhenDestroyed(gameObject);
            this.RegisterEvent<OnCountDownEndEvent>(OnGameOver).UnRegisterWhenDestroyed(gameObject);
            this.RegisterEvent<GamePassEvent>(OnGamePass).UnRegisterWhenDestroyed(gameObject);
        }

        private void OnGameStart(GameStartEvent e)
        {
            mEnemys.SetActive(true);

            foreach (Transform enemy in mEnemys.transform)
            {
                enemy.gameObject.SetActive(true);
            }
        }

        private void OnGamePass(GamePassEvent obj)
        {
            mEnemys.SetActive(false);
        }

        private void OnGameOver(OnCountDownEndEvent obj)
        {
            mEnemys.SetActive(false);
        }
    }
}
