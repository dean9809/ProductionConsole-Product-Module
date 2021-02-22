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
                        cmd.DeleteExistingProduct();
                        break;
                    case "5":
                        Console.WriteLine("Type LOAD to load. Leave blank to cancle");
                        string loadYES = Console.ReadLine();
                        if ((loadYES != "LOAD"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Loading cancled. Press any key to continue...");
                            Console.ReadKey(); Console.ResetColor();
                            break;
                        }
                        else
                            cmd.LoadProductList();
                        break;
                    case "6":
                        Console.WriteLine("Type SAVE to save product list. Leave blank to cancle");
                        string saveYES = Console.ReadLine();
                        if ((saveYES != "SAVE"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Saving cancled. Press any key to continue...");
                            Console.ReadKey(); Console.ResetColor();
                            break;
                        }
                        else
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
                Console.WriteLine("Press 4 to delete an existing product");
                Console.WriteLine("Press 5 to load all saved products");
                Console.WriteLine("Press 6 to save all products");
                Console.WriteLine("Press Q to exit");
            }
        }
    }
}
