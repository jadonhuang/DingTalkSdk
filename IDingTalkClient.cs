using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk
{
    public interface IDingTalkClient
    {

        DingTalkResponse<T> Get<T>(IDingTalkRequest<T> request);
        DingTalkResponse<T> Post<T>(IDingTalkRequest<T> request);

    }
}
