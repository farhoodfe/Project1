using Project1.Models;
using System.ComponentModel.DataAnnotations;

namespace Project1
{
    public class WeatherInfo
    {
        public int Id  { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public string? City { get; set; }
        [Required(ErrorMessage = "شهر الزامی است")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}