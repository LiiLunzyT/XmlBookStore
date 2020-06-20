using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace BTNhom2019.DAO
{
    public class BookDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        readonly String connectString = "~/App_Data/BookStore.xml";

        public BookDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Books");
        }

        public Book GetBookByID(String BookID)
        {
            XmlNode nBook = root.SelectSingleNode("Book[BookID = '" + BookID + "']");
            XmlNode nBookInfo = nBook["BookInfo"];
            Book book = new Book();
            book.BookID = nBook["BookID"].InnerText.ToString();
            book.BookName = nBook["BookName"].InnerText.ToString();
            book.BookPrice = int.Parse(nBook["BookPrice"].InnerText.ToString());
            book.BookQuantity = int.Parse(nBook["BookQuantity"].InnerText.ToString());
            book.BookDiscount = int.Parse(nBook["BookDiscount"].InnerText.ToString());

            book.Pages = int.Parse(nBookInfo["Pages"].InnerText);
            book.Size = nBookInfo["Size"].InnerText;
            book.Year = int.Parse(nBookInfo["Year"].InnerText);
            book.Description = nBookInfo["Description"].InnerText;

            book.AuthorID = nBook["AuthorID"].InnerText;
            book.CategoryID = nBook["CategoryID"].InnerText;
            book.ProducerID = nBook["ProducerID"].InnerText;

            return book;
        }

        public Book GetBookByIndex(int index)
        {
            XmlNode nBook = root.ChildNodes[index];
            XmlNode nBookInfo = nBook["BookInfo"];
            var book = new Book
            {
                BookID = nBook["BookID"].InnerText.ToString(),
                BookName = nBook["BookName"].InnerText.ToString(),
                BookPrice = int.Parse(nBook["BookPrice"].InnerText.ToString()),
                BookQuantity = int.Parse(nBook["BookQuantity"].InnerText.ToString()),
                BookDiscount = int.Parse(nBook["BookDiscount"].InnerText.ToString()),

                Pages = int.Parse(nBookInfo["Pages"].InnerText),
                Size = nBookInfo["Size"].InnerText,
                Year = int.Parse(nBookInfo["Year"].InnerText),
                Description = nBookInfo["Description"].InnerText,

                AuthorID = nBook["AuthorID"].InnerText,
                CategoryID = nBook["CategoryID"].InnerText,
                ProducerID = nBook["ProducerID"].InnerText
            };

            return book;
        }

        public void AddBook(Book book)
        {
            XmlNode nBook = root.ChildNodes[0];
            XmlNode newBook = nBook.CloneNode(true);
            XmlNode newBookInfo = newBook["BookInfo"];
            newBook["BookID"].InnerText = book.BookID;
            newBook["BookName"].InnerText = book.BookName;
            newBook["BookPrice"].InnerText = book.BookPrice.ToString();
            newBook["BookQuantity"].InnerText = book.BookQuantity.ToString();
            newBook["BookDiscount"].InnerText = book.BookDiscount.ToString();

            newBook["CategoryID"].InnerText = book.CategoryID;
            newBook["AuthorID"].InnerText = book.AuthorID;
            newBook["ProducerID"].InnerText = book.ProducerID;

            newBookInfo["Pages"].InnerText = book.Pages.ToString();
            newBookInfo["Size"].InnerText = book.Size;
            newBookInfo["Year"].InnerText = book.Year.ToString();
            newBookInfo["Description"].InnerText = book.Description;

            newBook["BookInfo"].InnerXml = newBookInfo.InnerXml;
            root.AppendChild(newBook);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void DeleteBook(Book book)
        {
            String BookID = book.BookID;
            XmlNode nBook = root.SelectSingleNode("Book[BookID = '" + BookID + "']");
            root.RemoveChild(nBook);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }
        public void DeleteBook(String BookID)
        {
            XmlNode nBook = root.SelectSingleNode("Book[BookID = '" + BookID + "']");
            root.RemoveChild(nBook);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void UpdateBook(Book book)
        {
            String BookID = book.BookID;
            XmlNode nBook = root.SelectSingleNode("Book[BookID = '" + BookID + "']");
            XmlNode nBookInfo = nBook["BookInfo"];
            nBook["BookName"].InnerText = book.BookName;
            nBook["BookPrice"].InnerText = book.BookPrice.ToString();
            nBook["BookQuantity"].InnerText = book.BookQuantity.ToString();
            nBook["BookDiscount"].InnerText = book.BookDiscount.ToString();

            nBook["CategoryID"].InnerText = book.CategoryID;
            nBook["AuthorID"].InnerText = book.AuthorID;
            nBook["ProducerID"].InnerText = book.ProducerID;

            nBookInfo["Pages"].InnerText = book.Pages.ToString();
            nBookInfo["Size"].InnerText = book.Size.ToString();
            nBookInfo["Year"].InnerText = book.Year.ToString();
            nBookInfo["Description"].InnerText = book.Description.ToString();

            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Book> GetListBooks()
        {
            List<Book> listBooks = new List<Book>();

            foreach (XmlNode node in root.ChildNodes)
            {
                XmlNode nBookInfo = node["BookInfo"];
                Book book = new Book
                {
                    BookID = node["BookID"].InnerText.ToString(),
                    BookName = node["BookName"].InnerText.ToString(),
                    BookPrice = int.Parse(node["BookPrice"].InnerText.ToString()),
                    BookQuantity = int.Parse(node["BookQuantity"].InnerText.ToString()),
                    BookDiscount = int.Parse(node["BookDiscount"].InnerText.ToString()),

                    Pages = int.Parse(nBookInfo["Pages"].InnerText),
                    Size = nBookInfo["Size"].InnerText,
                    Year = int.Parse(nBookInfo["Year"].InnerText),
                    Description = nBookInfo["Description"].InnerText,

                    AuthorID = node["AuthorID"].InnerText,
                    CategoryID = node["CategoryID"].InnerText,
                    ProducerID = node["ProducerID"].InnerText
                };

                listBooks.Add(book);
            }

            return listBooks;
        }

        public DataTable ToDataTable()
        {
            List<Book> listBooks = GetListBooks();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Sách", typeof(String));
            dt.Columns.Add("Tên Sách", typeof(String));
            dt.Columns.Add("Gía tiền", typeof(int));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Giảm giá", typeof(int));
            foreach (Book book in listBooks)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Sách"] = book.BookID;
                dr["Tên Sách"] = book.BookName;
                dr["Gía tiền"] = book.BookPrice;
                dr["Số lượng"] = book.BookQuantity;
                dr["Giảm giá"] = book.BookDiscount;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public String GenMaxID()
        {
            if (root.ChildNodes.Count == 0) return "BK-001";

            String lastID = root.LastChild["BookID"].InnerText.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            return "BK-" + str.PadLeft(3, '0');
        }
    }
}