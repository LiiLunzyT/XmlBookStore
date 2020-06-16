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
    public partial class TheLoai : System.Web.UI.Page
    {
        static int index = -1;
        static String mode = "view";

        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
            init();
        }

        private void setButtonEnable(Boolean add, Boolean edit, Boolean save, Boolean cancel, Boolean delete)
        {
            btnAdd.Enabled = add;
            btnEdit.Enabled = edit;
            btnSave.Enabled = save;
            btnCancel.Enabled = cancel;
            btnDelete.Enabled = delete;
        }

        private void init()
        {
            setButtonEnable(true, false, false, false, false);
            bindData();
        }

        private void bindData()
        {
            CategoryDAO dao = new CategoryDAO();
            DataTable dt = dao.toDataTable();

            grdTheLoai.DataSource = dt;
            grdTheLoai.DataBind();
        }

        protected void parseData()
        {
            CategoryDAO dao = new CategoryDAO();
            Category category = dao.getCategoryByIndex(index);

            inCategoryID.Value = category.CategoryID;
            inCategoryName.Value = category.CategoryName;
            inCategoryDesc.Value = category.CategoryDesc;
        }

        private void emptyForm()
        {
            inCategoryID.Value = "";
            inCategoryName.Value = "";
            inCategoryDesc.Value = "";
        }

        protected void grdTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = grdTheLoai.SelectedIndex;

            mode = "selected";
            setButtonEnable(false, true, false, true, true);

            parseData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryDAO dao = new CategoryDAO();
            String newID = dao.genMaxID();
            mode = "add";
            inCategoryID.Value = newID;
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategoryDAO dao = new CategoryDAO();

            if (mode == "add")
            {
                Category category = new Category();
                category.CategoryID = inCategoryID.Value;
                category.CategoryName = inCategoryName.Value;
                category.CategoryDesc = inCategoryDesc.Value;
                dao.addCategory(category);
            }
            if (mode == "edit")
            {
                Category category = new Category();
                category.CategoryID = inCategoryID.Value;
                category.CategoryName = inCategoryName.Value;
                category.CategoryDesc = inCategoryDesc.Value;
                dao.updateCategory(category);
            }

            init();
            emptyForm();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mode = "view";
            emptyForm();
            init();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CategoryDAO dao = new CategoryDAO();

            Category category = new Category();
            category.CategoryID = inCategoryID.Value;
            category.CategoryName = inCategoryName.Value;
            category.CategoryDesc = inCategoryDesc.Value;
            dao.deleteCategory(category);

            init();
            bindData();
        }
    }
}