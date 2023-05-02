using System.ComponentModel.DataAnnotations;

namespace HaftalikGorev.Entities
{
    public class Slider
    {
        public int Id{ get; set; }
        [Display(Name ="Resim")]
        public string? Image { get; set; }
    }
}
