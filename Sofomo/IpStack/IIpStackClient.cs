using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sofomo.DTO;

namespace Sofomo.IpStack
{
   public interface IIpStackClient
   {
       IpInfoDTO GetAddressInfo(string address);
   }
}
