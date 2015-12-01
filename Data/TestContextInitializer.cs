﻿using System;
using System.Data;
using System.Data.Entity;
using System.Text;
using Models;

namespace Data
{
    public class TestContextInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {

        protected override void Seed(TestContext context)
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

            if (context.Database.Connection.ServerVersion == "11.00.3000")
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