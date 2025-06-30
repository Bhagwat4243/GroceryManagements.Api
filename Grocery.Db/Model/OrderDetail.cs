using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Db.Model
{
    public class OrderDetail: GroceryBase
    {
        [Key]
        public int Id { get; set; }
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
