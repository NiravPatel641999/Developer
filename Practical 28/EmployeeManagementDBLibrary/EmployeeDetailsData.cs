using Dapper;
using EmployeeManagementCommonHelper.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmployeeManagementDBLibrary
{
    public class EmployeeDetailsData
    {
        public string DB_CONN_STRING = "Server=localhost;Initial Catalog=Employee;Trusted_Connection=True;";
        public List<UserRegistration> NewEmployeeRegistration(UserRegistration _registration)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", _registration.Email);
            parameter.Add("@Password", _registration.Password);
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                return SqlMapper.Query<UserRegistration>(db,"NewRegistration",parameter,commandType:CommandType.StoredProcedure).ToList();
            }
        }
        public List<EmployeeDetails> GetEmployeeDetails()
        {
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                return SqlMapper.Query<EmployeeDetails>(db,"GetEmployeeDetails", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<EmployeeDesignation> GetEmployeeDesignation()
        {
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                return SqlMapper.Query<EmployeeDesignation>(db,"GetEmployeeDesignation", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<EmployeeDetails> InsertNewEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            var parameter = new DynamicParameters();

            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {

                parameter.Add("@Name", _employeeDetails.Name);
                parameter.Add("@DesignationId", _employeeDetails.DesignationId);
                parameter.Add("@ProfilePicture", _employeeDetails.ProfilePicture);
                parameter.Add("@Salary", _employeeDetails.Salary);
                parameter.Add("@DateOfBirth", _employeeDetails.DateOfBirth);
                parameter.Add("@Email", _employeeDetails.Email);
                parameter.Add("@Address", _employeeDetails.Address);
                return SqlMapper.Query<EmployeeDetails>(db,"InsertEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public EmployeeDetails SelectEmployeeDetails(int id)
        {
            var parameter = new DynamicParameters();
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                parameter.Add("@Id", id);
                return SqlMapper.Query<EmployeeDetails>(db,"SelectEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<EmployeeDetails> UpdateEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            var parameter = new DynamicParameters();
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                parameter.Add("@Id", _employeeDetails.Id);
                parameter.Add("@Name", _employeeDetails.Name);
                parameter.Add("@DesignationId", _employeeDetails.DesignationId);
                parameter.Add("@ProfilePicture", _employeeDetails.ProfilePicture);
                parameter.Add("@Salary", _employeeDetails.Salary);
                parameter.Add("@DateOfBirth", _employeeDetails.DateOfBirth);
                parameter.Add("@Email", _employeeDetails.Email);
                parameter.Add("@Address", _employeeDetails.Address);
                return SqlMapper.Query<EmployeeDetails>(db,"UpdateEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<EmployeeDetails> DeleteEmployeeDetails(int id)
        {
            var parameter = new DynamicParameters();
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                parameter.Add("@Id", id);
                return SqlMapper.Query<EmployeeDetails>(db,"DeleteEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<UserLogin> EmployeeLogin(UserLogin _login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", _login.Email);
            parameter.Add("@Password", _login.Password);
            using (IDbConnection db = new SqlConnection(DB_CONN_STRING))
            {
                return SqlMapper.Query<UserLogin>(db, "UserLogin", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
