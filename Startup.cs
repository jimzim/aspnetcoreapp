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
                var data = "Test";

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
                                data += String.Format("{0}, {1}", reader["BlogId"], reader["Url"]);
                                //Console.WriteLine(String.Format("{0}, {1}",
                                // reader["BlogId"], reader["Url"]));
                            }
                        }
                        catch(Exception ex)
                        {
                            // Console.WriteLine(ex.ToString());
                            return context.Response.WriteAsync("Error: " + ex.ToString());
                        }
                    }
                    return context.Response.WriteAsync("Hello from ASP.NET Core!" + data);

                } catch(Exception ex) {
                    return context.Response.WriteAsync("Error: " + ex.ToString());
                }

                
            });
        }
    }
}