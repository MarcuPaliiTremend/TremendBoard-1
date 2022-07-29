
using TremendBoard.Application.models.ProjectViewModels;

namespace TremendBoard.Application.UseCases.Commands.GetProject
{
    public class GetProjectResponse
    {
        public List<ProjectDetailViewModel> ProjectDetails { get; set; }
    }
}
