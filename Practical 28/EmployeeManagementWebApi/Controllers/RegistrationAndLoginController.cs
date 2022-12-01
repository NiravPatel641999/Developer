using EmployeeManagementCommonHelper.ViewModel;
using EmployeeManagementDBLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationAndLoginController : ControllerBase
    {
        EmployeeDetailsData employeeData = new EmployeeDetailsData();
        /// <summary>Employees the registration.</summary>
        /// <param name="_registration">The registration.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        [Route("EmployeeRegistration")]
        public IActionResult EmployeeRegistration(UserRegistration _registration)
        {
            List<UserRegistration> registration = new List<UserRegistration>();
            EmployeeManagementCommonHelper.Model.UserRegistration employeeRegistration = new EmployeeManagementCommonHelper.Model.UserRegistration();
            employeeRegistration.Email = _registration.Email;
            employeeRegistration.Password = _registration.Password;
            employeeRegistration.ConfirmPassword = _registration.ConfirmPassword;
            employeeData.NewEmployeeRegistration(employeeRegistration);
            return Ok("New Registration Successfull");
        }
        /// <summary>Employees the login.</summary>
        /// <param name="_login">The login.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost]
        [Route("EmployeeLogin")]
        public IActionResult EmployeeLogin(UserLogin _login)
        {
            EmployeeManagementCommonHelper.Model.UserLogin employeeLogin = new EmployeeManagementCommonHelper.Model.UserLogin();
            employeeLogin.Email = _login.Email;
            employeeLogin.Password = _login.Password;
            var ans= employeeData.EmployeeLogin(employeeLogin);
            return Ok(ans);
        }
    }
}
