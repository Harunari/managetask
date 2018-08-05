using System;

namespace ManageProgress.Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoginId"] = null;
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}