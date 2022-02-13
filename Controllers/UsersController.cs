using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QME.Basic.API.Models;
using QME.Basic.API.Models.CustomModels;
using QME.Basic.API.Projects;
using QME.Basic.API.Services;

namespace QME.Basic.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly UserService userServiceObj = new UserService();

        [HttpPost("authenticate")]
        public MaybeResult<bool> AuthenticateUser(UserCredentials cred)
        {
            var result = MaybeResult<bool>.None();
            result.Data = true;

            return result;
        }


        [HttpPost("register")]
        public MaybeResult<SignUpResponse> RegisterUser(SignUpModel newUser)
        {
            return userServiceObj.UpdateUser(newUser);
        }

    }

}

