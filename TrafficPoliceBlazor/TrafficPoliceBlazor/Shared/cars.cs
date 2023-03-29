using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPoliceBlazor.Shared
{
    public class cars
    {
        [Key]
        [Column("number_plate")]
        public string? number_plate { get; set; }

        [Column("brand")]
        public string? brand { get; set; }

        [Column("model")]
        public string? model { get; set; }

        [Column("colour")]
        public string? colour { get; set; }

        [Column("owner")]
        public long owner { get; set; }
    }
}
