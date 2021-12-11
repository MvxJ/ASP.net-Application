using System;
using System.ComponentModel.DataAnnotations;


namespace WebMvc1.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public decimal Millage { get; set; }
        public DateTime ManufactureDate { get; set; }
    }
}
