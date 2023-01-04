using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using System.Security.Claims;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherInfoController : ControllerBase
    {
        ApiDbContext _dbContext = new ApiDbContext();

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("{city}")]
        [Authorize]
        public WeatherInfo Get(string city)
        {
            WeatherInfo wi = new WeatherInfo();
            wi.City = city;
            wi.Date = DateTime.Now;
            wi.TemperatureC = Random.Shared.Next(-20, 55);
            wi.Summary = Summaries[Random.Shared.Next(Summaries.Length)];

            var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var user = _dbContext.Users.FirstOrDefault(u=>u.Name==userName);
            wi.User = user;
            wi.UserId= user.Id;
           
            _dbContext.WeatherInfos.Add(wi);
            _dbContext.SaveChanges();
            return wi;
        }
    }
}
