using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace EmployeeManagementCommonHelper.ViewModel
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select your Designation")]
        public int DesignationId { get; set; }
        [DisplayName("ProfilePicture")]
        public string ProfilePicturePath { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        public string Designation { get; set; }
        [NotMapped]
        public SelectList DesignationList { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
