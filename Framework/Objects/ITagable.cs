using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface ITagable
    {
        /// Adds a new tag
        public void AddTag(string tag);
        /// Adds multiple tage
        public void AddTags(List<string> tags);
        /// Removes a tag
        public void RemoveTag(string tag);
        /// Check to see if a tag is attached to the game object
        public bool HasTag(string tag);
    }
}
