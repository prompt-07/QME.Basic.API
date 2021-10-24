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

        public TResult Data { get; set; }

        public static MaybeResult<TResult> None() => new MaybeResult<TResult>();

    }
}
