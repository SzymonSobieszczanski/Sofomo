using System;
using System.Collections.Generic;
using System.Text;

namespace Sofomo.Common
{
    public static class Helpers
    {
        public static string PrepareUrl(string url)
        {
            url = RemoveHttps(url);
            url = RemoveHttp(url);
            url = RemoveWWW(url);
            url = RemoveSlash(url);
            return url;
        }
        
        public static string RemoveHttp(string url)
        {
            if (url.StartsWith("http://"))
            {
                url = url.Substring("http://".Length);
            }

            return url;
        }
        public static string RemoveHttps(string url)
        {
            if (url.StartsWith("https://"))
            {
                url = url.Substring("https://".Length);
            }
            return url;
        }
        public static string RemoveWWW(string url)
        {
            if (url.StartsWith("www."))
            {
                url = url.Substring("www.".Length);
            }
            return url;
        }
        public static string RemoveSlash(string url)
        {
            if (url.EndsWith("/"))
            {
                return url.Remove(url.Length - 1);
            }
            return url;
        }



    }
}
