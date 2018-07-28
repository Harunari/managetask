using ManageProgress.Library;
using ManageProgress.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace ManageProgress.API
{
    public partial class SetJsonString : System.Web.UI.Page
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
            catch (Exception)
            {
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
                if (cdb.ExistSameName(participant))
                {
                    return "sameNameExisted";
                }

                cdb.RegisterParticipant(participant);

                return "registeredSuccess";
            }
            catch (Exception ex)
            {
                return "error";
            }
            

        }



    }
}