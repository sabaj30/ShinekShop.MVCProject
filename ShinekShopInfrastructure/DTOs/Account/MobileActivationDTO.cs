using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopInfrastructure.DTOs.Account
{
    public class MobileActivationDTO
    {
        [Display(Name = "کد فعالسازی")]
        [Required(ErrorMessage = "")]
        [MaxLength(5, ErrorMessage = "")]
        public required string ActivationCode { get; set; }
    }
}
