using System;

namespace FacadeDesignPattern
{
    internal class Program
    {
        // a website needs to determine whether a particular product has reached
        // a low stock level.
        static void Main(string[] args)
        {
            // Application of Facade Protoype
            StockFacade facade = new StockFacade();
            bool low = facade.IsLowStock("ABC123");


            
            // Application of Prototyping 
            
            Developer dev = new Developer();
            dev.Name = "Dipak";
            dev.Role = "Team Leader";
            dev.PreferredLanguage = "Java";

            Developer devCopy = (Developer)dev.Clone();
            devCopy.Name = "Sue";

            Console.WriteLine(dev);
            Console.WriteLine(devCopy);


            Typist typist = new Typist();
            typist.Name = "Rohit";
            typist.Role = "Typist";
            typist.WordsPerMinute = 120;

            Typist typistCopy = (Typist)typist.Clone();
            typistCopy.Name = "Tim";
            typist.WordsPerMinute = 155;

            Console.WriteLine(typist);
            Console.WriteLine(typistCopy);
            

            // Factory Model
        }

        
    }

    public class Product
    {
        private int _Connection;
        private string _itemNumber;

        public Product(string itemNumber, int Connection)
        {
            _Connection = Connection;
            _itemNumber = itemNumber;
        }

        public int PhysicalStock
        {
            get
            {
                return 95;
                // asssume 95 is current level.
                // Retrieve stock level from database.
            }
        }

        public int StockOnOrder
        {
            get
            {
                return 10;
                // assume 10 is incoming order.
                // Retrieve incoming ordered stock from database.
            }
        }

        public int LowStockLevel
        {
            get
            {
                return 80;
                // low stock level limit = 80
                // Retrieve low stock level from database.
            }
        }
    }


    public static class StockAllocator
    {
        public static int GetAllocations(string itemNumber, int Connection)
        {
            return 40;
            // we retrieved item number and connection. 
            // Retrieve allocated stock for product from database.
        }

        // public static int GetAllocations(string itemNumber, int connection) => 1
        // best practice
    }


    public class StockFacade
    {
        public bool IsLowStock(string itemNumber)
        {
            int Connection = 1;

            Product product = new Product(itemNumber, Connection);

            int physical = product.PhysicalStock;
            int onOrder = product.StockOnOrder;
            int lowStock = product.LowStockLevel;
            int allocations = StockAllocator.GetAllocations(itemNumber, Connection);

            int available = physical + onOrder - allocations;
            Console.WriteLine(available);
            Console.WriteLine(available <= lowStock);
            return (available <= lowStock);
        }
    }
}
