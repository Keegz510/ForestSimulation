﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;
using Framework;
using Raylib_cs;

namespace ForestSim
{
    public class InGameState : GameState
    {
        public InGameState() : base()
        { }

        public override void Init()
        {
            base.Init();
            Sprite sprite = resourceManager.LoadSprite("Images/Square32x32.png");
            sprite.SetPosition(new Framework.Maths.Vector2(100, 100));
            sprite.SetTint(Color.GREEN);
            sprite.Rotation = 45.0f;
            sprite.Scale = 3.0f;
        }
    }
}
