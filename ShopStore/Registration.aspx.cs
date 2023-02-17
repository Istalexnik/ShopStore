using ShopStore.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopStore
{
    public partial class Registration : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }
            List<SqlParameter> lParam = new List<SqlParameter>()
            {
                new SqlParameter("@col_username", txtUsername.Text.Trim()),
                new SqlParameter("@col_password", txtPassword.Text.Trim()),
                new SqlParameter("@col_email", txtEmail.Text.Trim())
            };
            SqlTool sqlTool = new SqlTool();
            int userid = Convert.ToInt32(sqlTool.ProcScalar("usp_register_user", lParam));
            switch (userid)
            {
                case -1:
                    {
                        lblMessage.Text = "Username already exists. \nPlease choose a different username.";
                        break;
                    }
                case -2:
                    {
                        lblMessage.Text = "This email address has already been used.";
                        break;
                    }
                default:
                    {
                        string activationCode = CreateActivationCode(userid);
                        SendActivationEmail(activationCode);
                        Response.Redirect("Login.aspx?activationLinkSent=true");
                        break;
                    }
            }

        }

        private string CreateActivationCode(int userid)
        {
            string activationCode = Guid.NewGuid().ToString();
            List<SqlParameter> lParam = new List<SqlParameter>()
            {
                new SqlParameter("@col_username", userid),
                new SqlParameter("@col_activation_code", activationCode)
            };
            SqlTool sqlTool = new SqlTool();
            sqlTool.Proc("usp_create_activation_code", lParam);
            return activationCode;
        }

        private void SendActivationEmail(string activationCode)
        {
            string fileName = Server.MapPath("~/Templates/Notice_Registration.html");
            string mailbody = File.ReadAllText(fileName);
            mailbody = mailbody.Replace("##USERNAME", txtUsername.Text.Trim());
            mailbody = mailbody.Replace("##URL##", Request.Url.AbsoluteUri.Replace("Registration.aspx", Convert.ToString("Activation.aspx?ActivationCode=") + activationCode));
            Emailing.Email(txtEmail.Text.Trim(), "Account Activation", mailbody);
        }
    }
}