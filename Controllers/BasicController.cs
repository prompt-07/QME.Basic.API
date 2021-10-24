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
    public class BasicController : ControllerBase
    {
        private readonly BaseService baseServiceObj = new BaseService();
            
        
        [HttpPost("api/create-queue")]
        public MaybeResult<QueueURL> CreateQueue(QueueModel data)
        {
            
            return baseServiceObj.AddQueue(data);
        }

        [HttpGet("get-queue/{qName}/{qId}")]
        public MaybeResult<QueueModel> Test(string qName, string qId)
        {
            return baseServiceObj.GetQueue(qId);
        }

    }

}

