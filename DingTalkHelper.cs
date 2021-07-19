using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk
{
    public class DingTalkHelper
    {
        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.000+08:00"); 

        }

        public static string SHA256(string key, string encryptString)
        {
            HMACSHA256 sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            byte[] signData = sha256.ComputeHash(Encoding.UTF8.GetBytes(encryptString));
            return Convert.ToBase64String(signData);
        }


        public static string GetRandomString()
        {
            return DateTime.UtcNow.ToString("yyMMddHHmmss") + new Random().Next(1000, 9999);

        }

        public static string ParamToQueryString(IDictionary<string, object> param)
        {

            if (param == null || param.Count == 0)
            {
                return null;
            }

            var keys = param.Keys.OrderBy(m => m).ToList();
            StringBuilder paramString = new StringBuilder();
            bool first = true;
            foreach (string key in keys)
            {
                object value = param[key];
                if (!first)
                {
                    paramString.Append("&");
                  
                }
                paramString.Append(key + "=" + value?.ToString());
                first = false;
            }

            return paramString.ToString();
        }


    }
}
