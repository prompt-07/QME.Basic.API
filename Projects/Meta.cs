using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Projects
{
    public class Meta
    {
        public QHelperData QueueMetaData { get; set; }
    }

    public class QHelperData
    {
        public int LiveQCount { get; set; } = 0;

        public int ServedCount { get; set; } = 0;
    }
}
