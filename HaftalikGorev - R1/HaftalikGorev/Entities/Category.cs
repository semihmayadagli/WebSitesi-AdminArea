using System.ComponentModel.DataAnnotations;

namespace HaftalikGorev.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name ="Adı")]
        public string Name{ get; set; }
        [Display(Name ="Aciklama")]
        public string? Description { get; set; }
        [Display(Name ="Oluşturma Tarihi")]
        public DateTime? CreateDate{ get; set; }=DateTime.Now;
        public virtual List<Product> Products { get; set; }
    }
}
