using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TremendBoard.Application.UseCases.Commands.GetProject
{
    public  class GetProjectRequest : IRequest<GetProjectResponse>
    {
    }
}
