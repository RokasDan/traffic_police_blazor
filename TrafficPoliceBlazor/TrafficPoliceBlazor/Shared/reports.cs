using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Shared
{
    public class reports
    {
        [Key]
        [Column("report_id")]
        public long report_id { get; set; }

        [Column("author")]
        public string author { get; set; }

        [Column("car_id")]
        public string car_id { get; set; }

        [Column("people_id")]
        public long people_id { get; set; }

        [Column("offence_id")]
        public long offence_id { get; set; }

        [Column("fine_issued")]
        public string fine_issued { get; set; }

        [Column("points_issued")]
        public string points_issued { get; set; }

        [Column("report_date")]
        public DateTime report_date { get; set; }

        [Column("details")]
        public string details { get; set; }
    }
}
