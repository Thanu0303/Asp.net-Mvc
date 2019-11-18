using MvcWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MvcWithWebApi.Controllers
{
    public class CategoryProductController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        private NorthwindEntities2 db2 = new NorthwindEntities2();

        // GET: api/CategoryProduct
        public IQueryable<Category> GetCategories()
        {
            //fill code to retrive all the Categoies
            return db2.Categories;
        }

        [ResponseType(typeof(Category))]     
        public IHttpActionResult GetProductByCategory(int id)
        {
            if (id < 0 || id > 8)
            {
                return BadRequest();
            }
            NorthwindEntities entities = new NorthwindEntities();
            var query = from c in entities.Products
                        where c.CategoryID == id
                        select c;
            return Ok(query);
            //fill in the code to retrive products on category id
        }

        

    }
}
