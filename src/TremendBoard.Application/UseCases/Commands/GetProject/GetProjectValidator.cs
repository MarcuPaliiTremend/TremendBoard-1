using FluentValidation;

namespace TremendBoard.Application.UseCases.Commands.GetProject
{
    public class GetProjectValidator : AbstractValidator<GetProjectRequest>
    {
        public GetProjectValidator()
        { 
        }
    }
}
