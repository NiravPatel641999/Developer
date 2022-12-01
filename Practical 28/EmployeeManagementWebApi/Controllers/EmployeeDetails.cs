using EmployeeManagementCommonHelper.ViewModel;
using EmployeeManagementDBLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementWebApi.Controllers
{
    [AuthorizeToken]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeDetails : ControllerBase
    {
        EmployeeDetailsData employeeData = new EmployeeDetailsData();

        /// <summary>Gets the employee details.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [Route("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            List<EmployeeManagementCommonHelper.ViewModel.EmployeeDetails> employeeList = new List<EmployeeManagementCommonHelper.ViewModel.EmployeeDetails>();
            var employeeListModel = employeeData.GetEmployeeDetails();
            if (employeeListModel != null && employeeListModel.Count > 0)
            {
                foreach (var item in employeeListModel)
                {
                    employeeList.Add(new EmployeeManagementCommonHelper.ViewModel.EmployeeDetails
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DesignationId = item.DesignationId,
                        ProfilePicture = Path.GetFileName(item.ProfilePicture),
                        Salary = item.Salary,
                        DateOfBirth = item.DateOfBirth,
                        Email = item.Email,
                        Address = item.Address,
                        Designation = item.Designation
                    });
                }
            }
            return Ok(employeeList);
        }
        /// <summary>Gets the designation.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [Route("GetEmployeeDesignation")]
        public IActionResult GetEmployeeDesignation()
        {
            List<EmployeeManagementCommonHelper.ViewModel.EmployeeDetails> employeeList = new List<EmployeeManagementCommonHelper.ViewModel.EmployeeDetails>();
            var employeeListModel = employeeData.GetEmployeeDesignation();
            if (employeeListModel != null && employeeListModel.Count > 0)
            {
                foreach (var item in employeeListModel)
                {
                    employeeList.Add(new EmployeeManagementCommonHelper.ViewModel.EmployeeDetails
                    {
                        Id = item.Id,
                        Designation = item.Designation
                    });
                }
            }
            return Ok(employeeList);
        }
        /// <summary>Inserts the new employee details.</summary>
        /// <param name="_employeeDetails">The employee details.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        [Route("InsertNewEmployeeDetails")]
        public IActionResult InsertNewEmployeeDetails(EmployeeManagementCommonHelper.ViewModel.EmployeeDetails _employeeDetails)
        {
            EmployeeManagementCommonHelper.Model.EmployeeDetails employeeListModel = new EmployeeManagementCommonHelper.Model.EmployeeDetails
            {
                Name = _employeeDetails.Name,
                DesignationId = _employeeDetails.DesignationId,
                ProfilePicture = _employeeDetails.ProfilePicture,
                Salary = _employeeDetails.Salary,
                DateOfBirth = _employeeDetails.DateOfBirth,
                Email = _employeeDetails.Email,
                Address = _employeeDetails.Address
            };
            employeeData.InsertNewEmployeeDetails(employeeListModel);
            return Ok("EmployeeDetails Added Successfully");
        }
        /// <summary>Selects the employee details.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [Route("SelectEmployeeDetails")]
        public IActionResult SelectEmployeeDetails(int id)
        {
            EmployeeManagementCommonHelper.ViewModel.EmployeeDetails employeeList = new EmployeeManagementCommonHelper.ViewModel.EmployeeDetails();
            var employeeListModel = employeeData.SelectEmployeeDetails(id);
            employeeList.Name = employeeListModel.Name;
            employeeList.DesignationId = employeeListModel.DesignationId;
            employeeList.ProfilePicture = employeeListModel.ProfilePicture;
            employeeList.Salary = employeeListModel.Salary;
            employeeList.DateOfBirth = employeeListModel.DateOfBirth;
            employeeList.Email = employeeListModel.Email;
            employeeList.Address = employeeListModel.Address;
            employeeList.Designation = employeeListModel.Designation;
            return Ok(employeeList);
        }
        /// <summary>Updates the employee details.</summary>
        /// <param name="_employeeDetails">The employee details.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [Route("UpdateEmployeeDetails")]
        [HttpPut]
        public IActionResult UpdateEmployeeDetails(EmployeeManagementCommonHelper.ViewModel.EmployeeDetails _employeeDetails)
        {
            EmployeeManagementCommonHelper.Model.EmployeeDetails employeeListModel = new EmployeeManagementCommonHelper.Model.EmployeeDetails
            {
                Id = _employeeDetails.Id,
                Name = _employeeDetails.Name,
                DesignationId = _employeeDetails.DesignationId,
                ProfilePicture = _employeeDetails.ProfilePicture,
                Salary = _employeeDetails.Salary,
                DateOfBirth = _employeeDetails.DateOfBirth,
                Email = _employeeDetails.Email,
                Address = _employeeDetails.Address
            };
            employeeData.UpdateEmployeeDetails(employeeListModel);
            return Ok("EmployeeDetails Updated Successfully");
        }
        /// <summary>Deletes the employee details.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [Route("DeleteEmployeeDetails")]
        [HttpDelete]
        public IActionResult DeleteEmployeeDetails(int id)
        {
            employeeData.DeleteEmployeeDetails(id);
            return Ok("EmployeeDetails Updated Successfully");
        }
    }
}
