using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MiBlog.Abstraction.Common
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// DateTime 转 时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertToTimeStamp(this DateTime time)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(time.AddHours(-8) - Jan1st1970).TotalMilliseconds;
        }


        /// <summary>
        /// 时间戳 转 Datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(this long timeStamp)
        {
            try
            {
                var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return start.AddMilliseconds(timeStamp).AddHours(8);
            }
            catch
            {
                return new DateTime(1910, 1, 1, 0, 0, 0);
            }
        }

        /// <summary>
        /// 可null时间戳 转 Datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime? ConvertToDateTime(this long? timeStamp)
        {
            try
            {
                return timeStamp.HasValue ? (DateTime?)ConvertToDateTime(timeStamp.Value) : null;
            }
            catch
            {
                return new DateTime(1910, 1, 1, 0, 0, 0);
            }
        }

        /// <summary>
        /// 判断对象是否为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T _this) where T : class
            => _this == null;

        /// <summary>
        /// 字符串判断 null 和 空字符串
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string _this)
            => string.IsNullOrEmpty(_this);

        /// <summary>
        /// 字符串判断 null 空字符串 空白字符串
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string _this)
            => string.IsNullOrWhiteSpace(_this);

        /// <summary>
        /// 判断字符串 是否是手机号
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsMobileNumber(this string _this)
            => _this == null ? false : CommonTool.GetMobileRegex().IsMatch(_this);


        /// <summary>
        /// 判断字符串 邮箱
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsMail(this string _this)
            => _this == null ? false : CommonTool.GetEmailRegex().IsMatch(_this);


        /// <summary>
        /// 判断 是Empty guid
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsEmptyGuid(this Guid? _this)
            => _this.HasValue && _this == Guid.Empty;

        /// <summary>
        /// 判断 是Empty guid
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsEmptyGuid(this Guid _this)
            => _this == Guid.Empty;

        /// <summary>
        /// 判断 是Empty guid
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNotEmptyGuid(this Guid? _this)
            => _this.HasValue && _this.Value != Guid.Empty;

        /// <summary>
        /// 判断 是Empty guid
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNotEmptyGuid(this Guid _this)
            => _this != Guid.Empty;

        /// <summary>
        /// 判断 guid
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsGuid(this Guid? _this)
            => _this.HasValue;



        /// <summary>
        /// 判断枚举是否定义（可空类型）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsEnum<TEnum>(this TEnum? _this) where TEnum : struct
                => _this.HasValue && System.Enum.IsDefined(typeof(TEnum), _this);


        /// <summary>
        /// 判断枚举是否定义（可空类型）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsEnum<TEnum>(this TEnum _this) where TEnum : struct
            => System.Enum.IsDefined(typeof(TEnum), _this);

        /// <summary>
        /// Guid 变成 小写字符串
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static string GuidToLowerString(this Guid _this)
            => _this.ToString().ToLower();
    }
}
