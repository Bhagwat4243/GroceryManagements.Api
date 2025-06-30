using Grocery.Db.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Db.ContextFolder
{
    public class CollectionContext:DbContext
    {
        public CollectionContext( DbContextOptions<CollectionContext>option):base(option) 
        {
            
        }
        public DbSet<Category> CategoryTbl { get; set; }
        public DbSet<Item> ItemTbl { get; set; }
        public DbSet<Stock> StockTbl { get; set; }
        public DbSet<Customer> CustomerTbl { get; set; }
        public DbSet<Order> OrderTbl { get; set; }
        public DbSet<OrderDetail> OrderDetailsTbl { get; set; }
    }
}
