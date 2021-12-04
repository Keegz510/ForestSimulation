using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface IObject
    {
        public abstract void Init();
        public abstract void OnInit();
        public abstract void Update();
        public abstract void OnUpdate();
        public abstract void Destroy();
        public abstract void OnDestroy();

    }
}
