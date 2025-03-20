using Application.ViewModels;
using DomeinService.Interfaces;
using DomeinService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Application.Controllers
{
    [Route("/api/[controller]")]
    public class JournalController : Controller
    {

        private IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpPost("/api.user.journal.getRange")]
        public async Task<IActionResult> GetRange(int skip, int take, FilterViewModel filter)
        {
            var filterModel = new RangeFilterModel
            {
                 Title = filter.Search,
                 Skip = skip,
                 Take = take,
                 From = filter.From, 
                 To = filter.To
            };
            return Ok(_journalService.GetRange(filterModel));
        }

        [HttpPost("/api.user.journal.getSingle")]
        public async Task<IActionResult> GetSingle(int Id)
        {
            return Ok(_journalService.GetSign(Id));
        }
    }
}
