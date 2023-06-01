using System;
using Dapper;
using System.Data;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Repos.Dto;
using System.Data.SqlClient;
using TopStyleAPI.Repos.Entities;

namespace TopStyleAPI.Data.Repository
{

    public class CustomerRepo : ICustomerRepo

    {
        private readonly ProductContext _db;
        public CustomerRepo(ProductContext db)
        {
            _db = db;
        }

        public string InsertCustomer(CustomerInsertInputDTO customerInputDto)
        {
            using (var context = new ProductContext())
            {
                var customer = new Customer
                {
                    CustomerName = customerInputDto.CustomerName,
                    Email = customerInputDto.Email,
                    Password = customerInputDto.Password
                };

                _db.Customers.Add(customer);
                _db.SaveChanges();

                return "New User is Inserted";
            }
        }

        public CustomerResponseDto LoginCustomer(CustomerLoginInputDTO loginInputDTO)
        {
            using (var context = new ProductContext())
            {
                var customer = _db.Customers.FirstOrDefault(c => c.Email == loginInputDTO.Email && c.Password == loginInputDTO.Password);

                if (customer != null)
                {
                    var responseDto = new CustomerResponseDto
                    {
                       
                    };

                    return responseDto;
                }

                return null;
            }
        }
    }

  
}