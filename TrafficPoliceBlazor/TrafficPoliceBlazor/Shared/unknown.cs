using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Shared
{
    public class unknown
    {
        [Key]
        [Column("Unknown_id")]
        public long Unknown_id { get; set; }

        [Column("first_name")]
        public string first_name { get; set; }

        [Column("last_name")]
        public string last_name { get; set;}
    }
}
