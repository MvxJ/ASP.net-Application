using System;
using System.ComponentModel.DataAnnotations;


namespace WebMvc1.Models
{
    public class FilmsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
