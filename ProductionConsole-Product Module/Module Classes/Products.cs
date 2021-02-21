using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionConsole_Product_Module
{
    public class Products
    {
        private string _ProductName { get; set; }
        private string _Revision { get; set; }
        private string _ArticleNumber { get; set; }
        private string _DateCreated { get; set; }
        private string _DateEdited { get; set; }
        private int _ListID { get; set; }

        public string ProductName
        {
         get{return _ProductName;}
         set{_ProductName = value;}
        }
        public string ArticleNumber
        {
            get{return _ArticleNumber;}
            set{_ArticleNumber = value;}
        }
        public string Revision
        {
            get{return _Revision;}
            set{_Revision = value;}
        }
        public string DateCreated
        {
            get{return _DateCreated;}
            set{ _DateCreated = value; }
        }
        public string DateEdited
        {
            get { return _DateEdited; }
            set { _DateEdited = value; }
        }
        public int ListID
        {
            get { return _ListID; }
            set { _ListID = value; }
        }
        public Products (string pn, string rev, string an, int lID)
        {
            this.ProductName = pn;
            this.Revision = rev;
            this.ArticleNumber = an;
            this.DateCreated = DateTime.Now.ToString();
            this.ListID = lID;
        }
        public Products(string pn, string rev, string an, string dTN, int lID, string dE)
        {
            
            this.ProductName = pn;
            this.Revision = rev;
            this.ArticleNumber = an;
            this.DateCreated = dTN;
            this.ListID = lID;
            this.DateEdited = dE; 
        }
    }
}
