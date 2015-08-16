using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zephyros.Framework.Interfaces
{
    public interface ICleanup
    {
        void Initialize();
        void Uninitialize();
    }
}
