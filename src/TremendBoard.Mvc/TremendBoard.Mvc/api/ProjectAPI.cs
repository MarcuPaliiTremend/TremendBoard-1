using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TremendBoard.Application.UseCases.Commands.GetFullName;
using TremendBoard.Application.UseCases.Commands.GetProject;
using TremendBoard.Infrastructure.Data.Models.Identity;
using TremendBoard.Mvc.Enums;
using TremendBoard.Mvc.Models.UserViewModels;

namespace TremendBoard.Mvc.Controllers
{
    [AllowAnonymous]
    public class ProjectAPI : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        public ProjectAPI(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet("projects")]
        public async Task<IActionResult> projects(CancellationToken cancellationToken)
        {
            try
            {
                var request = new GetProjectRequest { };
                var response = await _mediator.Send(request, cancellationToken);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.Message);
            }

        }

    }
}