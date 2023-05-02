using System.ComponentModel.DataAnnotations;

namespace HaftalikGorev.Entities
{
    public class User
    {
        public int Id{ get; set; }
        [Display(Name = "Adı")]
        public string Name{ get; set; }
        [Display(Name = "Soyad")]
        public string? Surname { get; set; }
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir adres girin.")]
        public string? Email { get; set; }
        
        [Display(Name = "Telefon")]
        public string? Phone{ get; set; }
        [Display(Name = "Şifre")]
        public string Password{ get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreateDte { get; set; } = DateTime.Now;
        [Display(Name ="Durum")]
        public bool IsActive{ get; set; }
        [Display(Name ="Admin")]
        public bool IsAdmin { get; set; }

    }
}
