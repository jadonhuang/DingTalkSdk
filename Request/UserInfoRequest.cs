using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingTalkSdk.Response;
using Newtonsoft.Json;

namespace DingTalkSdk.Request
{
   public class UserInfoRequest: IDingTalkRequest<UserInfoResponse>
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("auth_code")]
        public string AuthCode { get; set; }

        public string GetApiName()
        {
            return "/rpc/oauth2/dingtalk_app_user.json";
        }
    }
}
