using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTNhom2019.DAO;
using BTNhom2019.Model;

namespace BTNhom2019.Admin
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] != "Admin")
                {
                    Response.Redirect(String.Format("{0}?ReturnUrl={1}", "DangNhap.aspx", Request.RawUrl));
                } else
                {
                    StaffDAO dao = new StaffDAO();
                    if(dao.getStaffByUserID(Session["ID"].ToString()) == null)
                    {
                        welcome.InnerText = "Xin chào null";
                    } else
                    {
                        String name = dao.getStaffByUserID(Session["ID"].ToString()).StaffName;
                        welcome.InnerText = "Xin chào " + name + "!";
                    }
                    
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Session["ID"] = null;
            Response.Redirect("DangNhap.aspx");
        }
    }
}