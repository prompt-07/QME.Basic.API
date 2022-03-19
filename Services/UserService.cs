using QME.Basic.API.Models;
using QME.Basic.API.Models.Constants;
using QME.Basic.API.Models.CustomModels;
using QME.Basic.API.Projects;
using QME.Basic.API.Services._Helpers;
using System;
using System.Linq;

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
        public MaybeResult<LoginResponse> GetUserDetails(UserCredentials userCreds)
        {
            var result = MaybeResult<LoginResponse>.None();
            LoginResponse response = new LoginResponse();
            UserDatum data = qContext.UserData.Where(x => x.EmailId == userCreds.UserName && x.PassKey == userCreds.Password).FirstOrDefault();
            if (data != null){
                UserObject user = new UserObject()
                {
                    UserName = data.Name,
                    UserId = data.UserId,
                    UserProfileUrl = "",
                    EnterpriseId = data.EnterpriseId,
                    UserEmail = data.EmailId
                };

                QueueDatum qdata = qContext.QueueData.Where(x => x.QcreatorId == data.UserId).FirstOrDefault();
                if (qdata != null)
                {
                    QueueURL queue = new QueueURL()
                    {
                        qCode = qdata.Qguid,
                        qName = qdata.Qname,
                        qId = qdata.Qid,
                        noOfSubs = Convert.ToString(qdata.NoOfSubscribers)
                    };
                    response.User = user;
                    response.InitialQueue = queue;
                    result.Data = response;
                }
                else {
                    result.Exception.Message = "Queue not found";
                }
             }
            else{
                result.Exception.Message = "Login Failed or DB down";
            }

            return result;
        }

        public MaybeResult<SignUpResponse> UpdateUser(SignUpModel user)
        {
            var result = MaybeResult<SignUpResponse>.None();
            SignUpResponse response = new SignUpResponse();
            UserDatum newUser = new UserDatum() {
                UserId = baseHelper.IDGenerator(),
                Uname = user.Name,
                Name = user.Name,
                EmailId = user.EnterpriseEmail,
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

