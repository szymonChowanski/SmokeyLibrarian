using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using SmokeyLibrarian.EF;

namespace SmokeyLibrarian
{
    
    
    class Program
    {
        
        static void Main()
        {
            //using(var context = new BooksyDBEntities())
            //{
            //    try
            //    {
            //        foreach(BOOKS b in context.BOOKS.Where(b => b.AUTHOR=="Andrzej Pilipiuk"))
            //        {
            //            Console.WriteLine(b.TITLE);
            //        }
            //    }

            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            //Console.ReadKey();

            Console.WriteLine(DataLayer.AddUser("Marek"));
            Console.WriteLine(DataLayer.AddUser("Janek"));
            Console.WriteLine(DataLayer.AddUser("Jarek"));
            Console.WriteLine(DataLayer.AddUser("Darek"));
            Console.WriteLine(DataLayer.AddUser("Czarek"));
            
            Console.ReadKey();
        }


    }

}
