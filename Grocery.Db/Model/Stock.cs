using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Db.Model
{
    public class Stock: GroceryBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string DeelerName { get; set; }
        public decimal Quantity { get; set; }
        public decimal CostPerQuantity { get; set; }
        public decimal TotalCost { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
