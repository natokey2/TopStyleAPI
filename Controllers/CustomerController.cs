using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TopStyleAPI.Repos.Dto;
using TopStyleAPI.Repos.Entities;
using TopStyleAPI.Data.Interfaces;
using System.Configuration;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ProductContext _db;
    private readonly ICustomerRepo _customerRepo;

    public CustomerController(ProductContext db, ICustomerRepo customerRepo)
    {
        _db = db;

        _customerRepo = customerRepo;
    }


    [HttpPost("Login")]
    public IActionResult Login([FromBody] CustomerLoginInputDTO customerInput)
    {
        if (customerInput == null)
        {
            return BadRequest("Please send the right input");
        }

        using (var context = new ProductContext()) 
        
        {
            var customer = _db.Customers
                .FirstOrDefault(c => c.Email == customerInput.Email && c.Password == customerInput.Password);

            if (customer == null)
            {
                return NotFound("Invalid credentials");
            }

            return Ok(customer);
        }
    }


    [HttpPost("InsertCustomer")]
    public IActionResult InsertCustomer([FromBody] CustomerInsertInputDTO customerInsert)
    {
        if (customerInsert == null)
        {
            return BadRequest("Please send the right input");
        }

        using (var context = new ProductContext()) 
        {
            var newCustomer = new Customer
            {
                CustomerName = customerInsert.CustomerName,
                Email = customerInsert.Email,
                Password= customerInsert.Password
                
                
            };

            _db.Customers.Add(newCustomer);
            _db.SaveChanges();

            return Ok(new
            {
                successMessage = "Customer inserted successfully"
            });
        }

       
       
    }
}

