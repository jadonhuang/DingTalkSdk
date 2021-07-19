using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk.Response
{
   public class AccessTokenResponse
    {
        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

    }
}
