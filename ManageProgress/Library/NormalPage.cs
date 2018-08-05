using System;
using System.IO;

namespace ManageProgress.Library
{
    public class NormalPage : System.Web.UI.Page
    {
        public void OperateDb()
        {
            var cdb = new ConnectDB("Database1");
        }
        public string GetMapPath(string path)
        {
            // 引数を指定しない場合、このページのディレクトリが返される
            var directory = Page.Server.MapPath(path);
            return directory;
        }
        public void WriteErrorLog(string errorMessage)
        {
            var directory = GetMapPath("../log");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (var stm = new StreamWriter(Path.Combine(directory, "error.log"), true))
            {
                stm.WriteLine(DateTime.Now.ToString() + " " + errorMessage);
                stm.Flush();
            }
        }
    }
}