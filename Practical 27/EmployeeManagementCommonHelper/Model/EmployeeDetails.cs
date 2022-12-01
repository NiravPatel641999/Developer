using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagementCommonHelper.Model
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public string ProfilePicturePath { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }        
    }
}
