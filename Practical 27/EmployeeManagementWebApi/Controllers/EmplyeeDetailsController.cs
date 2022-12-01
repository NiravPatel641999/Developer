using EmployeeManagementCommonHelper.ViewModel;
using EmployeeManagementDatabaseLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementWebApi.Controllers
{
    [RoutePrefix("api/EmployeeDetails")]
    public class EmplyeeDetailsController : ApiController
    {
        public EmplyeeDetailsController()
        {
            EmployeeDetailsData employeeData = new EmployeeDetailsData();
        }
        EmployeeDetailsData employeeData = new EmployeeDetailsData();
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetEmployeeDetails()
        {
            List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
            var employeeListModel = employeeData.GetEmployeeDetails();
            if (employeeListModel != null && employeeListModel.Count > 0)
            {
                foreach (var item in employeeListModel)
                {
                    employeeList.Add(new EmployeeDetails
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DesignationId = item.DesignationId,
                        ProfilePicturePath = Path.GetFileName(item.ProfilePicturePath),
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

        [Route("{InsertNewEmployeeDetails}")]
        [HttpPost]
        public IHttpActionResult InsertNewEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
            EmployeeManagementCommonHelper.Model.EmployeeDetails employeeListModel = new EmployeeManagementCommonHelper.Model.EmployeeDetails
            {
                Name = _employeeDetails.Name,
                DesignationId = _employeeDetails.DesignationId,
                ProfilePicturePath = _employeeDetails.ProfilePicturePath,
                Salary = _employeeDetails.Salary,
                DateOfBirth = _employeeDetails.DateOfBirth,
                Email = _employeeDetails.Email,
                Address = _employeeDetails.Address
            };
            employeeData.InsertNewEmployeeDetails(employeeListModel);
            return Ok("EmployeeDetails Added Successfully");
        }
        [Route("{SelectEmployeeDetails}")]
        [HttpGet]
        public IHttpActionResult SelectEmployeeDetails(int id)
        {
            EmployeeDetails employeeList = new EmployeeDetails();
            var employeeListModel = employeeData.SelectEmployeeDetails(id);
            employeeList.Name = employeeListModel.Name;
            employeeList.DesignationId = employeeListModel.DesignationId;
            employeeList.ProfilePicturePath = employeeListModel.ProfilePicturePath;
            employeeList.Salary = employeeListModel.Salary;
            employeeList.DateOfBirth = employeeListModel.DateOfBirth;
            employeeList.Email = employeeListModel.Email;
            employeeList.Address = employeeListModel.Address;
            employeeList.Designation = employeeListModel.Designation;
            return Ok(employeeList);
        }
        [Route("{id}/{UpdateEmployeeDetails}")]
        [HttpPut]
        public IHttpActionResult UpdateEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            EmployeeManagementCommonHelper.Model.EmployeeDetails employeeListModel = new EmployeeManagementCommonHelper.Model.EmployeeDetails
            {
                Id = _employeeDetails.Id,
                Name = _employeeDetails.Name,
                DesignationId = _employeeDetails.DesignationId,
                ProfilePicturePath = _employeeDetails.ProfilePicturePath,
                Salary = _employeeDetails.Salary,
                DateOfBirth = _employeeDetails.DateOfBirth,
                Email = _employeeDetails.Email,
                Address = _employeeDetails.Address
            };
            employeeData.UpdateEmployeeDetails(employeeListModel);
            return Ok("EmployeeDetails Updated Successfully");
        }
        [Route("{id}/{DeleteEmployeeDetails}")]
        [HttpDelete]
        public IHttpActionResult DeleteEmployeeDetails(int id)
        {
            employeeData.DeleteEmployeeDetails(id);
            return Ok("EmployeeDetails Updated Successfully");
        }
        [Route("{GetEmployeeDesignation}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeDesignation()
        {
            List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
            var employeeListModel = employeeData.GetEmployeeDesignation();
            if (employeeListModel != null && employeeListModel.Count > 0)
            {
                foreach (var item in employeeListModel)
                {
                    employeeList.Add(new EmployeeDetails
                    {
                        Id = item.Id,
                        Designation = item.Designation
                    });
                }
            }
            return Ok(employeeList);
        }

    }
}
