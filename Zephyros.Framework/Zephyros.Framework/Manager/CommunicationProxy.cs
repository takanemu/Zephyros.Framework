
namespace Zephyros.Framework.Manager
{
    using System;
    using Zephyros.Framework.EventArgs;

    public class CommunicationProxy
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static readonly CommunicationProxy Instance = new CommunicationProxy();

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        static CommunicationProxy()
        {
        }

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        private CommunicationProxy()
        {
        }

        /// <summary>
        /// 更新イベントデリゲート
        /// </summary>
        /// <param name="sender">イベント元</param>
        /// <param name="e">パラメーター</param>
        public delegate void MessageReceiveEventHandler(object sender, MessageReceiveEventArgs e);

        /// <summary>
        /// 更新イベントハンドラ
        /// </summary>
        public event MessageReceiveEventHandler Receive;

        /// <summary>
        /// メッセージ送信<br/>
        /// </summary>
        /// <param name="address">宛先</param><br/>
        /// <param name="message">メッセージ</param><br/>
        /// <param name="parameter">パラメーター</param><br/>
        /// <param name="unique">自己イベント判別用ユニークキー</param>
        public void PostMessage(Enum address, string message, object parameter, string unique)
        {
            var e = new MessageReceiveEventArgs
            {
                Address = address,
                Message = message,
                Parameter = parameter,
                UniqueKey = unique,
            };
            this.OnMessageReceive(e);
        }

        /// <summary>
        /// メッセージ送信<br/>
        /// </summary>
        /// <param name="address">宛先</param><br/>
        /// <param name="message">メッセージ</param><br/>
        /// <param name="parameter">パラメーター</param><br/>
        public void PostMessage(Enum address, string message, object parameter)
        {
            MessageReceiveEventArgs e = new MessageReceiveEventArgs();

            e.Address = address;
            e.Message = message;
            e.Parameter = parameter;

            this.OnMessageReceive(e);
        }

        /// <summary>
        /// メッセージ送信<br/>
        /// </summary>
        /// <param name="address">宛先</param><br/>
        public void PostMessage(Enum address)
        {
            this.PostMessage(address, string.Empty, null);
        }

        /// <summary>
        /// メッセージ送信<br/>
        /// </summary>
        /// <param name="address">宛先</param><br/>
        /// <param name="message">メッセージ</param><br/>
        public void PostMessage(Enum address, string message)
        {
            this.PostMessage(address, message, null);
        }

        /// <summary>
        /// メッセージ送信<br/>
        /// </summary>
        /// <param name="address">宛先</param><br/>
        /// <param name="parameter">パラメーター</param><br/>
        public void PostMessage(Enum address, object parameter)
        {
            this.PostMessage(address, string.Empty, parameter);
        }

        /// <summary>
        /// イベントの発生<br/>
        /// </summary>
        /// <param name="e">メッセージ通信イベントパラメーター</param><br/>
        internal virtual void OnMessageReceive(MessageReceiveEventArgs e)
        {
            if (this.Receive != null)
            {
                this.Receive(this, e);
            }
        }
    }
}
