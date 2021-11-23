using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WeeklyReport.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private static Company MapCompany(SqlDataReader reader)
        {
            return new Company()
            {
                CompanyId = (int)reader["CompanyId"],
                Name = (string)reader["Name"],
                EstablishDate = (string)reader["EstablishDate"]
            };
        }
        public SqlConnection CreateConnection()
        {
            var sqlconnection = new SqlConnection("Server=.\\SQLEXPRESS;Database=Weekly_Team;Trusted_Connection=True");
            sqlconnection.Open();
            return sqlconnection;
        }
        public Company Create(Company entity)
        {
            using (var sqlconnection = CreateConnection())
            {
                var command = new SqlCommand("INSERT INTO [Companies] (Name, EstablishDate) VALUES(@Name, @EstablishDate)" + "SELECT * FROM Companies WHERE CompanyId=SCOPE_IDENTITY()", sqlconnection);

                var companyNameParam = new SqlParameter("@Name", SqlDbType.VarChar, 100)
                {
                    Value = entity.Name
                };
                var companyDateParam = new SqlParameter("@EstablishDate", SqlDbType.VarChar, 100)
                {
                    Value = entity.EstablishDate
                };
                command.Parameters.Add(companyNameParam);
                command.Parameters.Add(companyDateParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapCompany(reader);
                }

                return null;
            }

        }
        public Company Read(int entityId)
        {

            using (var sqlconnection = CreateConnection())
            {
                var command = new SqlCommand("SELECT * FROM Companies WHERE CompanyId=@CompanyId", sqlconnection);

                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entityId
                };

                command.Parameters.Add(companyIdParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapCompany(reader);
                }
                return null;
            }
        }

        public Company Update(Company entity)
        {
            using (var sqlconnection = CreateConnection())
            {
                var command = new SqlCommand("UPDATE companies SET Name=@Name, EstablishDate=@EstablishDate WHERE CompanyId=@CompanyId" + " SELECT * FROM Companies WHERE CompanyId=@CompanyId", sqlconnection);
                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entity.CompanyId
                };
                var companyNameParam = new SqlParameter("@Name", SqlDbType.VarChar, 100)
                {
                    Value = entity.Name
                };
                var companyDateParam = new SqlParameter("@EstablishDate", SqlDbType.VarChar, 100)
                {
                    Value = entity.EstablishDate
                };
                command.Parameters.Add(companyNameParam);
                command.Parameters.Add(companyDateParam);
                command.Parameters.Add(companyIdParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapCompany(reader);
                }

                return null;
            }
        }
        public Company Delete(int entityId)
        {
            using (var sqlconnection = CreateConnection())
            {
                var command = new SqlCommand("DELETE FROM Companies WHERE CompanyId=@CompanyId", sqlconnection);

                var companyIdParam = new SqlParameter("@CompanyId", SqlDbType.Int)
                {
                    Value = entityId
                };

                command.Parameters.Add(companyIdParam);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return MapCompany(reader);
                }
                return null;
            }
        }
    }
}
