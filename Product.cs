using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models
{
    public class Product
    {
        //Sql server ==> .NEt
        //int --> int, smallint--> short, tinyInt-->byte, bigint-->long,
        //numeric-->flaot/double,float-->float, money--> decimal,
        //char,nchar,varcahr--> string, binary--> byte[],bit--> boolean,
        //datetime-->Datetime

            // conceptual schema is below one
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 chars.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
    }
}