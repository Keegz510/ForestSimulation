using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Framework.Maths;
public struct Size
{
    public float Width;
    public float Height;
}

namespace Framework
{
    public class Button : GameObject
    {
        protected Action onClickAction;
        protected bool isHovering = false;
        protected Size buttonSize;
        public Button(Size buttonSize) : base()
        {
            this.buttonSize = buttonSize;   
        }

        public Button(Size buttonSize, string name) : base(name)
        {
            this.buttonSize = buttonSize;
        }

        public Button(Size buttonSize, Action onClick) : base()
        {
            onClickAction = onClick;
            this.buttonSize = buttonSize;
        }

        public Button(Size buttonSize, Action onClick, string name) : base(name)
        {
            this.buttonSize = buttonSize;
            onClickAction = onClick;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if(IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                if(CheckIfHovering())
                {
                    OnClick();
                }
            }
        }

        protected bool CheckIfHovering()
        {
            Vector2 mousePosition = new Vector2
            {
                x = GetMousePosition().X,
                y = GetMousePosition().Y
            };

            if (mousePosition.x > GlobalPosition.x && mousePosition.x < (mousePosition.x + buttonSize.Width))
            {
                if (mousePosition.y > GlobalPosition.y && mousePosition.y < (mousePosition.y + buttonSize.Height))
                {
                    return true;
                }
            }

            return false;
        }

        public void OnClick()
        {
            if(onClickAction != null)
            {
                onClickAction();
            }
        }

        public void SetOnClick(Action onClick) => onClickAction = onClick;
    }
}
