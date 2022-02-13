using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Models.CustomModels
{
    public class QueueObject
    {
        public string Qguid { get; set; }
        public string Qname { get; set; }
        public string Qid { get; set; }
        public int? NoOfSubscribers { get; set; }
        public string QcreatorId { get; set; }
    }
}
