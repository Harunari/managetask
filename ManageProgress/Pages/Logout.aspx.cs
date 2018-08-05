using ManageProgress.Library;
using System;

namespace ManageProgress.Pages
{
    public partial class Logout : NormalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["LoginId"] = null;
                Response.Redirect("~/Pages/Login.aspx");
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                return;
            }
        }
    }
}