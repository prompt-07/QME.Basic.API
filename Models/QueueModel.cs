using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Models
{
    public class QueueModel
    {
        [Required]
        public string qName { get; set; }

        public string qDesc { get; set; }

        public string qId { get; set; }

        public string qCreationDate { get; set; }

        public string qCreationTime { get; set; }

        public string noOfSubs { get; set; } = "0";
    }
}
