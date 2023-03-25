using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Shared
{
    public class offence
    {
        [Key]
        [Column("Offence_ID")]
        public long Offence_ID { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("maxFine")]
        public int maxFine { get; set; }

        [Column ("maxPoints")]
        public int maxPoints { get; set; } 

    }
}
