using ManageProgress.Library;
using Newtonsoft.Json;
using System.Web.Services;
using System;

namespace ManageProgress.API
{
    public partial class GetJsonString : System.Web.UI.Page
    {
        [WebMethod]
        public static string GetRegisteredProgresses(string userId)
        {
            try
            {
                var cdb = new ConnectDB("Database1");
                // TODO:ログイン中のユーザのみの進捗データ一覧を取得する
                var result = cdb.GetAllProgresses();
                if (result.Count == 0)
                {
                    return "nil";
                }
                // シリアライズ
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {
                return "error";
                
            }
        }
        [WebMethod]
        public static string GetParticipants(string strProgressId)
        {
            var cdb = new ConnectDB("Database1");
            try
            {
                int progressId = int.Parse(strProgressId);
                var result = cdb.GetParticipants(progressId);
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {

                return "error";
            }
        }
        [WebMethod]
        public static string GetTasks(string strProgressId)
        {
            var cdb = new ConnectDB("Database1");
            try
            {
                int progressId = int.Parse(strProgressId);
                var result = cdb.GetTasks(progressId);
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                return json;
            }
            catch (Exception)
            {

                return "error";
            }
        }
    }
}