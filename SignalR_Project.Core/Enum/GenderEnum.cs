using System.ComponentModel.DataAnnotations;

namespace SignalR_Project.Core.Enum
{
    public enum GenderEnum
    {
        [Display(Name = "Belirtilmemiş")]
        Undefined = 0,

        [Display(Name = "Kadın")]
        Female = 1,

        [Display(Name = "Erkek")]
        Male = 2
    }
}
