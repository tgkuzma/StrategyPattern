using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    //[Table("customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public DateTime DateActive { get; set; }

        public string Address { get; set; }
    }
}
