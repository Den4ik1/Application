using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("/api/[controller]")]
    public class PartnerController : Controller
    {

        [HttpPost("/api.user.partner.rememberMe")]
        public void RememberMe(int code)
        {
            throw new Exception("Dosn't exist");
        }
    }
}
