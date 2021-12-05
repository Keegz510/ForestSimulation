using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface ITagable
    {
        public void AddTag(string tag);
        public void AddTags(List<string> tags);
        public void RemoveTag(string tag);
        public void HasTag(string tag);
    }
}
