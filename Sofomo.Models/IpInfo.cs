using System;
using System.Collections.Generic;
using System.Text;

namespace Sofomo.Models
{
    public class IpInfo : BaseEntityModel
    {
        public string SearchAddress { get; set; }
        public string Ip { get; set; }
        public string IpV4 { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Location Location { get; set; }

    }
}
