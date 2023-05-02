using System.ComponentModel.DataAnnotations;

namespace HaftalikGorev.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name ="Marka Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime? CreateDate{ get; set; }= DateTime.Now;
        [Display(Name = "Logo")]
        public string? Logo{ get; set; }
        [Display(Name = "Durum")]
        public bool isActive { get; set; }
    }
}
