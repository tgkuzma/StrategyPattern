using System;
using System.Data;
using System.Data.Entity;
using System.Text;
using Models;

namespace Data
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {

        protected override void Seed(DataContext context)
        {
            context.Customers.Add(new Customer
            {
                Address = "123",
                DateActive = Convert.ToDateTime("11/18/2012"),
                CustomerName = "Trenton"
            });

            context.SaveChanges();
            CreateSqlStroedProcedure(context);
        }

        private static void CreateSqlStroedProcedure(DbContext context)
        {
            var initialState = context.Database.Connection.State;
            if (initialState == ConnectionState.Closed)
                context.Database.Connection.Open();

            if (context.Database.Connection.DataSource.Contains("localdb"))
            {
                using (var command = context.Database.Connection.CreateCommand())
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("CREATE PROCEDURE uspGetCustomerDuration");
                    stringBuilder.AppendLine("@CustomerName nvarchar(50)");
                    stringBuilder.AppendLine("AS");
                    stringBuilder.AppendLine("SET NOCOUNT ON;");
                    stringBuilder.AppendLine("SELECT DATEDIFF(yyyy, DateActive, GETDATE())");
                    stringBuilder.AppendLine("FROM Customers");
                    stringBuilder.AppendLine("WHERE CustomerName = @CustomerName;");

                    command.CommandText = stringBuilder.ToString();
                    command.ExecuteNonQuery();
                }
            }

            context.Database.Connection.Close();
        }
    }
}