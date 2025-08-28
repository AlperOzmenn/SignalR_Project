using System.ComponentModel.DataAnnotations;

namespace SignalR_Project.Core.Enum
{
   public enum MessageStatus
    {
        [Display (Name = "Gönderildi")]
        Sent = 1,

        [Display (Name = "Beklemede")]
        Pending = 2
    }
}
