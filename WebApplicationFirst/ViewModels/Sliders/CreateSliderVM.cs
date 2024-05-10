using System.ComponentModel.DataAnnotations;

namespace WebApplicationFirst.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(32,ErrorMessage ="Maksimal uzunluq 32 simvoldan cox ola bilmez"), Required]
        public string Title { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        [MaxLength(64), Required]
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
