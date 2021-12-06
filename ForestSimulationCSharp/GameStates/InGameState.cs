using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;
using Framework;

namespace ForestSim
{
    public class InGameState : GameState
    {
        public InGameState() : base()
        { }

        public override void Init()
        {
            base.Init();

            resourceManager.LoadSprite("Images/Square32x32.png");
        }
    }
}
