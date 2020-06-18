using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTNhom2019.Admin
{
    public partial class DonHang : System.Web.UI.Page
    {
        static int index = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        protected void bindData()
        {
            OrderDAO dao = new OrderDAO();
            DataTable dt = dao.toDataTable(orderFilter.SelectedValue);

            grdDonHang.DataSource = dt;
            grdDonHang.DataBind();
        }

        protected void orderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindData();
        }
    }
}