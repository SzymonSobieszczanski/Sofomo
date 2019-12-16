using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sofomo.DTO
{
    public class IpInfoDTO
    {
        public string SearchAddress { get; set; }
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("ipv4")]
        public string IpV4 { get; set; }

        [JsonProperty("continent_code")]
        public string ContinentCode { get; set; }
        [JsonProperty("continent_name")]
        public string ContinentName { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
        [JsonProperty("region_name")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("location")]
        public LocationDTO Location { get; set; }
    }

    public class LocationDTO
    {
        [JsonProperty("geoname_id")]
        public string GeoNameId { get; set; }
        [JsonProperty("capital")]
        public string Capital { get; set; }
        [JsonProperty("languages")]
        public List<LanguageDTO> Languages { get; set; }
        [JsonProperty("country_flag")]
        public string CountryFlag { get; set; }
        [JsonProperty("country_flag_emoji")]
        public string CountryFlagEmoji { get; set; }
        [JsonProperty("country_flag_emoji_unicode")]
        public string CountryFlagEmojiUnicode { get; set; }
        [JsonProperty("calling_code")]
        public string CallingCode { get; set; }
        [JsonProperty("is_eu")]
        public bool IsEu { get; set; }
        
    }

    public class LanguageDTO
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("native")]
        public string Native { get; set; }

    }
}
