using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PizzaShopApi.Controllers;

[ApiController]
public class ToppingsController : ControllerBase
{

    private IConfiguration _configuration;
    public ToppingsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("get_toppings")]
    public JsonResult get_toppings()
    {
        string query = "select * from Toppings";
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

    [HttpPost("add_topping")]
    public JsonResult add_topping()
    {
        string query = "INSERT INTO Toppings VALUES ('" + "Ham" + "')";
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

    [HttpPost("update_topping")]
    public JsonResult update_topping()
    {
        string query = "UPDATE Toppings SET ToppingName = '" + "Chedder" + "' WHERE ToppingID = " + "1";
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

    [HttpDelete("delete_topping")]
    public JsonResult delete_topping()
    {
        string query = "DELETE FROM Toppings WHERE ToppingId = '" + "6" + "'";
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