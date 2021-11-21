using System.ComponentModel.DataAnnotations;

namespace WebMvc1.Models
{
    public class NameFormModel
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Repeat")]
        [Range(1,5)]
        public int Repeat { get; set; }
    }
}
