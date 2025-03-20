using AutoMapper;
using DomeinService.Interfaces;
using DomeinService.Models;
using Infrastructyre.DataModels;
using Infrastructyre.Interfaces;

namespace DomeinService.Services
{
    public class TreeNodeService : ITreeNodeService
    {
        private ITreeNodeRepository _treeNodeRepository;
        private IJornalExeptionRepository _jornalExeptionRepository;
        private IMapper _mapper;
        public TreeNodeService(ITreeNodeRepository treeNodeRepository
            , IJornalExeptionRepository jornalExeptionRepository
            , IMapper mapper)
        {
            _treeNodeRepository = treeNodeRepository;
            _jornalExeptionRepository = jornalExeptionRepository;
            _mapper = mapper;
        }

        private async Task<bool> CheckMainTree(TreeNodeDataModel node)
        {
            if (node.ParentNodeId != null)
            {
                var parent = await _treeNodeRepository.GetNode((int)node.ParentNodeId, node.TreeName);
                if (parent != null)
                {
                    return true;
                }
                else
                {
                    await WriteJornal("Node does not belong to the parent's tree", "Problem with write");
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public async Task Create(string treeName, int parentNodeId, string nodeName)
        {

            var newNode = new TreeNodeDataModel
            {
                NodeName = nodeName,
                ParentNodeId = parentNodeId,
                TreeName = treeName,
            };

            try
            {
                if (await CheckMainTree(newNode))
                { 
                    await _treeNodeRepository.CreateTreeNode(newNode);
                }
            }
            catch (Exception ex)
            {
                await WriteJornal(ex.Message, "Problem with write");
            }
        }

        public async Task Delete(string treeName, int nodeId)
        {
            try
            {
                var treeNode = await _treeNodeRepository.GetNode(nodeId, treeName);
                if (treeNode.TreeNodeDataModels.Count() == 0)
                {
                    await _treeNodeRepository.DeleteTreeNode(treeNode);
                }
                else
                {
                    await WriteJornal("There are cildren", "Problem with write");
                }
            }
            catch (Exception ex)
            {
                await WriteJornal(ex.Message, "Problem with delete");
            }
        }

        public async Task Rename(string treeName, int nodeId, string newNodeName)
        {
            try
            {
                var treeNode = await _treeNodeRepository.GetNode(nodeId, treeName);
                treeNode.Id = nodeId;
                treeNode.NodeName = newNodeName;
                treeNode.TreeName = treeName;
                if (await CheckMainTree(treeNode))
                {
                    await _treeNodeRepository.RenameTreeNode(treeNode);
                }
            }
            catch (Exception ex)
            {
                await WriteJornal(ex.Message, "Problem with edit");
            }
        }

        private async Task WriteJornal(string text, string titel)
        {
            var exeption = new ExceptionModel(text, titel, 500);
            await _jornalExeptionRepository.WreatExeption(_mapper.Map<JornalExeptionDataModel>(exeption));

            throw exeption;
        }
    }
}
