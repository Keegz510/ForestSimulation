using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Maths;
using Framework.Engine;

namespace Framework
{
    public class GameObject : IObject, ITagable
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

        public float Rotation { get => rotation; set { rotation = value; } }
        public float Scale { get => scale; set => scale = value; }

        /// Parent of this gameobject
        protected GameObject parent = null;
        /// List of children under this game object
        protected List<GameObject> children = new List<GameObject>();

        public GameObject Parent { get => parent; }
        public List<GameObject> Children { get => children; }

        public bool bIsActive = true;


        #endregion

        protected ResourceManager manager;

        public GameObject()
        {
            objectName = "Game Object";
        }

        public GameObject(string name)
        {
            objectName = name;
        }

        /// <summary>
        /// Sets the ID for this object
        /// </summary>
        /// <param name="id">ID to set</param>
        public void SetID(string id) => objectID = id;

        /// <summary>
        /// Returns the object ID
        /// </summary>
        /// <returns>Returns the object ID</returns>
        public string GetID() => objectID;


        /// <summary>
        /// Updates the current transform position of the game object & all it's children
        /// </summary>
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

        public void SetManager(ResourceManager newManager) => manager = newManager;

        public virtual void Init()
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            if (!bIsActive) return;
        }

        /// <summary>
        /// Handles Destroying the game object
        /// </summary>
        public virtual void Destroy()
        {
            manager.UnloadGameObject(this);
        }

        /// <summary>
        /// Adds a new tag to the game object
        /// </summary>
        /// <param name="tag">Tag to add</param>
        public void AddTag(string tag)
        {
            if(!tags.Contains(tag))
            {
                tags.Add(tag);
            }
        }

        /// <summary>
        /// Adds multiple tags to the game object
        /// </summary>
        /// <param name="tags"></param>
        public void AddTags(List<string> tags)
        {
            foreach(var tag in tags)
            {
                this.tags.Add(tag);
            }
        }

        /// <summary>
        /// Removes the passed in tag
        /// </summary>
        /// <param name="tag">Tag to remove</param>
        public void RemoveTag(string tag)
        {
            if(tags.Contains(tag))
            {
                tags.Remove(tag);
            }
        }

        /// <summary>
        /// Check if the game object has the specified tag
        /// </summary>
        /// <param name="tag">Tag to check</param>
        /// <returns>Returns if the game object has the tag</returns>
        public bool HasTag(string tag)
        {
            if (tags.Contains(tag))
                return true;

            return false;
        }

        public void SetPosition(Vector2 pos) => LocalPosition = pos;
    }
}
