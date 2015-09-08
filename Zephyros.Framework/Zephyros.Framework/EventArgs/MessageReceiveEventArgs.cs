using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zephyros.Framework.EventArgs
{
    public class MessageReceiveEventArgs : System.EventArgs
    {
        /// <summary>
        /// 宛先
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// パラメーター
        /// </summary>
        public object Parameter { get; set; }

        /// <summary>
        /// 表示メッセージ
        /// </summary>
        /// <author>Yusuke Uchibori</author>
        public string MessageText { get; set; }

        /// <summary>
        /// 自己イベント判別用ユニークキー
        /// </summary>
        public string UniqueKey { get; set; }
    }
}
