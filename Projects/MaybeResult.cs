using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Projects
{
    public class MaybeResult<TResult>
    {
        MaybeResult() { }
        
        MaybeResult(TResult someValue)
        {
            if (someValue == null)
                throw new ArgumentNullException(nameof(someValue));

            Data = someValue;
           
        }

        public MaybeException Exception { get; set; }

        public bool IsException { get; set; } = false;

        public TResult Data { get; set; }

        public int DataCount { get; set; } = 0;

        public Meta MetaData { get; set; }
        public static MaybeResult<TResult> None() => new MaybeResult<TResult>();

    }
}
