using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Shared
{
    public class people
    {
        [Key]
        [Column("people_id")]
        public long people_id { get; set; }

        [Column("first_name")]
        public string first_name { get; set; }

        [Column("last_name")]
        public string last_name { get; set;}

        [Column("address")]
        public string address { get; set; }

        [Column("date_of_birth")]
        public DateTime date_of_birth { get; set; }

        [Column("license_number")]
        public string license_number { get; set; }
    }
}
