using System;
namespace TopStyleAPI.Repos.Dto
{
    public class CustomerInsertResponseDTO
    {
        // En transportklass som är det format som
        // web api: et skickar tillbaka data i

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
    }
}

