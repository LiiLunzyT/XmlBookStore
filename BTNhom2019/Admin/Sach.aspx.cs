using BTNhom2019.DAO;
using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTNhom2019.Admin
{
    public partial class Sach : System.Web.UI.Page
    {
        static int index = -1;
        static String mode = "view";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getCombobox();
                bindData();
                init();
            }
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
            BookDAO dao = new BookDAO();
            DataTable dt = dao.toDataTable();

            grdSach.DataSource = dt;
            grdSach.DataBind();
        }

        private void changeNor(HtmlInputText input)
        {

        }
        private Boolean isFormValid()
        {
            int errors = 0;
            if(inBookName.Value.Trim() == "")
            {
                inBookName.Style["border-color"] = "red";
                errors++;
            }
            if (inBookPrice.Value.Trim() == "")
            {
                inBookPrice.Style["border-color"] = "red";
                errors++;
            }
            if (inBookName.Value.Trim() == "")
            {
                inBookName.Style["border-color"] = "red";
                errors++;
            }
            if (inBookName.Value.Trim() == "")
            {
                inBookName.Style["border-color"] = "red";
                errors++;
            }
            if (inBookName.Value.Trim() == "")
            {
                inBookName.Style["border-color"] = "red";
                errors++;
            }

            if (errors > 0)
            {
                return false;
            }
            return true;
        }

        private void getCombobox()
        {
            AuthorDAO aDAO = new AuthorDAO();
            DataTable dt1 = aDAO.toDataTable();
            inAuthor.DataSource = dt1;
            inAuthor.DataTextField = "Tên Tác giả";
            inAuthor.DataValueField = "Mã Tác giả";
            inAuthor.DataBind();

            CategoryDAO cDAO = new CategoryDAO();
            DataTable dt2 = cDAO.toDataTable();
            inCategory.DataSource = dt2;
            inCategory.DataTextField = "Tên Thể loại";
            inCategory.DataValueField = "Mã Thể loại";
            inCategory.DataBind();

            ProducerDAO pDAO = new ProducerDAO();
            DataTable dt3 = pDAO.toDataTable();
            inProducer.DataSource = dt3;
            inProducer.DataTextField = "Tên Nhà xuất bản";
            inProducer.DataValueField = "Mã Nhà xuất bản";
            inProducer.DataBind();
        }

        protected void parseData()
        {
            BookDAO dao = new BookDAO();
            Book book = dao.geBookByIndex(index);

            inBookID.Value = book.BookID;
            inBookName.Value = book.BookName;
            inBookPrice.Value = book.BookPrice.ToString();
            inBookQuantity.Value = book.BookQuantity.ToString();
            inBookDiscount.Value = book.BookDiscount.ToString();
            inAuthor.SelectedValue = book.AuthorID;
            inCategory.SelectedValue = book.CategoryID;
            inProducer.SelectedValue = book.ProducerID;
            inPages.Value = book.Pages.ToString();
            inSize.Value = book.Size;
            inYear.Value = book.Year.ToString();
            inDescription.Value = book.Description;
        }

        private void emptyForm()
        {
            inBookID.Value = "";
            inBookName.Value = "";
            inBookPrice.Value = "";
            inBookQuantity.Value = "";
            inBookDiscount.Value = "";
            inPages.Value = "";
            inSize.Value = "";
            inYear.Value = "";
            inDescription.Value = "";
        }

        protected void grdSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = grdSach.SelectedIndex;

            mode = "selected";
            setButtonEnable(false, true, false, true, true);

            parseData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BookDAO dao = new BookDAO();
            String newID = dao.genMaxID();
            mode = "add";
            inBookID.Value = newID;
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            setButtonEnable(false, false, true, true, false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BookDAO dao = new BookDAO();

            if (mode == "add")
            {
                if(isFormValid())
                {

                    Book book = new Book();
                    book.BookID = inBookID.Value;
                    book.BookName = inBookName.Value;
                    book.BookPrice = int.Parse(inBookPrice.Value);
                    book.BookQuantity = int.Parse(inBookQuantity.Value);
                    book.BookDiscount = int.Parse(inBookDiscount.Value);

                    book.AuthorID = inAuthor.SelectedValue;
                    book.CategoryID = inCategory.SelectedValue;
                    book.ProducerID = inProducer.SelectedValue;

                    book.Pages = int.Parse(inPages.Value);
                    book.Size = inSize.Value;
                    book.Year = int.Parse(inYear.Value);
                    book.Description = inDescription.Value;

                    dao.addBook(book);
                }
            }
            if (mode == "edit")
            {
                Book book = new Book();
                book.BookID = inBookID.Value;
                book.BookName = inBookName.Value;
                book.BookPrice = int.Parse(inBookPrice.Value);
                book.BookQuantity = int.Parse(inBookQuantity.Value);
                book.BookDiscount = int.Parse(inBookDiscount.Value);

                book.AuthorID = inAuthor.SelectedValue;
                book.CategoryID = inCategory.SelectedValue;
                book.ProducerID = inProducer.SelectedValue;

                book.Pages = int.Parse(inPages.Value);
                book.Size = inSize.Value;
                book.Year = int.Parse(inYear.Value);
                book.Description = inDescription.Value;

                dao.updateBook(book);
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
            BookDAO dao = new BookDAO();

            Book book = new Book();
            book.BookName = inBookName.Value;
            book.BookPrice = int.Parse(inBookPrice.Value);
            book.BookQuantity = int.Parse(inBookQuantity.Value);
            book.BookDiscount = int.Parse(inBookDiscount.Value);
            dao.deleteBook(book);

            init();
            bindData();
        }
    }
}