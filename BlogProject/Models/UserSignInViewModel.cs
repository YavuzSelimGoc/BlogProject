using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanici adini girinss.")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen sifrenizi girinss.")]

        public string password { get; set; }
    }
}
