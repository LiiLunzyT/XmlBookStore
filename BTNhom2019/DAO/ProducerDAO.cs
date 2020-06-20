using BTNhom2019.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace BTNhom2019.DAO
{
    public class ProducerDAO
    {
        public XmlDocument doc;
        public XmlNode root;
        String connectString = "~/App_Data/BookStore.xml";

        public ProducerDAO()
        {
            doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(connectString));
            root = doc.SelectSingleNode("//Producers");
        }

        public Producer getProducerByID(String ProducerID)
        {
            XmlNode nProducer = root.SelectSingleNode("Producer[ProducerID = '" + ProducerID + "']");
            Producer producer = new Producer();
            producer.ProducerID = nProducer["ProducerID"].InnerText.ToString();
            producer.ProducerName = nProducer["ProducerName"].InnerText.ToString();
            producer.ProducerAddress = nProducer["ProducerAddress"].InnerText.ToString();
            producer.ProducerContact = nProducer["ProducerContact"].InnerText.ToString();
            return producer;
        }

        public Producer geProducerByIndex(int index)
        {
            Producer producer = new Producer();
            XmlNode nProducer = root.ChildNodes[index];
            producer.ProducerID = nProducer["ProducerID"].InnerText.ToString();
            producer.ProducerName = nProducer["ProducerName"].InnerText.ToString();
            producer.ProducerContact = nProducer["ProducerAddress"].InnerText.ToString();
            producer.ProducerAddress = nProducer["ProducerContact"].InnerText.ToString();
            return producer;
        }

        public void addProducer(Producer producer)
        {
            XmlNode nProducer = root.ChildNodes[0];
            XmlNode newProducer = nProducer.CloneNode(true);
            newProducer["ProducerID"].InnerText = producer.ProducerID;
            newProducer["ProducerName"].InnerText = producer.ProducerName;
            newProducer["ProducerAddress"].InnerText = producer.ProducerAddress.ToString();
            newProducer["ProducerContact"].InnerText = producer.ProducerContact.ToString();
            root.AppendChild(newProducer);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));

        }

        public void deleteProducer(Producer producer)
        {
            String ProducerID = producer.ProducerID;
            XmlNode nProducer = root.SelectSingleNode("Producer[ProducerID = '" + ProducerID + "']");
            root.RemoveChild(nProducer);
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public void updateProducer(Producer producer)
        {
            String ProducerID = producer.ProducerID;
            XmlNode nProducer = root.SelectSingleNode("Producer[ProducerID = '" + ProducerID + "']");
            nProducer["ProducerName"].InnerText = producer.ProducerName.ToString();
            nProducer["ProducerAddress"].InnerText = producer.ProducerAddress.ToString();
            nProducer["ProducerContact"].InnerText = producer.ProducerContact.ToString();
            doc.Save(HttpContext.Current.Server.MapPath(connectString));
        }

        public List<Producer> getListProducers()
        {
            List<Producer> listProducers = new List<Producer>();

            foreach (XmlNode node in root.ChildNodes)
            {
                Producer producer = new Producer();
                producer.ProducerID = node["ProducerID"].InnerText.ToString();
                producer.ProducerName = node["ProducerName"].InnerText.ToString();
                producer.ProducerContact = node["ProducerContact"].InnerText.ToString();
                producer.ProducerAddress = node["ProducerAddress"].InnerText.ToString();

                listProducers.Add(producer);
            }

            return listProducers;
        }

        public DataTable toDataTable()
        {
            List<Producer> listProducers = getListProducers();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhà xuất bản", typeof(String));
            dt.Columns.Add("Tên Nhà xuất bản", typeof(String));
            dt.Columns.Add("Liên Hệ", typeof(String));
            dt.Columns.Add("Địa Chỉ", typeof(String));
            foreach (Producer producer in listProducers)
            {
                DataRow dr = dt.NewRow();
                dr["Mã Nhà xuất bản"] = producer.ProducerID;
                dr["Tên Nhà xuất bản"] = producer.ProducerName;
                dr["Liên Hệ"] = producer.ProducerContact;
                dr["Địa Chỉ"] = producer.ProducerAddress;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public String genMaxID()
        {
            if (root.ChildNodes.Count == 0) return "PD-001";

            String lastID = root.LastChild["ProducerID"].InnerText.ToString();
            int num = int.Parse(lastID.Split('-')[1]);
            String str = "" + (num + 1);
            return "PD-" + str.PadLeft(3, '0');
        }
    }
}