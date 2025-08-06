using ShinekShopInfrastructure.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopInfrastructure.DTOs.Account
{
    public class EdditUserInformationDTO
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "")]
        [MaxLength(11, ErrorMessage = "")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "")]
        public string? EmailAddress { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "")]
        [MaxLength(10, ErrorMessage = "")]
        public string PostCode { get; set; } = string.Empty;
    }
}
