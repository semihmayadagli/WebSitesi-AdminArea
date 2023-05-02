using System.ComponentModel.DataAnnotations;

namespace HaftalikGorev.Entities
{
    public class Product
    {
        public int Id{ get; set; }
        [Display(Name ="Ürün Adı")]
        public string Name{ get; set; }
        [Display(Name = "Ürün Tanımı")]
        public string? Description { get; set; }
        [Display(Name = "Fiyat")]
        public decimal? Price{ get; set; }
        [Display(Name = "Stok Durumu")]
        public int? Stock { get; set; }
        [Display(Name = "Resim")]
        public string? Image{ get; set; }
        [Display(Name = "Oluşturma Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate{ get; set; }= DateTime.Now;
        [Display(Name = "Kategori Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public Category? Category{ get; set; }
    }
}
