using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name="Логин")]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name="Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
