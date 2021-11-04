using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QME.Basic.API.Models;
using QME.Basic.API.Projects;
using QME.Basic.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly BaseService baseServiceObj = new BaseService();

        [HttpGet("searchcore/{qid}")]
        public MaybeResult<bool> SearchCore(string qId)
        {
            var result = MaybeResult<bool>.None();
            result.Data = false;

            return baseServiceObj.SearchForId(qId);
        }

    }

}

