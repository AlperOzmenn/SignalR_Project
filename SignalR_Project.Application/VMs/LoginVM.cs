using System.ComponentModel.DataAnnotations;

namespace SignalR_Project.Application.VMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı Adı: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [Display(Name = "Şifre: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla: ")]
        public bool RememberMe { get; set; }
    }
}
