using Microsoft.AspNetCore.Identity;
using SignalR_Project.Core.Commons;
using SignalR_Project.Core.Enum;
using System.Data;
using System.Text.RegularExpressions;

namespace SignalR_Project.Core.Entities
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {

        private string _name;
        private string _surname;

        public AppUser() { }

        public AppUser(string name, string surname, string userEmail, string userName)
        {
            Name = name;
            Surname = surname;
            Email = userEmail;
            UserName = userName;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("İsim boş bırakılamaz.");

                if (value.Length < 3 || value.Length > 20)
                    throw new ArgumentException("İsim 3 ile 20 karakter arasında olmalıdır.");

                if (!Regex.IsMatch(value, @"^[a-zA-ZğüşöçİĞÜŞÖÇ\s]+$"))
                    throw new ArgumentException("İsim sadece harf içermelidir. Sayı veya noktalama işareti içeremez.");

                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Soyisim boş bırakılamaz.");

                if (value.Length < 3 || value.Length > 20)
                    throw new ArgumentException("Soyisim 3 ile 20 karakter arasında olmalıdır.");

                if (!Regex.IsMatch(value, @"^[a-zA-ZğüşöçİĞÜŞÖÇ\s]+$"))
                    throw new ArgumentException("Soyisim sadece harf içermelidir. Sayı veya noktalama işareti içeremez.");

                _surname = value;
            }
        }

        public string? Image { get; set; } = "/images/userProfile/defaut-profile.png";

        public GenderEnum? Gender { get; set; } = GenderEnum.Undefined;

        // IBaseEntity'den gelenler
        Guid IBaseEntity.Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public void Restore()
        {
            if (IsDeleted)
            {
                IsDeleted = false;
                UpdatedDate = DateTime.Now;
            }
        }
        public void SoftDelete()
        {
            if (!IsDeleted)
            {
                IsDeleted = true;
                DeletedDate = DateTime.Now;
            }
        }

        public void Update() => UpdatedDate = DateTime.Now;
    }
}
