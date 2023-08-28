using System;
using QFramework;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

namespace FrameworkDesign.Example
{
    public interface ICountDownSystem : ISystem
    {
        int CurrentRemainSeconds { get; }

        // 在外部获取 Update
        void Update();
    }

    public class CountDownSystem : AbstractSystem, ICountDownSystem
    {
        public int CurrentRemainSeconds => 10 - (int)(DateTime.Now - mGameStartTime).TotalSeconds;

        private DateTime mGameStartTime { get; set; }

        private bool mStarted;

        public void Update()
        {
            if (mStarted)
            {
                if (DateTime.Now - mGameStartTime > TimeSpan.FromSeconds(10))
                {
                    this.SendEvent<OnCountDownEndEvent>();
                    mStarted = false;
                }
            }
        }

        protected override void OnInit()
        {
            this.RegisterEvent<GameStartEvent>(e =>
            {
                mStarted = true;
                mGameStartTime = DateTime.Now;
            });

            this.RegisterEvent<GamePassEvent>(e =>
            {
                mStarted = false;
            });
        }
    }
}
