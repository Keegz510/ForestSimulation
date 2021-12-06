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
        /// How long the timer will run for
        private float timerLength = 2.0f;
        /// Where the timer is currently out
        private float timer = 0.0f;

        /// If the timer will loop or be removed on completion
        private bool bLoop = false;
        /// Reference to the action that will perform when timer is completed
        private Action onTimerCompleteAction = null;

        /// Reference to the resource manager holding this timer
        private ResourceManager manager;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="length">How long the timer will run for</param>
        /// <param name="loop">if the timer will restart</param>
        /// <param name="timerComplete">Action Performed when timer is completed</param>
        public Timer(float length, bool loop, Action timerComplete)
        {
            timerLength = length;
            bLoop = loop;
            onTimerCompleteAction = timerComplete;
        }

        /// <summary>
        /// Handles updating the timer
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            timer += 1 * deltaTime;

            if(timer >= timerLength)
            {
                CompleteTimer();
            }
        }

        /// Restarts the timer
        public void RestartTimer() => timer = 0.0f;

        /// <summary>
        /// Performs the action when timer is completed & determines if we need
        /// to restart the timer or not
        /// </summary>
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
