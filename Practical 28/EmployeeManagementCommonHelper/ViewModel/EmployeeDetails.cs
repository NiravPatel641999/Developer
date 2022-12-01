using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagementCommonHelper.ViewModel
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePicture { get; set; }
        public double Salary { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        public string Designation { get; set; }
        [NotMapped]
        public SelectList DesignationList { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
