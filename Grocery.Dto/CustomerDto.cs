using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Dto
{
    public class CustomerDto: GroceryBaseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        public string MobileNo { get; set; }
    }
}
