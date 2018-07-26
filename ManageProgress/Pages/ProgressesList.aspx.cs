using ManageProgress.Library;
using Newtonsoft.Json;
using System;
using System.Web.Services;

namespace ManageProgress.Pages
{
    public partial class ProgressesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO:Login機能が実装されたら消す
            Session["LoginId"] = "admin";
            loginId.InnerText = (string)Session["LoginId"];
        }

    }
}