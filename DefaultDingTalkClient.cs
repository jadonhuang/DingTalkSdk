using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk
{
    public class DefaultDingTalkClient : IDingTalkClient
    {


        private static RestClient  _restClient ;

        private string _baseUrl = "https://openplatform.dg-work.cn";

        private string _appSecrect;

        public string _appId;

    

        public DefaultDingTalkClient(string appId, string appSecrect) : this(null, appId, appSecrect)
        {

        }


        public DefaultDingTalkClient(string baseUrl, string appId, string appSecrect)
        {
            if (baseUrl != null)
            {
                _baseUrl = baseUrl;
            }
            _appId = appId;
            _appSecrect = appSecrect;
            _restClient = new RestClient(_baseUrl);
        }

        private IDictionary<string, string> BuildHeaders(string method,string apiName, IDictionary<string, object> param)
        {

            var timestamp = DingTalkHelper.GetTimestamp();
            var nonceStr = DingTalkHelper.GetRandomString();
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-Hmac-Auth-IP", "127.0.0.1");
            headers.Add("X-Hmac-Auth-MAC", "");
            headers.Add("X-Hmac-Auth-Timestamp", timestamp);
            headers.Add("X-Hmac-Auth-Version", "1.0");
            headers.Add("X-Hmac-Auth-Nonce", nonceStr);
            headers.Add("apiKey", _appId);

            var queryStr = DingTalkHelper.ParamToQueryString(param);

            string signStr = $"{method}\n{timestamp}\n{nonceStr}\n{apiName}";

            if (queryStr != null)
            {
                signStr += $"\n{queryStr}";
            }

            var signature = DingTalkHelper.SHA256(_appSecrect, signStr);

            headers.Add("X-Hmac-Auth-Signature", signature);

            return headers;



        }


        private DingTalkResponse<T> DoRequest<T>(IDingTalkRequest<T> request, Method method) 
        {

            var paramJoson =  JsonConvert.SerializeObject(request);

            IDictionary<string, object> param = JsonConvert.DeserializeObject<Dictionary<string, object>>(paramJoson);

            var headers = BuildHeaders(method.ToString().ToUpper(), request.GetApiName(),param);

            var restRequest = new RestRequest(request.GetApiName(), method);

            foreach (var kv in headers)
            {
                restRequest.AddHeader(kv.Key, kv.Value);
            }

            foreach (var kv in param)
            {
                restRequest.AddParameter(kv.Key, kv.Value);
            }

            var result = _restClient.Execute(restRequest);
            if (result.IsSuccessful)
            {
                var content = result.Content;
                return JsonConvert.DeserializeObject<DingTalkResponse<T>>(content);
              
            }

            return Activator.CreateInstance<DingTalkResponse<T>>();

        }


        public DingTalkResponse<T> Get<T>(IDingTalkRequest<T> request) 
        {
            return DoRequest(request, Method.GET);

        }

        public DingTalkResponse<T> Post<T>(IDingTalkRequest<T> request)
        {
            return DoRequest(request, Method.POST);
        }
    }
}
