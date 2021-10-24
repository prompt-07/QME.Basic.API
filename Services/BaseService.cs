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
        public BaseService()
        {
            
        }
        public MaybeResult<QueueURL> AddQueue(QueueModel data)
        {
            //string urlQName = data.qName.Substring(0, data.qName.IndexOf(' ') != -1 ? data.qName.IndexOf(' ') : data.qName.Length-1);
            //Insert in DB
            var result = MaybeResult<QueueURL>.None();

            QueueDatum newQueue = new QueueDatum()
            {
                Qguid = System.Guid.NewGuid().ToString(),
                Qname = data.qName,
                Qdesc = data.qDesc,
                Qid = data.qId
            };

            qContext.QueueData.Add(newQueue);
            string res = qContext.SaveChanges().ToString();

            if (string.Equals(res, appConstant.SuccessCode))
            {
                string customeQName = data.qName.Substring(0, newQueue.Qname.IndexOf(' ') != -1 ? newQueue.Qname.IndexOf(' ') : newQueue.Qname.Length - 1);


                //After success create QUrl
                QueueURL newQURL = new QueueURL()
                {
                    qUrl = $"{appConstant.BASEURL}/basic/get-queue/{customeQName}/{newQueue.Qid}",
                    qName = newQueue.Qname
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
                    qDesc = data.Qdesc
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
    }
}
