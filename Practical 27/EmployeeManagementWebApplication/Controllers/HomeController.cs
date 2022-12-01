using EmployeeManagementCommonHelper.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementWebApplication.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        /// <summary>Gets list of employees details.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public ActionResult Index()
        {
            try
            {
                List<EmployeeDetails> list = new List<EmployeeDetails>();
                client.BaseAddress = new Uri("https://localhost:44350/api/EmployeeDetails");
                var response = client.GetAsync("EmployeeDetails");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<EmployeeDetails>>();
                    display.Wait();
                    list = display.Result;
                }
                return View(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        public ActionResult AddNewEmployeeDetails()
        {
            EmployeeDetails employeeDesignation = new EmployeeDetails();
            var designation = GetDesignation();
            employeeDesignation.DesignationList = new SelectList(designation, "Id", "Designation");
            return View(employeeDesignation);
        }
        /// <summary>Adds the new employee details.</summary>
        /// <param name="_employeeDetails">The employee details.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public ActionResult AddNewEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            string FileName = Path.GetFileNameWithoutExtension(_employeeDetails.ImageFile.FileName);
            string FileExtension = Path.GetExtension(_employeeDetails.ImageFile.FileName);//To Get File Extension
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;//Add Current Date To Attached File Name 
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();//Get Upload path from Web.Config file AppSettings.
            _employeeDetails.ProfilePicturePath = UploadPath + FileName;//Its Create complete path to store in Database.
            _employeeDetails.ImageFile.SaveAs(_employeeDetails.ProfilePicturePath);//To copy and save file into Folder.

            EmployeeManagementCommonHelper.Model.EmployeeDetails model = new EmployeeManagementCommonHelper.Model.EmployeeDetails();
            model.Name = _employeeDetails.Name;
            model.DesignationId = _employeeDetails.DesignationId;
            model.Address = _employeeDetails.Address;
            model.DateOfBirth = _employeeDetails.DateOfBirth;
            model.ProfilePicturePath = _employeeDetails.ProfilePicturePath;
            model.Salary = _employeeDetails.Salary;
            model.Email = _employeeDetails.Email;
            client.BaseAddress = new Uri("https://localhost:44350/api/EmployeeDetails/InsertNewEmployeeDetails");
            var response = client.PostAsJsonAsync("InsertNewEmployeeDetails", model);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("addnewemployeedetails");

        }
        /// <summary>Gets the employee previous details for edit.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public ActionResult UpdateEmployeeDetails(int id)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            var designation = GetDesignation();
            client.BaseAddress = new Uri("https://localhost:44350/api/EmployeeDetails/SelectEmployeeDetails");
            var responseForEdit = client.GetAsync("SelectEmployeeDetails?id=" + id.ToString());
            responseForEdit.Wait();
            var testForEdit = responseForEdit.Result;
            if (testForEdit.IsSuccessStatusCode)
            {
                var display = testForEdit.Content.ReadAsAsync<EmployeeDetails>();
                display.Wait();
                employeeDetails = display.Result;
            }
            employeeDetails.DesignationList = new SelectList(designation, "Id", "Designation");

            string FileName = employeeDetails.ProfilePicturePath;
            string result = Path.GetFileName(FileName);
            ViewBag.FileName = result;
            return View(employeeDetails);
        }
        /// <summary>Updates the employee details.</summary>
        /// <param name="_employeeDetails">The employee details.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public ActionResult UpdateEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            string FileName = Path.GetFileNameWithoutExtension(_employeeDetails.ImageFile.FileName);
            string FileExtension = Path.GetExtension(_employeeDetails.ImageFile.FileName);
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            _employeeDetails.ProfilePicturePath = UploadPath + FileName;
            _employeeDetails.ImageFile.SaveAs(_employeeDetails.ProfilePicturePath);

            EmployeeManagementCommonHelper.Model.EmployeeDetails model = new EmployeeManagementCommonHelper.Model.EmployeeDetails();
            model.Id = _employeeDetails.Id;
            model.Name = _employeeDetails.Name;
            model.DesignationId = _employeeDetails.DesignationId;
            model.Address = _employeeDetails.Address;
            model.DateOfBirth = _employeeDetails.DateOfBirth;
            model.ProfilePicturePath = _employeeDetails.ProfilePicturePath;
            model.Salary = _employeeDetails.Salary;
            model.Email = _employeeDetails.Email;

            client.BaseAddress = new Uri("https://localhost:44350/api/EmployeeDetails/SelectEmployeeDetails/UpdateEmployeeDetails");
            var response = client.PutAsJsonAsync("UpdateEmployeeDetails", model);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("UpdateEmployeeDetails");
        }
        /// <summary>Deletes the employee details.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public ActionResult DeleteEmployeeDetails(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44350/api/EmployeeDetails/SelectEmployeeDetails/DeleteEmployeeDetails");
            var response = client.DeleteAsync("DeleteEmployeeDetails?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("DeleteEmployeeDetails");
        }

        /// <summary>Gets the designation.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [NonAction]
        public List<EmployeeDetails> GetDesignation()
        {
            List<EmployeeDetails> result = new List<EmployeeDetails>();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("https://localhost:44350/api/EmployeeDetails/GetEmployeeDesignation").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<EmployeeDetails>>().Result;
                }
            }
            return new List<EmployeeDetails>();
        }


    }
}