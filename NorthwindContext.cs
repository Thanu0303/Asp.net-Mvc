using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class NorthwindContext: System.Data.Entity.DbContext
    {
        //define a database set whose name should match with the physical table name
        // property name should be a plural of the conceptual class[product.cs]
        public System.Data.Entity.DbSet<MvcApplication.Models.Product> Products { get; set; }

        // create a connection string with a "NorthwindContext" name
        // this connstr should be defined in applications/web.config

    }
}