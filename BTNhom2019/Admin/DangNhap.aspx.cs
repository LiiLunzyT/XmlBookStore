using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTNhom2019.Admin
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if( Session["Login"] == "Admin")
                {
                    Response.Redirect("QuanLy.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(username.Value == "admin" && password.Value == "1")
            {
                Session["Login"] = "Admin";
                if (Request.QueryString["ReturnUrl"] != null)
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"].ToString());
                }
                else
                {
                    Response.Redirect("QuanLy.aspx");
                }
            }
        }
    }
}