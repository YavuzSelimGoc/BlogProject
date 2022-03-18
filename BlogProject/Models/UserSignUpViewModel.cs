using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Ad Soyad Gir Lütfeeeen")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Gir Lütfeeeen")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password",ErrorMessage = "Şifreler check et")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail ")]
        [Required(ErrorMessage = "Mail Gir Lütfeen")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Kullanıcı adı Gir Lütfeeeen")]
        public string UserName { get; set; }

    }
}
