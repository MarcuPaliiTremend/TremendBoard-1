using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TremendBoard.Application.models;
using TremendBoard.Application.models.ProjectViewModels;
using TremendBoard.Infrastructure.Services.Interfaces;

namespace TremendBoard.Application.UseCases.Commands.GetProject
{
    public class GetProjectHandler : IRequestHandler<GetProjectRequest, GetProjectResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProjectHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProjectResponse> Handle(GetProjectRequest request, CancellationToken cancellationToken)
        {
            var projects = await _unitOfWork.Project.GetAllAsync();
            if (projects == null)
            {
                throw new Exception("Projects not found");
            }
            var projectsView = projects
                .Select(x => new ProjectDetailViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();

            var response = new GetProjectResponse()
            {
                ProjectDetails = projectsView
            };

            return response;
        }
    }
}
