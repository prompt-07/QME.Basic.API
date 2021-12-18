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
    public class UsersController : Controller
    {
        private readonly BaseService baseServiceObj = new BaseService();

        [HttpPost("authenticate")]
        public MaybeResult<bool> AuthenticateUser(UserCredentials cred)
        {
            var result = MaybeResult<bool>.None();
            result.Data = true;

            return result;
        }

    }

}

