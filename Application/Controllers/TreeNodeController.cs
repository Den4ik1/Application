using DomeinService.Interfaces;
using DomeinService.Models;
using DomeinService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("/api/[controller]")]
    public class TreeNodeController : Controller
    {

        private ITreeNodeService _treeNodeService;

        public TreeNodeController(ITreeNodeService treeNodeService)
        {
            _treeNodeService = treeNodeService;
        }


        [HttpPost("/api.user.tree.node.create")]
        public async Task<IActionResult> Create(string treeName, int parentNodeId, string nodeName)
        {
            try
            {
                await _treeNodeService.Create(treeName, parentNodeId, nodeName);

                return Ok("Done");
            }
            catch (ExceptionModel ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpPost("/api.user.tree.node.delete")]
        public async Task<IActionResult> Delete(string treeName, int nodeId)
        {
            try
            {
                await _treeNodeService.Delete(treeName, nodeId);
                return Ok("Done");
            }
            catch (ExceptionModel ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpPost("/api.user.tree.node.rename")]
        public async Task<IActionResult> Rename(string treeName, int nodeId, string newNodeName)
        {
            try
            {
                await _treeNodeService.Rename(treeName, nodeId, newNodeName);
                return Ok("Done");
            }
            catch (ExceptionModel ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }
    }
}
