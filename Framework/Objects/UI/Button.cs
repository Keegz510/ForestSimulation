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
        /// Reference to the action that is performed when button is clicked
        protected Action onClickAction;
        /// Reference to the size of the object
        protected Size buttonSize;
        public Size ButtonSize { get => buttonSize; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="buttonSize">Size of the button</param>
        public Button(Size buttonSize) : base()
        {
            this.buttonSize = buttonSize;   
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buttonSize">Size of the button</param>
        /// <param name="name">Name of the game object</param>
        public Button(Size buttonSize, string name) : base(name)
        {
            this.buttonSize = buttonSize;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buttonSize">Size of the button</param>
        /// <param name="onClick">Action to perform when button is clicked</param>
        public Button(Size buttonSize, Action onClick) : base()
        {
            onClickAction = onClick;
            this.buttonSize = buttonSize;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buttonSize">Size of the button</param>
        /// <param name="onClick">Action to perform when button is clicked</param>
        /// <param name="name">Name of the game object</param>
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

        /// <summary>
        /// Checks if the object is begin hovered over
        /// </summary>
        /// <returns>If being hovered or not</returns>
        protected bool CheckIfHovering()
        {
            Vector2 mousePosition = new Vector2
            {
                x = GetMousePosition().X,
                y = GetMousePosition().Y
            };

            if (mousePosition.x > GlobalPosition.x && mousePosition.x < (mousePosition.x + (buttonSize.Width * scale)))
            {
                if (mousePosition.y > GlobalPosition.y && mousePosition.y < (mousePosition.y + (buttonSize.Height * scale)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Action performed when the button is clicked
        /// </summary>
        public void OnClick()
        {
            if(onClickAction != null)
            {
                onClickAction();
            }
        }

        /// Sets the action we wish to perform when the button is clicked
        public void SetOnClick(Action onClick) => onClickAction = onClick;
    }
}
