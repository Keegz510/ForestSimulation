﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Framework
{
    public interface IDrawable
    {
        public void Draw();
        public void SetTexture(string texturePath, Texture2D texture);
        public Texture2D GetTexture();
      
    }
}
