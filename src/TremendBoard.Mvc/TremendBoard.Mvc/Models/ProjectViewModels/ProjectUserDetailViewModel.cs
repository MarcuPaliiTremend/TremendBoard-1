﻿using System.ComponentModel.DataAnnotations;
using TremendBoard.Infrastructure.Data.Models.Identity;

namespace TremendBoard.Mvc.Models.ProjectViewModels
{
    public class ProjectUserDetailViewModel
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRoleName { get; set; }


        public ProjectUserDetailViewModel() {}

        public ProjectUserDetailViewModel(string projectId, ApplicationUserRole userRole, ApplicationUser user, ApplicationRole role)
        {
            ProjectId = projectId;
            UserId = userRole.UserId;
            RoleId = userRole.RoleId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserRoleName = role.Name;
        }
    }
}
