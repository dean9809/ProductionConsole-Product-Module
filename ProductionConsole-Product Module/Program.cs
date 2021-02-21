using System;

namespace ProductionConsole_Product_Module
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ProductManagement cmd = new ProductManagement();
            cmd.LoadProductList();
            do
            {
                Console.Clear();
                ShowMenu();
                var selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        cmd.CreateNewProduct();
                        break;
                    case "2":
                        cmd.ShowAllProducts();
                        break;
                    case "3":
                        cmd.EditExistingProduct();
                        break;
                    case "4":
                        Console.WriteLine("Type YES to load. Leave blank to cancle");
                        string loadYES = Console.ReadLine();
                        if ((loadYES != "YES")) { Console.ForegroundColor = ConsoleColor.Red; 
                                                  Console.WriteLine("Loading failed. Press any key to continue...");
                                                  Console.ReadKey(); Console.ResetColor(); break; }
                        else
                        cmd.LoadProductList();
                        break;
                    case "5":
                        cmd.SaveProductList();
                        break;
                    case "Q":
                        return;
                    case "q":
                        return;
                }
                

            } while (true);
            //cmd.CreateNewProduct();
            //cmd.TESTMASSCREATE();  

            static void ShowMenu()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Main Menu");
                Console.ResetColor();
                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Press 2 to view all products");
                Console.WriteLine("Press 3 to edit an existing product");
                Console.WriteLine("Press 4 to load all saved products");
                Console.WriteLine("Press 5 to save all products");
                Console.WriteLine("Press Q to exit");
            }
        }
    }
}
