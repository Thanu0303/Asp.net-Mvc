using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username is required")]
        [MinLength(5, ErrorMessage ="Username should be atleast 5 letters")]
        [Display(Name ="User Name :")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set; }

        [Display(Name = "Keep me Signed In")]
        
        public bool RememberMe { get; set; }
    }
}