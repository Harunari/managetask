using ManageProgress.Library;
using System;

namespace ManageProgress.Pages
{
    public partial class ProgressesList : NormalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["LoginId"] == null)
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                loginId.InnerText = (string)Session["LoginId"];
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                return;
            }
        }

    }
}