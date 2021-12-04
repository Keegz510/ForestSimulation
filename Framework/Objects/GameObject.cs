using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Maths;

namespace Framework
{
    public class GameObject
    {
        #region Object Details

        /// Name of the object
        protected string objectName;
        /// ID of the object
        protected string objectID;
        /// List of tags for the game object
        protected List<string> tags = new List<string>();

        #endregion

        #region Transform

        /// Local Position of this game Object
        protected Vector2 localPosition = new Vector2();
        /// Global position of this game object
        protected Vector2 globalPosition = new Vector2();
        /// Rotation of this game object
        protected float rotation = 0;
        /// Scale of this game object
        protected float scale = 1;

        public Vector2 LocalPosition
        {
            get => localPosition;
            set
            {
                localPosition = value;
                UpdateTransform();
            }
        }

        public Vector2 GlobalPosition { get => globalPosition; }

        protected GameObject parent;
        protected List<GameObject> children = new List<GameObject>();

        public GameObject Parent { get => parent; }
        public List<GameObject> Children { get => children; }

        #endregion


        public void UpdateTransform()
        {
            if(parent != null)
            {
                globalPosition = parent.GlobalPosition + localPosition;
            } else
            {
                globalPosition = localPosition;
            }

            foreach(var go in children)
            {
                go.UpdateTransform();
            }
        }
        
        /// <summary>
        /// Sets the new parent for this game object
        /// </summary>
        /// <param name="newParent">This game objects new parent</param>
        public void SetParent(GameObject newParent)
        {
            if(parent != null)
            {
                parent.RemoveChild(this);
            }

            parent = newParent;
            parent.AddChild(this);
        }

        /// <summary>
        /// Adds a new child to this game object
        /// </summary>
        /// <param name="child">New child to add</param>
        public void AddChild(GameObject child)
        {
            if(child != null && !children.Contains(child))
            {
                children.Add(child);
            }
        }

        /// <summary>
        /// Removes a children from the gameobject
        /// </summary>
        /// <param name="child">Child to remove</param>
        public void RemoveChild(GameObject child)
        {
            if(child != null && children.Contains(child))
            {
                children.Remove(child);
            }
        }

    }
}
