using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

    [HttpPost("add_topping/{toppingName}")]
    public JsonResult add_topping(string toppingName)
    {
        string query = "INSERT INTO Toppings VALUES ('" + toppingName + "')";
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

    [HttpPost("update_topping/{toppingName}/{toppingId}")]
    public JsonResult update_topping(string toppingName, int toppingId)
    {
        string query = "UPDATE Toppings SET ToppingName = '" + toppingName + "' WHERE ToppingID = " + toppingId;
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

    [HttpDelete("delete_topping/{toppingId}")]
    public JsonResult delete_topping(int toppingId)
    {
        string query = "DELETE FROM Toppings WHERE ToppingId = '" + toppingId + "'";
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