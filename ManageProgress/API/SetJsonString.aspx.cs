using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManageProgress.Library;
using Newtonsoft.Json;
using ManageProgress.Models;

namespace ManageProgress.API
{
    public partial class SetJsonString : System.Web.UI.Page
    {
        [WebMethod]
        public static string SetNewProgress(string jsonString)
        {
            if (jsonString == "")
            {
                return "failed";
            }
            var cdb = new ConnectDB("Database1");

            var receivedData = JsonConvert.DeserializeObject<Dictionary<string,string>>(jsonString);
            var progress = new ProgressModel {
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
    }
}