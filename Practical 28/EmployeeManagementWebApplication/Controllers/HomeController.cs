using EmployeeManagementCommonHelper.ViewModel;
using EmployeeManagementWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
        }
        public IActionResult Registration()
        {
            return View();
        }
        /// <summary>Registrations the specified registration.</summary>
        /// <param name="_registration">The registration.</param>
        [HttpPost]
        public IActionResult Registration(UserRegistration _registration)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsJsonAsync("http://localhost:54943/RegistrationAndLogin/EmployeeRegistration", _registration).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Registration");
        }
        /// <summary>Logins this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>Logins the specified login.</summary>
        /// <param name="_login">The User login.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        public IActionResult Login(UserLogin _login)
        {
            using (HttpClient client = new HttpClient())
            {
                List<UserLogin> loginDetails = new List<UserLogin>();
                var response = client.PostAsJsonAsync("http://localhost:54943/RegistrationAndLogin/EmployeeLogin", _login).Result;
                if (response.IsSuccessStatusCode)
                {
                    var display = response.Content.ReadAsAsync<List<UserLogin>>().Result;
                    if(display.Count == 1)
                    {
                        if ((_login.Email == display[0].Email) && (_login.Password == display[0].Password))
                        {
                            var accessToken = GenerateJSONWebToken(); //Generate JWT token for validation
                            SetJWTCookie(accessToken); //Set token in Cookie
                            return RedirectToAction("EmployeeInfo");
                        }
                    }   
                }
            }
            return RedirectToAction("Login");
        }
        /// <summary>List Of Employees information.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult EmployeeInfo()
        {
            var jwt = Request.Cookies["jwtCookie"]; //Get token value from Cookie
            List<EmployeeDetails> list = new List<EmployeeDetails>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authToken", jwt); // Set token in header
                var response = client.GetAsync("http://localhost:54943/EmployeeDetails/GetEmployeeDetails").Result;
                if (response.StatusCode == (System.Net.HttpStatusCode)417)
                {
                    return RedirectToAction("Login");
                }
                else if (response.ReasonPhrase == "Not Authorized")
                {
                    return RedirectToAction("Login");
                }
                else if (response.IsSuccessStatusCode)
                {
                    var display = response.Content.ReadAsAsync<List<EmployeeDetails>>().Result;
                    list = display;
                }
            }
            return View(list);
        }
        /// <summary>Gets the designation.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [NonAction]
        public List<EmployeeDetails> GetDesignation()
        {
            var jwt = Request.Cookies["jwtCookie"];
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authToken", jwt);
                var response = client.GetAsync("http://localhost:54943/EmployeeDetails/GetEmployeeDesignation").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<EmployeeDetails>>().Result;
                }
            }
            return new List<EmployeeDetails>();
        }
        /// <summary>Adds the new employee details.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult AddNewEmployeeDetails()
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
        public IActionResult AddNewEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            string FileName = Path.GetFileNameWithoutExtension(_employeeDetails.ImageFile.FileName);
            string FileExtension = Path.GetExtension(_employeeDetails.ImageFile.FileName);//To Get File Extension
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;//Add Current Date To Attached File Name 
            string UploadPath = configuration.GetSection("ImagePath").GetSection("UserImagePath").Value;//Get Upload path from Appsetting.json.
            _employeeDetails.ProfilePicture = UploadPath + FileName;//Its Create complete path to store in Database.
            using (var stream = new FileStream(_employeeDetails.ProfilePicture, FileMode.Create))
            {
                _employeeDetails.ImageFile.CopyTo(stream);
            }
            EmployeeManagementCommonHelper.Model.EmployeeDetails model = new EmployeeManagementCommonHelper.Model.EmployeeDetails();
            model.Name = _employeeDetails.Name;
            model.DesignationId = _employeeDetails.DesignationId;
            model.Address = _employeeDetails.Address;
            model.DateOfBirth = _employeeDetails.DateOfBirth;
            model.ProfilePicture = _employeeDetails.ProfilePicture;
            model.Salary = _employeeDetails.Salary;
            model.Email = _employeeDetails.Email;
            var jwt = Request.Cookies["jwtCookie"];
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authToken", jwt);
                var response = client.PostAsJsonAsync("http://localhost:54943/EmployeeDetails/InsertNewEmployeeDetails", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("EmployeeInfo");
                }
            }
            return RedirectToAction("AddNewEmployeeDetails");

        }
        /// <summary>Updates the employee details.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult UpdateEmployeeDetails(int id)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            var designation = GetDesignation();
            var jwt = Request.Cookies["jwtCookie"];
            using (HttpClient client =new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authToken", jwt);
                var response = client.GetAsync("http://localhost:54943/EmployeeDetails/SelectEmployeeDetails?id="+id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var display = response.Content.ReadAsAsync<EmployeeDetails>().Result;
                    employeeDetails = display;
                }
            }
            employeeDetails.DesignationList = new SelectList(designation, "Id", "Designation");
            string FileName = employeeDetails.ProfilePicture;
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
        public IActionResult UpdateEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            string FileName = Path.GetFileNameWithoutExtension(_employeeDetails.ImageFile.FileName);
            string FileExtension = Path.GetExtension(_employeeDetails.ImageFile.FileName);
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            string UploadPath = configuration.GetSection("ImagePath").GetSection("UserImagePath").Value;
            _employeeDetails.ProfilePicture = UploadPath + FileName;
            using (var stream = new FileStream(_employeeDetails.ProfilePicture, FileMode.Create))
            {
                _employeeDetails.ImageFile.CopyTo(stream);
            }
            EmployeeManagementCommonHelper.Model.EmployeeDetails model = new EmployeeManagementCommonHelper.Model.EmployeeDetails();
            model.Id = _employeeDetails.Id;
            model.Name = _employeeDetails.Name;
            model.DesignationId = _employeeDetails.DesignationId;
            model.Address = _employeeDetails.Address;
            model.DateOfBirth = _employeeDetails.DateOfBirth;
            model.ProfilePicture = _employeeDetails.ProfilePicture;
            model.Salary = _employeeDetails.Salary;
            model.Email = _employeeDetails.Email;
            var jwt = Request.Cookies["jwtCookie"];
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authToken", jwt);
                var response = client.PutAsJsonAsync("http://localhost:54943/EmployeeDetails/UpdateEmployeeDetails", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("EmployeeInfo");
                }
            }
            return RedirectToAction("UpdateEmployeeDetails");
        }
        /// <summary>Deletes the employee details.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public IActionResult DeleteEmployeeDetails(int id)
        {
            var jwt = Request.Cookies["jwtCookie"];
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authToken", jwt);
                var response = client.DeleteAsync("http://localhost:54943/EmployeeDetails/DeleteEmployeeDetails?id=" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("EmployeeInfo");
                }
            }
            return RedirectToAction("DeleteEmployeeDetails");
        }
        /// <summary>Generates the json web token.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretekeyKeySecrete"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>Sets the JWT token in cookie.</summary>
        /// <param name="token">The token.</param>
        private void SetJWTCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(3),
            };
            Response.Cookies.Append("jwtCookie", token, cookieOptions);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
