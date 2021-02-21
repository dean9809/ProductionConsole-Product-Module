using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProductionConsole_Product_Module
{
    public class ProductManagement
    {

        private List<Products> _ProductList = new List<Products>();
        public List<Products> ProductList
        {
            get { return _ProductList; }
            set { this._ProductList = value; }
        }
        public List<Products> TempSearchList = new List<Products>();
        private int ListCount = 0;

       public void TESTMASSCREATE()
        {//Creates bunch of objects and adds them to a list. the "an" is a string from int q. each loop adds +1 to q .
            //ONLY USED DURING TESTING
            int i;
            int q = 1;
            string pn = "test";
            string rev = "Rev";
            for (i = 1; i <= 3; i++) { ++q; ListIDGenerator(); int lID = ListCount; string an = q.ToString(); Products product = new Products(pn, rev, an, lID); ProductList.Add(product);  }
        }
       
        public void CreateNewProduct() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Product Creation");
            Console.ResetColor();
            Console.Write("Product Name:");
            var pn = Console.ReadLine();
            Console.Write("Revision:");
            var rev = Console.ReadLine();
            Console.Write("Article Number:");
            var an = Console.ReadLine();
            ListIDGenerator();  //generates unique ID
            var lID = ListCount;
            Products product = new Products(pn, rev, an, lID); 
            ProductList.Add(product);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product Created. Press any key to return");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void EditExistingProduct()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Product Editor");
            Console.ResetColor();
            Console.WriteLine("Press 1 to search by ID");
            Console.WriteLine("Press 2 to search by Product Name");
            Console.WriteLine("Press 3 to search by Article Number");
            string selection = Console.ReadLine();
            var item = ProductList.FirstOrDefault();
            switch (selection)
                {
                case "1":
                    Console.Write("Search for an ID: ");
                    
                    string lIDsearch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(lIDsearch)) { return; }
                    try // Input validation and conversion to int
                    {
                        int lIDsearchInt = Int32.Parse(lIDsearch);
                        item = ProductList.FirstOrDefault(o => o.ListID == lIDsearchInt);
                        if (item == null) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Search failed to find a match. Press any key to return to the main menu"); Console.ReadKey(); return; }
                        TempSearchList.Add(item);
                    }
                    catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid Search. Check that you are only using intergers."); Console.ReadKey(); Console.ResetColor(); return; } //Failed search 
                    break;
                case "2":
                    Console.Write("Search for a Product Name: ");
                    string pnSearch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(pnSearch)) { return; }
                    item = ProductList.FirstOrDefault(o => o.ProductName == pnSearch);
                    if (item == null) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Search failed to find a match. Press any key to return to the main menu"); Console.ReadKey(); return; }
                    TempSearchList.Add(item);
                    break;
                case "3":
                    Console.Write("Search for an Article Number: ");
                    string anSearch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(anSearch)) { return; }
                    item = ProductList.FirstOrDefault(o => o.ArticleNumber == anSearch);
                    if (item == null) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Search failed to find a match. Press any key to return to the main menu"); Console.ReadKey(); return; }
                    TempSearchList.Add(item);
                    break;
                default:
                    return;
            }
            Console.WriteLine();
            ShowSearchedProduct();
            TempSearchList.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Leave blank to keep original values.\n");
            Console.ResetColor();

            Console.Write("New product name: ");
            string pnnew = Console.ReadLine();
            Console.Write("New revision: ");
            string revnew = Console.ReadLine();
            Console.Write("New article number: ");
            string annew = Console.ReadLine();
            if (item != null)
                    {
                        if (!string.IsNullOrWhiteSpace(pnnew))
                        { item.ProductName = pnnew; }
                        if (!string.IsNullOrWhiteSpace(revnew))
                        { item.Revision = revnew; }
                        if (!string.IsNullOrWhiteSpace(annew))
                        { item.ArticleNumber = annew; }
                        { item.DateEdited = DateTime.Now.ToString() ; }
                        TempSearchList.Add(item);
                Console.Clear();
                        ShowEditedProduct();
                        TempSearchList.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Edit successful. Press any key to return");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Search failed to find a match. Press any key to return to the main menu"); Console.ReadKey(); return; }//failed search message
        } //finds an existing product via a search for name, id or art no. Edits values and updates them

        public void ShowAllProducts() //shows all products saved in the list
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Existing Products");
            Console.ResetColor();
            //int i = 0;  //change to list count
            foreach (var product in ProductList)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ID: {0} ", product.ListID);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine(" PRODUCT NAME: {0} \n REVISION: {1} \n ARTICLE NUMBER: {2} \n DATE CREATED: {3}", product.ProductName, product.Revision, product.ArticleNumber, product.DateCreated);

                if(product.DateEdited != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" LAST EDITED: ");
                    Console.Write("{0}", product.DateEdited);
                    Console.WriteLine();
                    Console.ResetColor();

                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("End of list. Press any key to return");
            Console.ResetColor();
            Console.ReadKey();

        }

        public void ShowSearchedProduct() //shows searched product
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Existing Products");
            Console.ResetColor();
            foreach (var product in TempSearchList)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ID: {0} ", product.ListID);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine(" PRODUCT NAME: {0} \n REVISION: {1} \n ARTICLE NUMBER: {2} \n DATE CREATED: {3}", product.ProductName, product.Revision, product.ArticleNumber, product.DateCreated);

                if (product.DateEdited != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" LAST EDITED: ");
                    Console.Write("{0}", product.DateEdited);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
        public void ShowEditedProduct() //shows all products saved in the list
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Edited Product");
            Console.ResetColor();
            foreach (var product in TempSearchList)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ID: {0} ", product.ListID);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine(" PRODUCT NAME: {0} \n REVISION: {1} \n ARTICLE NUMBER: {2} \n DATE CREATED: {3}", product.ProductName, product.Revision, product.ArticleNumber, product.DateCreated);

                if (product.DateEdited != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" LAST EDITED: ");
                    Console.Write("{0}", product.DateEdited);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }
        public void ListIDGenerator() //generates an ID for each new product in the list
        {
                ListCount++;
        }
        public void StartUpListCount()//Counts all files in the list at the beginning of the program
        {
            /*foreach (var product in ProductList)
            { ListIDGenerator(); }*/
            int max = ProductList.Max(t => t.ListID);
            //int maxInt = Int32.Parse(max);
            ListCount = max;

        }
        public void SaveProductList() //Saves the product list to a txt file
        {
            using (StreamWriter sw = new StreamWriter("ProductList.txt"))
            {
                foreach (var product in ProductList)
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5}", product.ListID, product.ProductName, product.Revision, product.ArticleNumber, product.DateCreated, product.DateEdited);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saving Complete. Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void LoadProductList() //loads all saved products from the txt file and sets ListCount
        {
            using (StreamReader sr = new StreamReader("ProductList.txt"))
            {
                string textLine;
                ProductList.Clear();
                while ((textLine = sr.ReadLine()) != null)
                {
                    string[] ta = textLine.Split(",");
                    var pn = ta[1]; var rev = ta[2]; var an = ta[3]; var dTN = ta[4]; var slID = ta[0]; var dE = ta[5];
                    int lID = Int32.Parse(slID);
                    Products product = new Products(pn, rev, an, dTN, lID, dE);
                    ProductList.Add(product);
                }
                StartUpListCount();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading Complete. Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
