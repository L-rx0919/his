using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace HIS.Utility
{
    public static class StringHelper
    {
        /// <summary>
        /// 首字母大小写拆单词
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] SplitCamelCase(this string input)
        {
            // 使用正则表达式匹配每个大写字母前的位置并进行拆分
            return Regex.Matches(input, @"[A-Z][a-z]*")
                        .Select(m => m.Value)
                        .ToArray();
        }

        /// <summary>
        /// 生成表名
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GenerateTableName(this string input)
        {
            var words = input.SplitCamelCase();
            return string.Join("_", words);
        }

        #region 用SHA1加密字符串

        /// <summary>
        /// 用SHA1加密字符串
        /// </summary>
        /// <param name="rawData">要加密的数据</param>
        /// <returns></returns>
        public static string ComputeSha256Hash(this string rawData)
        {
            // 创建一个 SHA256 对象
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // 计算哈希
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // 将字节数组转换为十六进制字符串
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // 转为小写十六进制
                }
                return builder.ToString();
            }
        }

        #endregion
    }
}
