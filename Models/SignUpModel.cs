using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Models
{
    public class SignUpModel
    {
        public string Name { get; set; }
        public string EnterpriseName { get; set; }

        public string MobileNumber { get; set; }

        public string EnterpriseDescription { get; set; }

        public string EnterpriseLocation { get; set; }

        public string EnterpriseEmail { get; set; }

        public string Password { get; set; }
    }
}
