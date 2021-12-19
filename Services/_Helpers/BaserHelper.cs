using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Services._Helpers
{
    public class BaserHelper
    {
        public BaserHelper() { }
        public string IDGenerator()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
