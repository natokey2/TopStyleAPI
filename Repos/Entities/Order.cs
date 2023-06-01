using System;
namespace TopStyleAPI.Repos.Entities
{
	public class Order
	{
        public int OrderId { get; set; }
        public string ?Name { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }


    }
}

