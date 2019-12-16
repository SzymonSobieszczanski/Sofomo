using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sofomo.Models
{
    public class Language : BaseEntityModel
    {
        public int LocationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
