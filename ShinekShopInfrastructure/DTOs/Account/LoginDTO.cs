using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopInfrastructure.DTOs.Account
{
    public class LoginDTO
    {
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "")]
        [MaxLength(11, ErrorMessage = "")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string? ReturnUrl { get; set; }
    }
}
