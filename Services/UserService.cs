using QME.Basic.API.Models;
using QME.Basic.API.Models.Constants;
using QME.Basic.API.Models.CustomModels;
using QME.Basic.API.Projects;
using QME.Basic.API.Services._Helpers;

namespace QME.Basic.API.Services
{
    public class UserService
    {
        private readonly AppConstants appConstant = new AppConstants();
        private BaserHelper baseHelper = new BaserHelper();
        private QMEContext qContext = new QMEContext();
        public UserService()
        {
            
        }


        public MaybeResult<UserObject> UpdateUser(SignUpModel user)
        {
            var result = MaybeResult<UserObject>.None();
            UserDatum newUser = new UserDatum() {
                UserId = baseHelper.IDGenerator(),
                Uname = user.Name,
                Name = user.Name,
                PassKey = user.Password,
                EnterpriseId = user.EnterpriseName,
                ContactNumberA = user.MobileNumber,
                ContactNumberB = user.MobileNumber,
            };
            qContext.Add(newUser);
            string res = qContext.SaveChanges().ToString();

            if (string.Equals(res, appConstant.SuccessCodeToDB))
            {
                UserObject createdUser = new UserObject()
                {
                    UserName = newUser.Name,
                    UserEmail = newUser.Name,
                    UserId = newUser.UserId,
                    UserProfileUrl = ""
                };
                result.Data = createdUser;
            }
            else
            {
                result.Exception.Message = "New User Creation Failed";
                result.IsException = true;
            }

            return result;
        }
    }
}
