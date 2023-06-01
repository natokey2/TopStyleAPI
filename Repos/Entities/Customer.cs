using System;
using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Repos.Entities
{
	public class Customer
	{

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
    }
}

