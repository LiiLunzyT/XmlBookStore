using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using BTNhom2019.Model;

namespace BTNhom2019.DAO
{
    public class AuthorDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        readonly String connectString = "~/App_Data/BookStore.xml";

        public AuthorDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Authors");
        }

        public Author GetAuthorByID(String AuthorID)
        {
            XmlNode nAuthor = root.SelectSingleNode("Author[AuthorID = '" + AuthorID + "']");
            Author author = new Author
            {
                AuthorID = nAuthor["AuthorID"].InnerText.ToString(),
                AuthorName = nAuthor["AuthorName"].InnerText.ToString(),
                AuthorContact = nAuthor["AuthorContact"].InnerText.ToString()
            };
            return author;
        }

        public Author GetAuthorByIndex(int index)
        {
            XmlNode nAuthor = root.ChildNodes[index];
            Author author = new Author
            {
                AuthorID = nAuthor["AuthorID"].InnerText.ToString(),
                AuthorName = nAuthor["AuthorName"].InnerText.ToString(),
                AuthorContact = nAuthor["AuthorContact"].InnerText.ToString()
            };
            return author;
        }

        public void AddAuthor(Author author)
        {
            XmlNode nAuthor = root.ChildNodes[0];
            XmlNode newAuthor = nAuthor.CloneNode(true);
            newAuthor["AuthorID"].InnerText = author.AuthorID;
            newAuthor["AuthorName"].InnerText = author.AuthorName;
            newAuthor["AuthorContact"].InnerText = author.AuthorContact;
            root.AppendChild(newAuthor);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void DeleteAuthor(Author author)
        {
            String AuthorID = author.AuthorID;
            XmlNode nAuthor = root.SelectSingleNode("Author[AuthorID = '" + AuthorID + "']");
            root.RemoveChild(nAuthor);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void UpdateAuthor(Author author)
        {
            String AuthorID = author.AuthorID;
            XmlNode nAuthor = root.SelectSingleNode("Author[AuthorID = '" + AuthorID + "']");
            nAuthor["AuthorName"].InnerText = author.AuthorName;
            nAuthor["AuthorContact"].InnerText = author.AuthorContact;
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Author> GetListAuthors()
        {
            List<Author> listAuthors = new List<Author>();

            foreach (XmlNode node in root.ChildNodes)
            {
                Author author = new Author
                {
                    AuthorID = node["AuthorID"].InnerText.ToString(),
                    AuthorName = node["AuthorName"].InnerText.ToString(),
                    AuthorContact = node["AuthorContact"].InnerText.ToString()
                };

                listAuthors.Add(author);
            }

            return listAuthors;
        }

        public DataTable ToDataTable()
        {
            List<Author> listAuthors = GetListAuthors();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Tác giả", typeof(String));
            dt.Columns.Add("Tên Tác giả", typeof(String));
            dt.Columns.Add("Liên lạc", typeof(String));
            foreach (Author author in listAuthors)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Tác giả"] = author.AuthorID;
                dr["Tên Tác giả"] = author.AuthorName;
                dr["Liên lạc"] = author.AuthorContact;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public String GenMaxID()
        {
            if (root.ChildNodes.Count == 0) return "AU-001";

            String lastID = root.LastChild["AuthorID"].InnerText.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            return "AU-" + str.PadLeft(3, '0');
        }
    }
}