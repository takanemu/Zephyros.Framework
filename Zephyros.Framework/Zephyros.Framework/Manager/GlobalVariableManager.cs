﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zephyros.Framework.EventArgs;
using Zephyros.Framework.Interfaces;

namespace Zephyros.Framework.Manager
{
    public class GlobalVariableManager
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static readonly GlobalVariableManager Instance = new GlobalVariableManager();

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        static GlobalVariableManager()
        {
        }

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        private GlobalVariableManager()
        {
        }

        /// <summary>
        /// 更新イベントデリゲート
        /// </summary>
        /// <param name="sender">イベント元</param><br/>
        /// <param name="e">パラメーター</param><br/>
        public delegate void PropertyChangeEventHandler(object sender, VariableChangeEventArgs e);

        /// <summary>
        /// 更新イベントハンドラ
        /// </summary>
        public event PropertyChangeEventHandler Change;

        /// <summary>
        /// 値の格納テーブル
        /// </summary>
        private Dictionary<Enum, object> map = new Dictionary<Enum, object>();

        /// <summary>
        /// データの初期化（更新イベントは発生しない）
        /// </summary>
        /// <param name="key">データ格納キー</param><br/>
        /// <param name="value">格納データ</param><br/>
        public void InitValue(Enum key, object value)
        {
            if (value is INotifyPropertyEntity)
            {
                INotifyPropertyEntity iv = (INotifyPropertyEntity)value;

                if (this.map.ContainsKey(key))
                {
                    // イベントハンドラを解除
                    INotifyPropertyEntity old = (INotifyPropertyEntity)this.map[key];

                    old.PropertyChanged -= this.PropertyChangedHandler;

                    // イベントハンドラを再追加
                    iv.PropertyChanged += new PropertyChangedEventHandler(this.PropertyChangedHandler);

                    // キーを設定
                    iv.Key = key;

                    // 値を上書き
                    this.map[key] = value;
                }
                else
                {
                    // イベントハンドラを追加
                    iv.PropertyChanged += new PropertyChangedEventHandler(this.PropertyChangedHandler);

                    // キーを設定
                    iv.Key = key;

                    // キーと値を追加
                    this.map.Add(key, value);
                }
            }
            else
            {
                if (this.map.ContainsKey(key))
                {
                    // 値を上書き
                    this.map[key] = value;
                }
                else
                {
                    // キーと値を追加
                    this.map.Add(key, value);
                }
            }
        }

        /// <summary>
        /// データの格納
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="unique">自己イベント判別用ユニークキー</param>
        public void SetValue(Enum key, object value, string unique)
        {
            this.SetValue(key, value, false, unique);
        }

        /// <summary>
        /// データの格納<br/>
        /// INotifyPropertyChangedインターフェースを実装したクラスは<br/>
        /// 更新イベント発行対象外となる。更新イベントを発行する場合には<br/>
        /// クラス内で、PropertyChangedイベントを発行すること。<br/>
        /// </summary>
        /// <param name="key">データ格納キー</param><br/>
        /// <param name="value">格納データ</param><br/>
        /// <param name="canRaisePropertyChanged">プロパティ変更通知強制実行可否</param>
        public void SetValue(Enum key, object value, bool canRaisePropertyChanged = false, string unique = null)
        {
            if (value is INotifyPropertyEntity)
            {
                // INotifyPropertyChangedインターフェースを実装したクラスは、更新でイベントの発行は行わない。
                INotifyPropertyEntity iv = (INotifyPropertyEntity)value;

                if (this.map.ContainsKey(key))
                {
                    // イベントハンドラを解除
                    INotifyPropertyEntity old = (INotifyPropertyEntity)this.map[key];

                    old.PropertyChanged -= this.PropertyChangedHandler;

                    // イベントハンドラを再追加
                    iv.PropertyChanged += new PropertyChangedEventHandler(this.PropertyChangedHandler);

                    // キーを設定
                    iv.Key = key;

                    // 値を上書き
                    this.map[key] = value;
                }
                else
                {
                    // イベントハンドラを追加
                    iv.PropertyChanged += new PropertyChangedEventHandler(this.PropertyChangedHandler);

                    // キーを設定
                    iv.Key = key;

                    // キーと値を追加
                    this.map.Add(key, value);
                }
            }
            else
            {
                // 通常オブジェクトの設定では、更新イベントの発行は行われる。
                VariableChangeEventArgs e = new VariableChangeEventArgs
                {
                    Key = key,
                    Latest = value,
                    UniqueKey = unique,
                };
                if (this.map.ContainsKey(key))
                {
                    // 更新
                    e.Change = true;

                    // 変更前の値を退避
                    e.Old = this.map[key];

                    // 値を上書き
                    this.map[key] = value;
                }
                else
                {
                    // 新規登録
                    e.Change = false;

                    // キーと値を追加
                    this.map.Add(key, value);
                }

                // 値が更新された時だけイベントを発生する。
                if (e.Old != null && e.Old.Equals(e.Latest) == false)
                {
                    this.OnPropertyChange(e);    // イベント発火
                }
                else if (e.Latest != null && e.Latest.Equals(e.Old) == false)
                {
                    this.OnPropertyChange(e);    // イベント発火
                }
                else if (canRaisePropertyChanged)
                {
                    this.OnPropertyChange(e);   // イベント強制発火
                }
            }
        }

        /// <summary>
        /// 値の削除
        /// イベントは、発火されないので注意
        /// </summary>
        /// <param name="key">データ格納キー</param>
        public void Remove(Enum key)
        {
            if (this.map.ContainsKey(key))
            {
                this.map.Remove(key);
            }
        }

        /// <summary>
        /// プロパティ更新処理ハンドラー<br/>
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">パラメーター</param>
        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            VariableChangeEventArgs ne = new VariableChangeEventArgs
            {
                // 更新フラグ
                Change = true,
                // キー
                Key = ((INotifyPropertyEntity)sender).Key,
                // プロパティ名
                PropertyName = e.PropertyName,
                // 親Entityの格納
                Parent = sender,
            };

            Type t = sender.GetType();

            // 更新値
            ne.Latest = t.InvokeMember(e.PropertyName, BindingFlags.GetProperty, null, sender, null);

            this.OnPropertyChange(ne);    // イベント発火
        }

        /// <summary>
        /// 格納データの取得<br/>
        /// </summary>
        /// <param name="key">データ取得キー</param><br/>
        /// <returns>格納データ</returns>
        public object GetValue(Enum key)
        {
            if (this.ContainsKey(key))
            {
                return this.map[key];
            }
            return null;
        }

        /// <summary>
        /// 格納データの取得<br/>
        /// </summary>
        /// <typeparam name="ReturnType">取得型</typeparam>
        /// <param name="key">データ取得キー</param><br/>
        /// <returns>格納データ</returns>
        public ReturnType GetValue<ReturnType>(Enum key)
        {
            if (this.ContainsKey(key))
            {
                return (ReturnType)this.map[key];
            }
            return default(ReturnType);
        }

        /// <summary>
        /// キーが格納されているか判定
        /// </summary>
        /// <param name="key">データ取得キー</param>
        /// <returns>trueなら格納されている</returns>
        public bool ContainsKey(Enum key)
        {
            return this.map.ContainsKey(key);
        }

        /// <summary>
        /// イベントの発生<br/>
        /// </summary>
        /// <param name="e">データ変更イベントパラメーター</param><br/>
        internal virtual void OnPropertyChange(VariableChangeEventArgs e)
        {
            if (this.Change != null)
            {
                this.Change(this, e);
            }
        }
    }
}
