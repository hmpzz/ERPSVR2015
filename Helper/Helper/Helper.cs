using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  
        /// <summary>
        /// 加解密用类
        /// </summary>
        public class SecurityHelper
        {
            #region 加密解密法一
            //默认密钥向量 
            private static byte[] Keys = { 0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            /// <summary> 
            /// DES加密字符串 
            /// </summary> 
            /// <param name="encryptString">待加密的字符串</param> 
            /// <param name="encryptKey">加密密钥,要求为8位</param> 
            /// <returns>加密成功返回加密后的字符串，失败返回源串</returns> 

            public static string EncryptDES(string encryptString, string encryptKey = "tjhmpz801023@#$%")
            {
                try
                {
                    byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 16));
                    byte[] rgbIV = Keys;
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                    var DCSP = Aes.Create();
                    MemoryStream mStream = new MemoryStream();
                    CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                    cStream.Write(inputByteArray, 0, inputByteArray.Length);
                    cStream.FlushFinalBlock();
                    return Convert.ToBase64String(mStream.ToArray());
                }
                catch (Exception ex)
                {
                    return ex.Message + encryptString;
                }

            }

            /// <summary> 
            /// DES解密字符串 
            /// </summary> 
            /// <param name="decryptString">待解密的字符串</param> 
            /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param> 
            /// <returns>解密成功返回解密后的字符串，失败返源串</returns> 

            public static string DecryptDES(string decryptString, string decryptKey = "tjhmpz801023@#$%")
            {
                try
                {
                    byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 16));
                    byte[] rgbIV = Keys;
                    byte[] inputByteArray = Convert.FromBase64String(decryptString);
                    var DCSP = Aes.Create();
                    MemoryStream mStream = new MemoryStream();
                    CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                    Byte[] inputByteArrays = new byte[inputByteArray.Length];
                    cStream.Write(inputByteArray, 0, inputByteArray.Length);
                    cStream.FlushFinalBlock();
                    return Encoding.UTF8.GetString(mStream.ToArray());
                }
                catch (Exception ex)
                {
                    return ex.Message + decryptString;
                }

            }
            #endregion
        }


    /// <summary>
    /// 提供支持数据绑定的泛型集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindingCollection<T> : BindingList<T>
    {
        private bool _isSortedCore = true;
        private ListSortDirection _sortDirectionCore = ListSortDirection.Ascending;
        private PropertyDescriptor _sortPropertyCore = null;
        /// <summary>
        /// 是否已排序
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return _isSortedCore; }
        }
        /// <summary>
        /// 获取列表的排序方向
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirectionCore; }
        }
        /// <summary>
        /// 获取用于对列表排序的属性说明符
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortPropertyCore; }
        }
        /// <summary>
        /// 是否支持排序
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        /// <summary>
        /// 是否支持搜索
        /// </summary>
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public BindingCollection()
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list"></param>
        public BindingCollection(IList<T> list)
            : base(list)
        { }
        /// <summary>
        /// 对项排序
        /// </summary>
        /// <param name="property"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;
            if (items != null)
            {
                ObjectPropertyCompare<T> pc = new ObjectPropertyCompare<T>(property, direction);
                items.Sort(pc);
                _isSortedCore = true;
                _sortDirectionCore = direction;
                _sortPropertyCore = property;
            }
            else
            {
                _isSortedCore = false;
            }
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        /// <summary>
        /// 移除排序
        /// </summary>
        protected override void RemoveSortCore()
        {
            _isSortedCore = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }
    public class ObjectPropertyCompare<T> : IComparer<T>
    {
        /// <summary>
        /// 属性
        /// </summary>
        public PropertyDescriptor Property { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public ListSortDirection Direction { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectPropertyCompare()
        { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="property"></param>
        /// <param name="direction"></param>
        public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        {
            Property = property;
            Direction = direction;
        }
        /// <summary>
        /// 比较两个对象
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            object xValue = x.GetType().GetProperty(Property.Name).GetValue(x, null);
            object yValue = y.GetType().GetProperty(Property.Name).GetValue(y, null);
            int returnValue;
            if (xValue == null && yValue == null)
            {
                returnValue = 0;
            }
            else if (xValue == null)
            {
                returnValue = -1;
            }
            else if (yValue == null)
            {
                returnValue = 1;
            }
            else if (xValue is IComparable)
            {
                returnValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (xValue.Equals(yValue))
            {
                returnValue = 0;
            }
            else
            {
                returnValue = xValue.ToString().CompareTo(yValue.ToString());
            }
            if (Direction == ListSortDirection.Ascending)
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }
    }
}
