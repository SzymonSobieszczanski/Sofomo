using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sofomo.DTO;
using Sofomo.Extension;

namespace Sofomo.IpStack
{
    public class IpStackClient : IIpStackClient
    {
        private readonly ApiSettings _apiSettings;
        public IpStackClient(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }
        public  IpInfoDTO GetAddressInfo(string address)
        {
            IpInfoDTO ipInfo = new IpInfoDTO();
            try
            {
                string info = new WebClient().DownloadString($"{_apiSettings.ApiUrl}{address}?access_key={_apiSettings.ApiKey}");
                ipInfo = JsonConvert.DeserializeObject<IpInfoDTO>(info);
                ipInfo.SearchAddress = address;
                return ipInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
