using System.ComponentModel.DataAnnotations;

namespace WebMvc1.Models
{
    public class BirthDateFormModel
    {
        [Display(Name = "Days since birth")]
        public System.DateTime BirthDate { get; set; }
    }
}
