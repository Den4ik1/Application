using Application.ViewModels;
using AutoMapper;
using DomeinService.Interfaces;
using DomeinService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("/api/[controller]")]
    public class TreeController : Controller
    {
        private IMapper _mapper;

        private ITreeService _treeService;

        public TreeController(ITreeService treeService, IMapper mapper)
        {
            _treeService = treeService;
            _mapper = mapper;
        }

        [HttpPost("/api.user.tree.get")]
        public async Task<IActionResult> Get(string treeName)
        {
            try
            {
                return Ok(_mapper.Map<TreeViewModel>(await _treeService.GetTree(treeName)));
            }
            catch (ExceptionModel ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }
    }
}
