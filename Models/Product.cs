using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "FirstName must contains at least 2 charcters")]
        public string ProductName { get; set; }
        [Required]
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int StatusID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
    }

    [Keyless]
    public class ProductInfo
    {
        public string StatusName { get; set; }
        public int ProductCount { get; set; }
    }
}

