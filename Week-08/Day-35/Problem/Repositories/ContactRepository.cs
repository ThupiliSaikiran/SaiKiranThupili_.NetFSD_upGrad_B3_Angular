using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connString;

        public ContactRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connString);
        }

        public List<Company> GetCompanies()
        {
            string sqlQuery = "SELECT CompanyId,CompanyName FROM Company";

            var db = GetConnection();

            return db.Query<Company>(sqlQuery).ToList();
        }

        public List<Department> GetDepartments()
        {
            string sqlQuery = "SELECT DepartmentId, DepartmentName FROM Department";

            var db = GetConnection();

            return db.Query<Department>(sqlQuery).ToList();
        }


        public List<ContactInfo> GetAllContacts()
        {
            string sqlQuery = @"SELECT c.ContactId, c.FirstName, c.LastName, c.EmailId, c.MobileNo, c.Designation,com.CompanyId, com.CompanyName,d.DepartmentId, d.DepartmentName FROM ContactInfo c JOIN Company com ON c.CompanyId = com.CompanyId JOIN Department d ON c.DepartmentId = d.DepartmentId";

            var db = GetConnection();

            return db.Query<ContactInfo, Company, Department, ContactInfo>(
        sqlQuery,
        (contact, company, department) =>
        {
            contact.Company = company;
            contact.Department = department;
            return contact;
        }, splitOn: "CompanyId,DepartmentId").ToList();
        }


        public ContactInfo GetContactById(int id)
        {
            string sqlQuery = @"SELECT c.ContactId, c.FirstName, c.LastName, c.EmailId, c.MobileNo, c.Designation,com.CompanyId, com.CompanyName,d.DepartmentId, d.DepartmentName FROM ContactInfo c JOIN Company com ON c.CompanyId = com.CompanyId JOIN Department d ON c.DepartmentId = d.DepartmentId WHERE ContactId =@id" ;

            var db = GetConnection();

            return db.Query<ContactInfo, Company, Department, ContactInfo>(
                sqlQuery,
                (contact, company, department) =>
                {
                    contact.Company = company;
                    contact.Department = department;
                    return contact;
                },
                new { id },
                splitOn: "CompanyId,DepartmentId"
            ).FirstOrDefault();



        }


        public void AddContact(ContactInfo contact)
        {
            string sqlQuery = @"INSERT INTO ContactInfo
                        (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                        VALUES
                        (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            var db = GetConnection();

            db.Execute(sqlQuery,contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            string sqlQuery = @"Update ContactInfo SET FirstName=@FirstName,LastName=@LastName,EmailId=@EmailId,MobileNo=@MobileNo,Designation=@Designation,CompanyId=@CompanyId,DepartmentId=@DepartmentId WHERE ContactId=@ContactId";

            var db = GetConnection();
            db.Execute(sqlQuery, contact);
        }

        public void DeleteContact(int id)
        {
            string sqlQuery = @"Delete from ContactInfo WHERE ContactId=@id";


            var db = GetConnection();
            db.Execute(sqlQuery, new { id });
        }
    }
}
