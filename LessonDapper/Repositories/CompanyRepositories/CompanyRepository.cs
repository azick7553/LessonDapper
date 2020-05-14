using Dapper;
using LessonDapper.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LessonDapper.Repositories.CompanyRepositories
{
    public class CompanyRepository : RepositoryBase<Company>
    {
        public CompanyRepository() : base()
        {
        }

        public int? AddOne(Company model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    var command = "INSERT INTO COMPANY(CompanyName) VALUES(@CompanyName); SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    return db.Query<int>(command, model).FirstOrDefault();
                }
            }
            catch(SqlException ex)
            {
                return null;
            }
            
        }

        public List<Company> AddMany(params Company[] companies)
        {
            List<Company> outListCompany = new List<Company>();
            foreach (var company in companies)
            {

                outListCompany.Add(new Company()
                {
                    Id = AddOne(company) ?? 0,
                    CompanyName = company.CompanyName
                });
            }
            return outListCompany;
        }
    }
}
