using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Dto
{
    public class StockDto: GroceryBaseDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string DeelerName { get; set; }
        public decimal Quantity { get; set; }
        public decimal CostPerQuantity { get; set; }
        public decimal TotalCost { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }
    }
}
