﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TremendBoard.Infrastructure.Data.Models;
using TremendBoard.Infrastructure.Data.Models.Identity;
using TremendBoard.Infrastructure.Services.Interfaces;
using TremendBoard.Mvc.Enums;
using TremendBoard.Mvc.Mappers;
using TremendBoard.Mvc.Models.ProjectViewModels;
using TremendBoard.Mvc.Models.RoleViewModels;
using TremendBoard.Mvc.Models.UserViewModels;

namespace TremendBoard.Mvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapDtoToViewModel _mapDtoToViewModel;
        private readonly IMapViewModelToDto _mapViewModelToDto;

        public ProjectController(IProjectService projectService, IUnitOfWork unitOfWork, IMapDtoToViewModel mapDtoToViewModel, IMapViewModelToDto mapViewModelToDto)
        {
            _projectService = projectService;
            _unitOfWork = unitOfWork;
            _mapDtoToViewModel = mapDtoToViewModel;
            _mapViewModelToDto = mapViewModelToDto;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Index()
        {
            var projects = await _unitOfWork.Project.GetAllAsync();
            var projectsView = projects
                .Select(x => new ProjectDetailViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            var model = new ProjectIndexViewModel
            {
                Projects = projectsView
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //await _unitOfWork.Project.AddAsync(new Project
            //{
            //    Name = model.Name,
            //    Description = model.Description,
            //    CreatedDate = DateTime.Now,
            //    Deadline = model.Deadline,
            //    ProjectStatus = model.ProjectStatus
            //});

            //await _unitOfWork.SaveAsync();


            var dto = _mapViewModelToDto.ProjectViewModelToProjectDto(model);
            await _projectService.Create(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            //var project = await _unitOfWork.Project.GetByIdAsync(id);


            
            //if (project == null)
            //{
            //    throw new ApplicationException($"Unable to load project with ID '{id}'.");
            //}

            //var users = await _unitOfWork.User.GetAllAsync();
            //var usersView = users.Select(user => new UserDetailViewModel
            //{
            //    Id = user.Id,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Username = user.UserName,
            //    Email = user.Email,
            //    PhoneNumber = user.PhoneNumber
            //});

            //var roles = await _unitOfWork.Role.GetAllAsync();
            //var rolesView = roles
            //    .Where(x => x.Name != Role.Admin.ToString())
            //    .OrderBy(x => x.Name)
            //    .Select(r => new ApplicationRoleDetailViewModel
            //    {
            //        Id = r.Id,
            //        RoleName = r.Name,
            //        Description = r.Description
            //    });

            //var model = new ProjectDetailViewModel
            //{
            //    Id = id,
            //    Name = project.Name,
            //    Description = project.Description,
            //    Deadline = project.Deadline,
            //    ProjectStatus = project.ProjectStatus,
            //    ProjectUsers = new List<ProjectUserDetailViewModel>(),
            //    Users = usersView,
            //    Roles = rolesView
            //};

            //var userRoles = _unitOfWork.Project.GetProjectUserRoles(id);
            
            //foreach (var userRole in userRoles)
            //{
            //    var user = users.FirstOrDefault(x => x.Id == userRole.UserId);
            //    var role = roles.FirstOrDefault(x => x.Id == userRole.RoleId);
                
            //    var projectUser = new ProjectUserDetailViewModel
            //    {
            //        ProjectId = id,
            //        UserId = userRole.UserId,
            //        RoleId = userRole.RoleId,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        UserRoleName = role.Name
            //    };

            //    model.ProjectUsers.Add(projectUser);
            //}

            var dto = await _projectService.Edit(id);
            var viewModel = _mapDtoToViewModel.ProjectDtoToViewModel(dto);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectDetailViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            //var projectId = model.Id;
            //var project = await _unitOfWork.Project.GetByIdAsync(projectId);

            //if (project == null)
            //{
            //    ModelState.AddModelError("Error", "Unable to load the project");
            //    return View(model);
            //}

            //project.Name = model.Name;
            //project.Description = model.Description;
            //project.Deadline = model.Deadline;
            //project.ProjectStatus = model.ProjectStatus;

            //var users = await _unitOfWork.User.GetAllAsync();
            //var usersView = users.Select(user => new UserDetailViewModel
            //{
            //    Id = user.Id,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Username = user.UserName,
            //    Email = user.Email,
            //    PhoneNumber = user.PhoneNumber
            //});

            //var roles = await _unitOfWork.Role.GetAllAsync();
            //var rolesView = roles
            //    .Where(x => x.Name != Role.Admin.ToString())
            //    .OrderBy(x => x.Name)
            //    .Select(r => new ApplicationRoleDetailViewModel
            //    {
            //        Id = r.Id,
            //        RoleName = r.Name,
            //        Description = r.Description
            //    });

            //model.Roles = rolesView;
            //model.Users = usersView;

            //var userRoles = _unitOfWork.Project.GetProjectUserRoles(project.Id);

            //model.ProjectUsers = new List<ProjectUserDetailViewModel>();

            //foreach (var userRole in userRoles)
            //{
            //    var user = users.FirstOrDefault(x => x.Id == userRole.UserId);
            //    var role = roles.FirstOrDefault(x => x.Id == userRole.RoleId);
            //    var projectUser = new ProjectUserDetailViewModel
            //    {
            //        ProjectId = project.Id,
            //        UserId = userRole.UserId,
            //        RoleId = userRole.RoleId,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        UserRoleName = role.Name
            //    };

            //    model.ProjectUsers.Add(projectUser);
            //}

            //_unitOfWork.Project.Update(project);
            //await _unitOfWork.SaveAsync();

            //model.StatusMessage = $"{project.Name} project has been updated";

            //This doesn't work because adding a new project user doesn't work because database issues :(

            var dto = _mapViewModelToDto.ProjectViewModelToProjectDto(model);
            await _projectService.Edit(dto);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(ProjectUserDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error");
                return RedirectToAction(nameof(Edit), new { model.ProjectId });
            }

            var project = await _unitOfWork.Project.GetByIdAsync(model.ProjectId);

            var userRole = new ApplicationUserRole
            {
                Project = project,
                UserId = model.UserId,
                RoleId = model.RoleId
            };

            await _unitOfWork.UserRole.AddAsync(userRole);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Edit), new { id = model.ProjectId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            //var project = await _unitOfWork.Project.GetByIdAsync(id);

            var dto = await _projectService.Delete(id);
            var project = _mapDtoToViewModel.IncompleteProjectDtoToViewModel(dto);

            if (project == null)
            {
                StatusMessage = "Project not found";
                return View();
            }

            //var model = new ProjectDetailViewModel
            //{
            //    Name = project.Name,
            //    Description = project.Description
            //};

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProjectDetailViewModel model)
        {
            //var projectId = model.Id;

            //var project = await _unitOfWork.Project.GetByIdAsync(projectId);



            //if (project == null)
            //{
            //    StatusMessage = "Project not found";
            //    return View();
            //}

            //_unitOfWork.Project.Remove(project);
            //await _unitOfWork.SaveAsync();

            var project = _mapViewModelToDto.ProjectViewModelToProjectDto(model);

            await _projectService.Delete(project);

            return RedirectToAction(nameof(Index));
        }
    }
}