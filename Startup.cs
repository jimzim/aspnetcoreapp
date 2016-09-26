using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace aspnetcoreapp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                var connectionString = "Server=tcp:jzdotnetsql.database.windows.net,1433;Initial Catalog=jzdotnets;Persist Security Info=False;User ID=jzadmin;Password=jzSqlserver1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                // var connectionString = "Server=tcp:ignitesqlserverqmabuhr73zepu.westus.cloudapp.azure.com,1433;Initial Catalog=Blogging;Persist Security Info=False;User ID=igniteadmin;Password=P@ssw0rd4Ignite;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
                
                var sqldata = "";

                try {

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        var queryString = "select * from Blog";
                        SqlCommand command = new SqlCommand(queryString, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        try
                        {
                            while (reader.Read())
                            {
                                sqldata += String.Format("{0}, {1}\n", reader["BlogId"], reader["Url"]);
                            }
                        }
                        catch(Exception ex)
                        {
                            // Console.WriteLine(ex.ToString());
                            return context.Response.WriteAsync("Error: " + ex.ToString());
                        }
                    }
                    return context.Response.WriteAsync("Hello from ASP.NET Core! \n" + sqldata);

                } catch(Exception ex) {
                    return context.Response.WriteAsync("Error: " + ex.ToString());
                }

                
            });
        }
    }
}