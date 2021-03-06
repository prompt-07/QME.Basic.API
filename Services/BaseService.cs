using Newtonsoft.Json.Linq;
using QME.Basic.API.Models;
using QME.Basic.API.Models.Constants;
using QME.Basic.API.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Services
{
    public class BaseService
    {
        private readonly AppConstants appConstant = new AppConstants();
        private QMEContext qContext = new QMEContext();
        private TimeSpan timeRes;

        public BaseService()
        {
            
        }
        public MaybeResult<QueueURL> AddQueue(QueueModel data)
        {
            //Insert in DB
            var result = MaybeResult<QueueURL>.None();
            QueueDatum newQueue = new QueueDatum()
            {
                Qguid = System.Guid.NewGuid().ToString(),
                Qname = data.qName,
                Qdesc = data.qDesc,
                Qid = data.qId,
                QcreationDate = Convert.ToDateTime(data.qCreationDate),
                QcreationTime = TimeSpan.TryParse(data.qCreationTime, out timeRes) ? timeRes : DateTime.Now.TimeOfDay,
                NoOfSubscribers = (int?)Convert.ToInt64(data.noOfSubs),
                QcreatorId = data.QcreatorId
            };

            qContext.QueueData.Add(newQueue);
            string res = qContext.SaveChanges().ToString();

            if (string.Equals(res, appConstant.SuccessCodeToDB))
            {
                //string customeQName = data.qName.Substring(0, newQueue.Qname.IndexOf(' ') != -1 ? newQueue.Qname.IndexOf(' ') : newQueue.Qname.Length - 1);


                //After success create QUrl
                QueueURL newQURL = new QueueURL()
                {
                    qCode = newQueue.Qguid,
                    qName = newQueue.Qname,
                    qId = newQueue.Qid,
                    //qCreationDate = newQueue.QcreationDate.ToString("dd-MM-yyyy"),
                    //qCreationTime = newQueue.QcreationTime.ToString(@"hh\:mm\:ss"),
                    noOfSubs = newQueue.NoOfSubscribers.ToString()
                };
                result.Data = newQURL;
                return result;
            }

            else 
            {
                result.Exception.Message = "New Queue Insert/Creation Failed";
                return result;
            }

             
        }

        public MaybeResult<QueueModel> GetQueue(string qId)
        {
            var result = MaybeResult<QueueModel>.None();
            QueueDatum data = qContext.QueueData.Where(x => x.Qid == qId).FirstOrDefault();

            if (data != null)
            {
                QueueModel response = new QueueModel()
                {
                    qId = data.Qid,
                    qName = data.Qname,
                    qDesc = data.Qdesc,
                    qCreationDate = data.QcreationDate.ToString(),
                    qCreationTime = data.QcreationTime.ToString(),
                    noOfSubs = data.NoOfSubscribers.ToString()
                };

                result.Data = response;
                return result;
            }
            else
            {
                result.Exception.Message = "Incorrect-queueID or DB down";
                return result;
            }
        }

        public bool AddSubscriber(SubData subscriberData)
        {
            var result = MaybeResult<QueueModel>.None();
            QueueDatum data = qContext.QueueData.Where(x => x.Qguid == subscriberData.qCode).FirstOrDefault();

            if (data != null)
            {
                data.NoOfSubscribers = data.NoOfSubscribers + 1;

                string res = qContext.SaveChanges().ToString();
                return true;
            }
            else
            {
                result.Exception.Message = "Incorrect-queueID or DB down";
                return false;
            }
        }

        public MaybeResult<bool> SearchForId(string qId)
        {
            var result = MaybeResult<bool>.None();
            QueueDatum data = qContext.QueueData.Where(x => x.Qid == qId).FirstOrDefault();

            result.Data = data != null ? true : false;
            return result;

        }


        public MaybeResult<bool> CustomerRegistraionService(CustomerDatum customer)
        {
            var result = MaybeResult<bool>.None();
            Random rnd = new Random();
            CustomerDatum newCustomer = new CustomerDatum()
            {
                FullName = customer.FullName,
                MobileNumber = customer.MobileNumber,
                EmailId = customer.EmailId,
                ServicesDesc = customer.ServicesDesc,
                TenantId = customer.TenantId,
                RegistrationId = rnd.Next().ToString(),
                Stage = "0"
            };

            qContext.CustomerData.Add(newCustomer);
            string res = qContext.SaveChanges().ToString();

            if (string.Equals(res, appConstant.SuccessCodeToDB))
            {
                result.Data = true;
            }
            else
                result.Data = false;


            return result;
        }



        public MaybeResult<List<CustomerDatum>> GetCustomerService(string id)
        {
            var result = MaybeResult<List<CustomerDatum>>.None();
            List<CustomerDatum> data = qContext.CustomerData.Where(x => x.TenantId == id).ToList<CustomerDatum>();
            result.Data = data;
            result.DataCount = data.Count();
            dynamic metaObj = new JObject();
            result.MetaData = new Meta() {
                QueueMetaData = new QHelperData() {
                    LiveQCount = getCount(data, 1),
                    ServedCount = getCount(data, 2)
                }
            };
            return result;
        }

        public MaybeResult<bool> UpdateCustomerState(string id)
        {
            var result = MaybeResult<bool>.None();
            CustomerDatum data = qContext.CustomerData.Where(x => x.RegistrationId == id).FirstOrDefault<CustomerDatum>();
            data.Stage = (Int32.Parse(data.Stage)+1).ToString();
            qContext.CustomerData.Update(data);
            string res = qContext.SaveChanges().ToString();
            result.Data = string.Equals(res, appConstant.SuccessCodeToDB) ? true : false;
            return result;
        }


        public int getCount(List<CustomerDatum> dataList, int _type)
        {
            int currCount = 0;
            foreach (var data in dataList) {
                if (string.Equals(data.Stage, _type.ToString())) {
                    currCount++;
                }
            }

            return currCount;
        }

    }
}
