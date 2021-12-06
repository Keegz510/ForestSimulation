using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;

namespace Framework.Maths
{
    public class Timer
    {
        private float timerLength = 2.0f;
        private float timer = 0.0f;

        private bool bLoop = false;
        private Action onTimerCompleteAction = null;

        private ResourceManager manager;

        public Timer(float length, bool loop, Action timerComplete)
        {
            timerLength = length;
            bLoop = loop;
            onTimerCompleteAction = timerComplete;
        }

        public void Update(float deltaTime)
        {
            timer += 1 * deltaTime;

            if(timer >= timerLength)
            {
                CompleteTimer();
            }
        }

        public void RestartTimer() => timer = 0.0f;

        public void CompleteTimer()
        {
            if(onTimerCompleteAction != null)
            {
                onTimerCompleteAction();
            }

            if(bLoop)
            {
                RestartTimer();
            } else
            {
                manager.RemoveTimer(this);
            }
        }

        public void SetManager(ResourceManager newManager) => manager = newManager;

    }
}
