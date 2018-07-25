using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ManageProgress.Library;

namespace ManageProgress.API
{
    public partial class SetJsonString : System.Web.UI.Page
    {
        [WebMethod]
        public static bool SetNewProgress(string json)
        {
            var cdb = new ConnectDB("Database1");
        }
    }
}