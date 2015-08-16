using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zephyros.Framework.EventArgs
{
    public class VariableChangeEventArgs
    {
        /// <summary>
        /// 更新フラグ(true=更新/false=新規)
        /// </summary>
        public bool Change { get; set; }

        /// <summary>
        /// データ種別(格納キー)
        /// </summary>
        public Enum Key { get; set; }

        /// <summary>
        /// 更新前データ値
        /// </summary>
        public object Old { get; set; }

        /// <summary>
        /// 更新後データ値
        /// </summary>
        public object Latest { get; set; }

        /// <summary>
        /// プロパティ名(INotifyPropertyEntity)の場合のみ
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 親Entityクラス(INotifyPropertyEntity)の場合のみ
        /// </summary>
        public object Parent { get; set; }

        /// <summary>
        /// 自己イベント判別用ユニークキー
        /// </summary>
        public string UniqueKey { get; set; }

        /// <summary>
        /// プロパティ名を判定する
        /// </summary>
        /// <typeparam name="T">型情報</typeparam>
        /// <param name="propertyExpression">プロパティを示すラムダ式</param>
        /// <returns>真なら引数のプロパティ</returns>
        public bool IsCheckProperty<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            if (!(propertyExpression.Body is MemberExpression))
            {
                throw new NotSupportedException("このメソッドでは ()=>プロパティ の形式のラムダ式以外許可されません");
            }

            if (((MemberExpression)propertyExpression.Body).Member.Name == this.PropertyName)
            {
                return true;
            }
            return false;
        }
    }
}
