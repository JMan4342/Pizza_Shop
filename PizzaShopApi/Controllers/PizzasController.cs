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

    [HttpPost("add_pizza")]
    public JsonResult add_pizza()
    {
        string query = "INSERT INTO Pizzas VALUES ('" + "Pepperoni, Sausage, Ham" + "', '" + "Meat Fans" + "')";
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

    [HttpPost("update_pizza")]
    public JsonResult update_pizza()
    {
        string query = "UPDATE Pizzas SET PizzaName = '" + "Classic Meat Pizza" + "', Toppings = '" + "Pepperoni, Sausage" + "' WHERE PizzaID = " + "3";
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

    [HttpDelete("delete_pizza")]
    public JsonResult delete_pizza()
    {
        string query = "DELETE FROM Pizzas WHERE PizzaId = '" + "5" + "'";
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
}