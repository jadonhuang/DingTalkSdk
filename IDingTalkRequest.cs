using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSdk
{
    public interface IDingTalkRequest<T>
    {

        string GetApiName();

    }
}
