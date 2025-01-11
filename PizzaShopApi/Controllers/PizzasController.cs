using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PizzaShopApi.Controllers;

[ApiController]
public class PizzasController : ControllerBase
{

    private IConfiguration _configuration;
    public PizzasController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("get_pizzas")]
    public JsonResult get_pizzas()
    {
        string query = "select * from Pizzas";
        DataTable table = new DataTable();
        string SqlDatasource = _configuration.GetConnectionString("Pizza_Shop");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(SqlDatasource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
            }
        }

        return new JsonResult(table);
    }

    [HttpPost("add_pizza/{pizzaName}/{toppings}")]
    public JsonResult add_pizza(string pizzaName, string toppings)
    {
        string query = "INSERT INTO Pizzas VALUES ('" + toppings + "', '" + pizzaName + "')";
        DataTable table = new DataTable();
        string SqlDatasource = _configuration.GetConnectionString("Pizza_Shop");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(SqlDatasource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
            }
        }

        return new JsonResult("Added Successfully");
    }

    [HttpPost("update_pizza/{pizzaName}/{toppings}/{pizzaId}")]
    public JsonResult update_pizza(string pizzaName, string toppings, int pizzaId)
    {
        string query = "UPDATE Pizzas SET PizzaName = '" + pizzaName + "', Toppings = '" + toppings + "' WHERE PizzaID = " + pizzaId;
        DataTable table = new DataTable();
        string SqlDatasource = _configuration.GetConnectionString("Pizza_Shop");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(SqlDatasource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
            }
        }

        return new JsonResult("Updated Successfully");
    }

    [HttpDelete("delete_pizza/{pizzaId}")]
    public JsonResult delete_pizza(int pizzaId)
    {
        string query = "DELETE FROM Pizzas WHERE PizzaId = '" + pizzaId + "'";
        DataTable table = new DataTable();
        string SqlDatasource = _configuration.GetConnectionString("Pizza_Shop");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(SqlDatasource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
            }
        }

        return new JsonResult("Deleted Successfully");
    }
}