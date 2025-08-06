using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopInfrastructure.DTOs.Account
{
    public class RegisterUserDTO
    {
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "")]
        [MaxLength(11, ErrorMessage = "")]
        public string PhoneNumber { get; set; }
    }
}
