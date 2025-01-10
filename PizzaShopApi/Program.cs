// using System;
// using Microsoft.Data.SqlClient;
// using System.Text;

// namespace sqltest
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             try 
//             { 
//                 SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//                 builder.DataSource = "LAPTOP-MR0DC8L4\\SQLEXPRESS"; 
//                 // builder.UserID = "<your_username>";            
//                 // builder.Password = "<password>";     
//                 builder.InitialCatalog = "Pizza_Shop";

//                 using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//                 {
//                     Console.WriteLine("\nQuery data example:");
//                     Console.WriteLine("=========================================\n");

//                     String sql = "SELECT name, collation_name FROM sys.databases";

//                     using (SqlCommand command = new SqlCommand(sql, connection))
//                     {
//                         connection.Open();
//                         using (SqlDataReader reader = command.ExecuteReader())
//                         {
//                             while (reader.Read())
//                             {
//                                 Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
//                             }
//                         }
//                     }                    
//                 }
//             }
//             catch (SqlException e)
//             {
//                 Console.WriteLine(e.ToString());
//             }
//             Console.ReadLine();
//         }
//     }
// }

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
