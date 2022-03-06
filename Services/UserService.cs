using QME.Basic.API.Models;
using QME.Basic.API.Models.Constants;
using QME.Basic.API.Models.CustomModels;
using QME.Basic.API.Projects;
using QME.Basic.API.Services._Helpers;
using System;

namespace QME.Basic.API.Services
{
    public class UserService
    {
        private readonly AppConstants appConstant = new AppConstants();
        private BaserHelper baseHelper = new BaserHelper();
        private QMEContext qContext = new QMEContext();
        private AppConstants constObj = new AppConstants();
        private readonly BaseService baseServiceObj = new BaseService();
        public UserService()
        {
            
        }


        public MaybeResult<SignUpResponse> UpdateUser(SignUpModel user)
        {
            var result = MaybeResult<SignUpResponse>.None();
            SignUpResponse response = new SignUpResponse();
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
                    UserEmail = user.EnterpriseEmail,
                    UserId = newUser.UserId,
                    EnterpriseId = newUser.EnterpriseId,
                    UserProfileUrl = ""
                };
                response.User = createdUser;

                response.InitialQueue = CreateQueue(newUser);
                result.Data = response;

            }
            else
            {
                result.Exception.Message = "New User Creation Failed";
                result.IsException = true;
            }

            return result;
        }

        public QueueURL CreateQueue(UserDatum newUser)
        {
            #region CreateInitialQueue
            QueueModel data = new QueueModel()
            {
                qName = generateSlug(newUser.EnterpriseId),
                qId = newUser.EnterpriseId.Substring(0,4),
                qDesc = constObj.AutoQueueHelperText,
                qCreationDate = Convert.ToString(DateTime.UtcNow.Date),
                qCreationTime = Convert.ToString(DateTime.Now.TimeOfDay),
                noOfSubs = "0",
                QcreatorId = newUser.UserId
    };

            var newQueue = baseServiceObj.AddQueue(data);
            if (!newQueue.IsException) {
                return newQueue.Data;
            }

            return new QueueURL();
            #endregion
        }
        string generateSlug(string str)
        {            
            return str.Replace(' ', '-');
        }
    }
}

