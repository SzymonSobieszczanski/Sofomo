using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Sofomo.Models
{
   public class Location : BaseEntityModel
    {
        public int IpInfoId { get; set; }
        public string GeoNameId { get; set; }
        public string Capital { get; set; }
        public ICollection<Language> Languages { get; set;}
        public string CountryFlag { get; set; }
        public string CountryFlagEmoji { get; set; }
        public string CountryFlagEmojiUnicode { get; set; }
        public string CallingCode { get; set; }
        public bool IsEu { get; set; }
        public IpInfo IpInfo { get; set; }
    }
}
