using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk
{
    public class DingTalkResponse<T>
    {

       
        public bool Success { get; set; }

     
        public string ErrorCode { get; set; }

       
        public string ErrorMsg { get; set; }


        public DTalkResponseContent<T> Content { get; set; }


    }

    public class DTalkResponseContent<T>
    {
    
        public T Data { get; set; }

     
        public string ResponseMessage { get; set; }

      
        public string ResponseCode { get; set; }

    }


}
