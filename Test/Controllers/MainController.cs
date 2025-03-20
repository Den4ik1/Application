using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [Route("/api/[controller]")]
    public class MainController : Controller
    {
        [HttpGet("GetAll")]
        public List<ViewModel> GetAll()
        {
            var result = new List<ViewModel>
            {  new ViewModel
                {
                    Id = 1,
                    Name = "123"
                }
            };

            return result;
        }

        [HttpGet("GetById")]

        public ViewModel GetById (int id) 
        {
            return new ViewModel
            {
                Id = 1,
                Name = "123"
            };
        }
    }
}
