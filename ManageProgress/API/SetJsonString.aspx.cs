using ManageProgress.Library;
using ManageProgress.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace ManageProgress.API
{
    public partial class SetJsonString : APIPage
    {
        [WebMethod]
        public static string SetNewProgress(string jsonString)
        {
            var cdb = new ConnectDB("Database1");
            if (jsonString == "")
            {
                return "failed";
            }
            var receivedData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            try
            {
                var progress = new ProgressModel
                {
                    UserId = receivedData["userId"],
                    Title = receivedData["title"],
                    DateTimeRegistered = DateTime.Now,
                    NumberOfTask = int.Parse(receivedData["numberOfTask"]),
                    Password = receivedData["password"]
                };
                var tasks = new List<TaskModel>();
                for (int i = 1; i <= progress.NumberOfTask; i++)
                {
                    tasks.Add(new TaskModel { Task = receivedData["task" + i.ToString()] });
                }


                if (cdb.SetProgress(progress, tasks))
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                var thisPage = new GetJsonString();
                thisPage.WriteErrorLog(ex.Message);
                return "error";
            }

        }
        [WebMethod]
        public static string SetNewParticipant(string jsonString)
        {
            var cdb = new ConnectDB("Database1");
            if (jsonString == "")
            {
                return "error";
            }
            var receivedData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            try
            {
                var participant = new ParticipantModel
                {
                    ProgressId = int.Parse(receivedData["progressId"]),
                    ParticipantName = receivedData["name"],
                    CurrentProgress = 0
                };
                var password = receivedData["password"];
                if (!cdb.IsCorrectPassword(participant, password))
                {
                    return "wrongPassword";
                }
                if (cdb.IsExistSameName(participant))
                {
                    return "sameNameExisted";
                }

                cdb.SetParticipant(participant);

                return "registeredSuccess";
            }
            catch (Exception ex)
            {
                var thisPage = new GetJsonString();
                thisPage.WriteErrorLog(ex.Message);
                return "error";
            }


        }
        [WebMethod]
        public static string ChangeProgress(string jsonString)
        {
            var cdb = new ConnectDB("Database1");
            if (jsonString == "")
            {
                return "nil";
            }
            var receivedData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            try
            {
                var participant = new ParticipantModel
                {
                    ProgressId = int.Parse(receivedData["progressId"]),
                    ParticipantName = receivedData["participantName"],
                    CurrentProgress = int.Parse(receivedData["currentProgress"])
                };
                var password = receivedData["progPassword"];
                if (cdb.IsCorrectPassword(participant, password))
                {
                    cdb.ChangeProgress(participant);
                    return "success";
                }
                return "wrongPassword";
                
            }
            catch (Exception ex)
            {
                var thisPage = new GetJsonString();
                thisPage.WriteErrorLog(ex.Message);
                return "error";
            }
        }

    }
}