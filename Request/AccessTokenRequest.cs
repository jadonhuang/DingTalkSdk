using DingTalkSdk.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk.Request
{
   public class AccessTokenRequest : IDingTalkRequest<AccessTokenResponse>
    {
        public string AppKey { get; set; }

        public string AppSecret { get; set; }

        public string GetApiName()
        {
            return "/gettoken.json";
        }

    }



}
