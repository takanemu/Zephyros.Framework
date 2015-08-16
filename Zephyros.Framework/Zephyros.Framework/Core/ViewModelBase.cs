using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephyros.Framework.Interfaces;
using Zephyros.Framework.Manager;
using Zephyros.Framework.Mixins;

namespace Zephyros.Framework.Core
{
    public class ViewModelBase : Livet.ViewModel, ICleanup
    {
        public void Initialize()
        {
            if (this is MViewModelCommunicationProvider)
            {
                ((MViewModelCommunicationProvider)this).Construction(this);
                CommunicationProxy.Instance.Receive += ReceiveHandler;
            }
            if(this is MViewModelVariableShareProvider)
            {
                ((MViewModelVariableShareProvider)this).Construction(this);
                GlobalVariableManager.Instance.Change += ChangeHandler;
            }
        }

        public void Uninitialize()
        {
            if (this is MViewModelCommunicationProvider)
            {
                CommunicationProxy.Instance.Receive -= ReceiveHandler;
            }
            if (this is MViewModelVariableShareProvider)
            {
                GlobalVariableManager.Instance.Change -= ChangeHandler;
            }
        }

        private void ReceiveHandler(object sender, EventArgs.MessageReceiveEventArgs e)
        {
            ((MViewModelCommunicationProvider)this).CallFunction(e);
        }

        private void ChangeHandler(object sender, EventArgs.VariableChangeEventArgs e)
        {
            ((MViewModelVariableShareProvider)this).CallFunction(e);
        }
    }
}
