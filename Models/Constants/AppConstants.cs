using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QME.Basic.API.Projects.CustomBaseMiddleware;

namespace QME.Basic.API.Models.Constants
{
    public class AppConstants
    {
        
        public string BASEURL = MyHttpContext.AppBaseUrl;
        public string SuccessCodeToDB = "1";
        public string SuccessCode = "200";
    }
}
