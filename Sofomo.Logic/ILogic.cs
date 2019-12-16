using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Sofomo.DTO;

namespace Sofomo.Logic
{
    public interface ILogic
    {
        HttpStatusCode Delete(string address);
        int Add(IpInfoDTO ipInfoDto);
        IpInfoDTO Get(string address);
    }
}
