using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTNhom2019.DAO;

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
            UserDAO dao = new UserDAO();

            if(dao.AdminLogin(username.Value, password.Value) != "wrong")
            {
                Session["Login"] = "Admin";
                Session["ID"] = dao.AdminLogin(username.Value, password.Value);
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