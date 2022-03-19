using QME.Basic.API.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Models
{
    public class LoginResponse
    {
        public UserObject User { get; set; }

        public QueueURL InitialQueue { get; set; }
    }
}
