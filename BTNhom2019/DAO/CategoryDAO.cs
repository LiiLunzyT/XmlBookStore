using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace BTNhom2019.DAO
{
    public class CategoryDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";

        public CategoryDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Categories");
        }

        public Category getCategoryByID(String CategoryID)
        {
            XmlNode nCategory = root.SelectSingleNode("Category[@CategoryID = '" + CategoryID + "']");
            Category category = new Category();
            category.CategoryID = nCategory.Attributes["CategoryID"].Value.ToString();
            category.CategoryName = nCategory["CategoryName"].InnerText.ToString();
            category.CategoryDesc = nCategory["CategoryDesc"].InnerText.ToString();
            return category;
        }

        public Category getCategoryByIndex(int index)
        {
            Category category = new Category();
            XmlNode nCategory = root.ChildNodes[index];
            category.CategoryID = nCategory.Attributes["CategoryID"].Value.ToString();
            category.CategoryName = nCategory["CategoryName"].InnerText.ToString();
            category.CategoryDesc = nCategory["CategoryDesc"].InnerText.ToString();
            return category;
        }

        public void addCategory(Category category)
        {
            XmlNode nCategory = root.ChildNodes[0];
            XmlNode newCategory = nCategory.CloneNode(true);
            newCategory.Attributes["CategoryID"].Value = category.CategoryID;
            newCategory["CategoryName"].InnerText = category.CategoryName;
            newCategory["CategoryDesc"].InnerText = category.CategoryDesc;
            root.AppendChild(newCategory);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void deleteCategory(Category category)
        {
            String CategoryID = category.CategoryID;
            XmlNode nCategory = root.SelectSingleNode("Category[@CategoryID = '" + CategoryID + "']");
            root.RemoveChild(nCategory);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void updateCategory(Category category)
        {
            String CategoryID = category.CategoryID;
            XmlNode nCategory = root.SelectSingleNode("Category[@CategoryID = '" + CategoryID + "']");
            nCategory["CategoryName"].InnerText = category.CategoryName;
            nCategory["CategoryDesc"].InnerText = category.CategoryDesc;
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Category> getListCategories()
        {
            List<Category> listCategories = new List<Category>();

            foreach (XmlNode node in root.ChildNodes)
            {
                Category category = new Category();
                category.CategoryID = node.Attributes["CategoryID"].Value.ToString();
                category.CategoryName = node["CategoryName"].InnerText.ToString();
                category.CategoryDesc = node["CategoryDesc"].InnerText.ToString();

                listCategories.Add(category);
            }

            return listCategories;
        }

        public DataTable toDataTable()
        {
            List<Category> listCategories = getListCategories();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Thể loại", typeof(String));
            dt.Columns.Add("Tên Thể loại", typeof(String));
            dt.Columns.Add("Mô tả", typeof(String));
            foreach (Category category in listCategories)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Thể loại"] = category.CategoryID;
                dr["Tên Thể loại"] = category.CategoryName;
                dr["Mô tả"] = category.CategoryDesc;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public String genMaxID()
        {
            String rs = "";

            String lastID = root.LastChild.Attributes["CategoryID"].Value.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            rs = "CG-" + str.PadLeft(3, '0');

            return rs;
        }
    }
}