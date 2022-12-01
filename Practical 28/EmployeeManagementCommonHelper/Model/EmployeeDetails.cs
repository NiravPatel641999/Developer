using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagementCommonHelper.Model
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public string ProfilePicture { get; set; }
        public double Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
    }
}
