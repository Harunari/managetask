using System;
using ManageProgress.Library;
using ManageProgress.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManageProgress.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoginId"] = null;
        }


        protected void Login_Click(object sender, EventArgs e)
        {
            var cdb = new ConnectDB("Database1");
            var loginUser = new UserModel
            {
                UserId = userId.Text,
                Password = pass.Text
            };
            try
            {
                if (cdb.IsLogined(loginUser))
                {
                    Session["LoginId"] = loginUser.UserId;
                    loginAlert.Text = "" +
                        "<script>sessionStorage.setItem('loginId', '" +
                        loginUser.UserId + "');" +
                        "</script>";
                    loginAlert.Text = "" +
                        "<script>console.log(sessionStorage.getItem('loginId');" +
                        "</script>";
                    Response.Redirect("~/Pages/ProgressesList.aspx");
                }
                loginAlert.Text = "IDまたはパスワードが間違っています";
            }
            catch (Exception ex)
            {
                loginAlert.Text = "<script>" +
                    "alert('サーバ内部でエラーが発生しました');" +
                    "</script>";
            }
        }
    }
}