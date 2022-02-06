using System;
using System.Collections.Generic;

#nullable disable

namespace QME.Basic.API.Models
{
    public partial class CustomerDatum
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string ServicesDesc { get; set; }
        public string TenantId { get; set; }
        public string RegistrationId { get; set; }
    }
}
