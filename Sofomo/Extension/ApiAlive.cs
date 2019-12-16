using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Sofomo.IpStack;

namespace Sofomo.Extension
{
    public static class ApiAlive
    {
        public static bool IsApiAlive(string url)
        {
            try
            {

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                if (request != null)
                {
                    request.Method = "HEAD";
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    if (response != null)
                    {
                        var responseStatus = response.StatusCode;
                        response.Close();
                        return (responseStatus == HttpStatusCode.OK);
                    }
                }

                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
