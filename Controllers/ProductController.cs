using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Repos.Entities;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _db;

        public ProductController(ProductContext db)
        {
            _db = db;
        }
        //[HttpGet]
        //public IActionResult GetProduct()
        //{
        //    var result = _db.Products.ToList();

        //    LINQfuncationRead();


        //    return Ok(result);
        //}
        //private void LINQfuncationRead()
        //{
        //    var productWithCategory = _db.Products
        //                             .Include(e => e.Category)
        //                             .ToList();


        //    var productFun = _db.Products.Where(e => e.Category.CategoryId == 1).ToList();

        //    var categoryList = _db.Categories.ToList();

        //    var categoyFun = _db.Categories.Where(o => o.CategoryId == 1).ToList();
        //}

        [HttpGet]
        public IActionResult GetProducts()
        {
            using (var dbContext = new ProductContext())
            {
                var products = _db.Products.ToList();

                return Ok(products);
            }
        }



        [HttpGet("search")]
        public IActionResult SearchProducts(string name)
        {
            using (var dbContext = new ProductContext())
            {
                var matchingProducts = _db.Products.Where(p => p.ProductName == name).ToList();

                return Ok(matchingProducts);
            }
        }




        [HttpPost]
        public IActionResult InsertProduct()
        {
            // Create a new Product
            Product newProduct = new Product();
            newProduct.ProductName = "New Product";
            newProduct.Description = "nice matreal";
            newProduct.Price = 5000;
            newProduct.CategoryId = 3;



            // Create a new Category
            Category newCategory = new Category();
            newCategory.CategoryName = "New Product";



            // Add the new Product and Category to the DbContext
            _db.Products.Add(newProduct);
            _db.Categories.Add(newCategory);

            // Save changes to the database
            _db.SaveChanges();

            // Retrieve the generated IDs
            var productId = newProduct.ProductId;
            var categoryId = newCategory.CategoryId;

            return Ok("Product and Category inserted successfully.");
        }




    }
}
