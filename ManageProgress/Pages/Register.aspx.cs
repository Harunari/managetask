using ManageProgress.Library;
using ManageProgress.Models;
using System;
using System.Text;

namespace ManageProgress.Pages
{
    public partial class WebForm1 : NormalPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                var registerFlag = true;
                var alertMessage = new StringBuilder();
                var cdb = new ConnectDB("Database1");
                var user = new UserModel
                {
                    UserId = userId.Text,
                    Email = email.Text,
                    Password = pass.Text
                };
                registerAlert.Text = "";
                if (user.UserId == "")
                {
                    alertMessage.Append("<p>ユーザIDを入力してください</p>");
                    registerFlag = false;
                }
                if (user.Password == "")
                {
                    alertMessage.Append("<p>パスワードを入力してください</p>");
                    registerFlag = false;
                }
                if (user.Email == "")
                {
                    alertMessage.Append("<p>メールアドレスを入力してください</p>");
                    registerFlag = false;
                }
                if (user.Password != rePass.Text)
                {
                    alertMessage.Append("<p>異なるパスワードが入力されています</p>");
                    registerFlag = false;
                }
                if (user.UserId.Length > 15)
                {
                    alertMessage.Append("<p>ユーザIDは15文字以内で入力してください</p>");
                    registerFlag = false;
                }
                if (user.Password.Length > 15)
                {
                    alertMessage.Append("<p>パスワードは15文字以内で入力してください</p>");
                    registerFlag = false;
                }
                if (!registerFlag)
                {
                    registerAlert.Text = alertMessage.ToString();
                    return;
                }
                if (cdb.IsExist(InputType.UserId, user.UserId))
                {
                    alertMessage.Append("<p>既に同じIDが登録されています</p>");
                    registerFlag = false;
                }
                if (cdb.IsExist(InputType.Email, user.Email))
                {
                    alertMessage.Append("<p>既に同じEmailが登録されています</p>");
                    registerFlag = false;
                }
                if (registerFlag)
                {
                    cdb.RegisterUserInformation(user);
                    Response.Redirect("~/Pages/Login.aspx");
                }
                registerAlert.Text = alertMessage.ToString();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                registerAlert.Text = "<script>" +
                    "alert('サーバ内部でエラーが発生しました');" +
                    "</script>";
            }

        }
    }
}