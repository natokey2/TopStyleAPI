using System;
using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Repos.Dto
{
    public class CustomerInsertInputDTO
    {
        [Required]
        [StringLength(40)]
        public string? CustomerName { get; set; }
        [Required]
        [StringLength(40)]
        public string? Email { get; set; }
        [Required]
        [StringLength(30)]
        public string? Password { get; set; }
    }
}

