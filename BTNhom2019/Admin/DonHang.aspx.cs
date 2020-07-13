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
        String mode = "view";
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
            DataTable dt = dao.ToDataTable(orderFilter.SelectedValue);

            grdDonHang.DataSource = dt;
            grdDonHang.DataBind();
        }

        protected void orderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindData();
        }

        protected void grdDonHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDonHang.PageIndex = e.NewPageIndex;
            bindData();
        }

        protected void grdDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = "selected";
            parseData();
        }

        private void parseData()
        {
            OrderDAO oDAO = new OrderDAO();
            Order order = oDAO.GetOrderByID(grdDonHang.SelectedRow.Cells[1].Text);

            CustomerDAO cDAO = new CustomerDAO();
            Customer customer = cDAO.GetCustomerByCustomerID(order.CustomerID);

            inOrderID.Value = order.OrderID;
            inDate.Value = order.OrderDate.ToString();
            inCustomerID.Value = order.CustomerID;
            inCustomerName.Value = customer.CustomerName;
            inAddress.Value = customer.CustomerAddress;
            inTotal.Value = oDAO.CountTotal(order.Details).ToString();

            btnAccept.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void emptyForm()
        {
            inOrderID.Value = "";
            inDate.Value = "";
            inCustomerID.Value = "";
            inCustomerName.Value = "";
            inAddress.Value = "";
            inTotal.Value = "";

            btnAccept.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            OrderDAO oDAO = new OrderDAO();
            oDAO.CheckOrder(inOrderID.Value);
            emptyForm();
            bindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OrderDAO oDAO = new OrderDAO();
            oDAO.DeleteOrder(inOrderID.Value);
            emptyForm();
            bindData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            emptyForm();
        }
    }
}