using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Dto
{
    public class OrderDto: GroceryBaseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public ICollection<OrderDetailDto> OrderDetailsDto { get; set; } = new List<OrderDetailDto>();
    }
}
