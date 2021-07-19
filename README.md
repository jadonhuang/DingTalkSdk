# 专有钉钉Sdk
最近在开发专有钉钉接口，发现官方没有.net sdk，于是编写了一个，希望此代码对您有所帮助。
只编写了getaccesstoken和getuserinfo两个接口类，其他的请求类，请按照文档自行编写，编写相应的Request和Response类即可。

public class AccessTokenRequest : IDingTalkRequest<AccessTokenResponse>
       {  
       
        public string AppKey { get; set; }

        public string AppSecret { get; set; }

        public string GetApiName()
        {
            return "/gettoken.json";
        }

    }
    

    接口调用如下：
    
     class Program
    {
        static void Main(string[] args)
        {


            string appKey = "appKey";
            string appSecrect = "appSecrect";
            IDingTalkClient dingTalkClient = new DefaultDingTalkClient(appKey, appSecrect);

            AccessTokenRequest request = new AccessTokenRequest();
            request.AppKey = appKey;
            request.AppSecret = appSecrect;

            var result = dingTalkClient.Get(request);

            Console.WriteLine(JsonConvert.SerializeObject(result));


            var token = result.Content.Data.AccessToken;

            var userRequest = new UserInfoRequest() { AccessToken = token, AuthCode = "AuthCode" };

            var userResult = dingTalkClient.Post(userRequest);

            Console.WriteLine(JsonConvert.SerializeObject(userResult));



         }
        }
