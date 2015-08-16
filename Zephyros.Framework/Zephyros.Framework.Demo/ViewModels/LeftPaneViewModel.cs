using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Zephyros.Framework.Attributes;
using Zephyros.Framework.Core;
using Zephyros.Framework.Demo.Enums;
using Zephyros.Framework.EventArgs;
using Zephyros.Framework.Interfaces;

namespace Zephyros.Framework.Demo.ViewModels
{
    public class LeftPaneViewModel : ViewModelBase, MViewModelCommunicationProvider, MViewModelVariableShareProvider
    {
        public LeftPaneViewModel()
        {
            this.Initialize();
            this.Uninitialize();
        }

        private Livet.Commands.ViewModelCommand _closeButtonCommand;

        public Livet.Commands.ViewModelCommand CloseButtonCommand
        {
            get
            {
                if (this._closeButtonCommand == null)
                {
                    this._closeButtonCommand = new Livet.Commands.ViewModelCommand(this.CloseButton);
                }
                return this._closeButtonCommand;
            }
        }
        private void CloseButton()
        {
            var lclose = (Storyboard)Application.Current.MainWindow.FindResource("LeftPaneClose");

            lclose.Begin();
        }

        [CommunicationProxy(Key = CommunicationKeyEnum.TEST00)]
        public void Test00Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST01)]
        public void Test01Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST02)]
        public void Test02Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST03)]
        public void Test03Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST04)]
        public void Test04Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST05)]
        public void Test05Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST06)]
        public void Test06Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST07)]
        public void Test07Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST08)]
        public void Test08Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST09)]
        public void Test09Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST10)]
        public void Test10Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST11)]
        public void Test11Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST12)]
        public void Test12Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST13)]
        public void Test13Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST14)]
        public void Test14Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST15)]
        public void Test15Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST16)]
        public void Test16Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST17)]
        public void Test17Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST18)]
        public void Test18Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST19)]
        public void Test19Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST20)]
        public void Test20Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST21)]
        public void Test21Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST22)]
        public void Test22Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST23)]
        public void Test23Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST24)]
        public void Test24Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST25)]
        public void Test25Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST26)]
        public void Test26Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST27)]
        public void Test27Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST28)]
        public void Test28Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST29)]
        public void Test29Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST30)]
        public void Test30Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST31)]
        public void Test31Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST32)]
        public void Test32Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST33)]
        public void Test33Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST34)]
        public void Test34Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST35)]
        public void Test35Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST36)]
        public void Test36Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST37)]
        public void Test37Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST38)]
        public void Test38Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST39)]
        public void Test39Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST40)]
        public void Test40Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST41)]
        public void Test41Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST42)]
        public void Test42Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST43)]
        public void Test43Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST44)]
        public void Test44Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST45)]
        public void Test45Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST46)]
        public void Test46Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST47)]
        public void Test47Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST48)]
        public void Test48Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST49)]
        public void Test49Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST50)]
        public void Test50Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST51)]
        public void Test51Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST52)]
        public void Test52Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST53)]
        public void Test53Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST54)]
        public void Test54Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST55)]
        public void Test55Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST56)]
        public void Test56Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST57)]
        public void Test57Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST58)]
        public void Test58Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST59)]
        public void Test59Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST60)]
        public void Test60Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST61)]
        public void Test61Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST62)]
        public void Test62Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST63)]
        public void Test63Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST64)]
        public void Test64Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST65)]
        public void Test65Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST66)]
        public void Test66Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST67)]
        public void Test67Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST68)]
        public void Test68Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST69)]
        public void Test69Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST70)]
        public void Test70Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST71)]
        public void Test71Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST72)]
        public void Test72Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST73)]
        public void Test73Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST74)]
        public void Test74Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST75)]
        public void Test75Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST76)]
        public void Test76Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST77)]
        public void Test77Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST78)]
        public void Test78Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST79)]
        public void Test79Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST80)]
        public void Test80Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST81)]
        public void Test81Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST82)]
        public void Test82Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST83)]
        public void Test83Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST84)]
        public void Test84Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST85)]
        public void Test85Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST86)]
        public void Test86Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST87)]
        public void Test87Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST88)]
        public void Test88Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST89)]
        public void Test89Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST90)]
        public void Test90Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST91)]
        public void Test91Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST92)]
        public void Test92Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST93)]
        public void Test93Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST94)]
        public void Test94Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST95)]
        public void Test95Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST96)]
        public void Test96Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST97)]
        public void Test97Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST98)]
        public void Test98Listner(MessageReceiveEventArgs e)
        {
        }
        [CommunicationProxy(Key = CommunicationKeyEnum.TEST99)]
        public void Test99Listner(MessageReceiveEventArgs e)
        {
        }
    }
}
