using ManageProgress.Library;
using Newtonsoft.Json;
using System.Web.Services;

namespace ManageProgress.API
{
    public partial class GetJsonString : System.Web.UI.Page
    {
        [WebMethod]
        public static string GetRegisteredProgresses(string userId)
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
    }
}