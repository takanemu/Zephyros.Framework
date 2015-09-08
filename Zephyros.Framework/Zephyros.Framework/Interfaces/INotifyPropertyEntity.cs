using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zephyros.Framework.Interfaces
{
    public interface INotifyPropertyEntity : INotifyPropertyChanged
    {
        /// <summary>
        /// キー
        /// </summary>
        int Key { get; set; }
    }
}
