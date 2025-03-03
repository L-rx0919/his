using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Utility
{
    public static class EnumHelper
    {
        /// <summary>
        /// 根据 Description 的值获取枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumByDescription<T>(string description) where T : Enum
        {
            System.Reflection.FieldInfo[] fields = typeof(T).GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false); //获取描述属性
                if (objs.Length > 0 && (objs[0] as DescriptionAttribute).Description == description)
                {
                    return (T)field.GetValue(null);
                }
            }
            return default;
        }
        /// <summary>
        /// 根据枚举值获取 Description 的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myEnum"></param>
        /// <returns></returns>
        public static string EnumToDescription<T>(this T myEnum)
            where T : Enum, IConvertible
        {
            Type type = typeof(T);
            System.Reflection.FieldInfo info = type.GetField(myEnum.ToString());
            var attributes = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes.Length > 0)
            {
                // 确保数组不为空，才访问
                DescriptionAttribute descriptionAttribute = attributes[0] as DescriptionAttribute;
                return descriptionAttribute?.Description ?? myEnum.ToString();
            }
            else
            {
                // 如果没有Description特性，返回枚举值的名称
                return myEnum.ToString();
            }
        }
    }
}
