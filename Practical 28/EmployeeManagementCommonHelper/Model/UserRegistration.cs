using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagementCommonHelper.Model
{
    public class UserRegistration
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
