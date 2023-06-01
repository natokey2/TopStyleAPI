using System;
using TopStyleAPI.Repos.Dto;

namespace TopStyleAPI.Data.Interfaces
{
    public interface ICustomerRepo
    {
        public CustomerResponseDto LoginCustomer(CustomerLoginInputDTO loginInputDTO);

        public string InsertCustomer(CustomerInsertInputDTO customerInputDto);

    }
}

