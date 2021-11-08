using System;
using System.Collections.Generic;

#nullable disable

namespace QME.Basic.API.Models
{
    public partial class QueueDatum
    {
        public string Qguid { get; set; }
        public string Qname { get; set; }
        public string Qdesc { get; set; }
        public string Qid { get; set; }
        public DateTime? QcreationDate { get; set; }
        public TimeSpan? QcreationTime { get; set; }
        public int? NoOfSubscribers { get; set; }
    }
}
