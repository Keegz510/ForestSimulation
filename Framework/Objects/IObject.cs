using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Engine;

namespace Framework
{
    public interface IObject
    {
        public void SetID(string id);
        public string GetID();
        public void Init();
        public void Update(float deltaTime);
        public void Destroy();
        public void SetManager(ResourceManager manager);

    }
}
