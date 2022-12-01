using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EmployeeManagementCommonHelper.Model;
using System.Configuration;

namespace EmployeeManagementDatabaseLibrary
{
    public class EmployeeDetailsData
    {
        public List<EmployeeDetails> GetEmployeeDetails()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {

                return db.Query<EmployeeDetails>("EXEC GetEmployeeDetails").ToList();
            }
        }
        public List<EmployeeDetails> InsertNewEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            var parameter = new DynamicParameters();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {

                parameter.Add("@Name", _employeeDetails.Name);
                parameter.Add("@DesignationId", _employeeDetails.DesignationId);
                parameter.Add("@ProfilePicturePath", _employeeDetails.ProfilePicturePath);
                parameter.Add("@Salary", _employeeDetails.Salary);
                parameter.Add("@DateOfBirth", _employeeDetails.DateOfBirth);
                parameter.Add("@Email", _employeeDetails.Email);
                parameter.Add("@Address", _employeeDetails.Address);
                return db.Query<EmployeeDetails>("InsertEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public EmployeeDetails SelectEmployeeDetails(int id)
        {
            var parameter = new DynamicParameters();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                parameter.Add("@Id", id);
                return db.Query<EmployeeDetails>("SelectEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<EmployeeDetails> UpdateEmployeeDetails(EmployeeDetails _employeeDetails)
        {
            var parameter = new DynamicParameters();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                parameter.Add("@Id", _employeeDetails.Id);
                parameter.Add("@Name", _employeeDetails.Name);
                parameter.Add("@DesignationId", _employeeDetails.DesignationId);
                parameter.Add("@ProfilePicturePath", _employeeDetails.ProfilePicturePath);
                parameter.Add("@Salary", _employeeDetails.Salary);
                parameter.Add("@DateOfBirth", _employeeDetails.DateOfBirth);
                parameter.Add("@Email", _employeeDetails.Email);
                parameter.Add("@Address", _employeeDetails.Address);
                return db.Query<EmployeeDetails>("UpdateEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<EmployeeDetails> DeleteEmployeeDetails(int id)
        {
            var parameter = new DynamicParameters();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                parameter.Add("@Id", id);
                return db.Query<EmployeeDetails>("DeleteEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<EmployeeDesignation> GetEmployeeDesignation()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {

                return db.Query<EmployeeDesignation>("GetEmployeeDesignation").ToList();
            }
        }
    }
}
