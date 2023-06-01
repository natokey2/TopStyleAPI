using System;
namespace TopStyleAPI.Repos.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }
		public String ? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
    }
}

