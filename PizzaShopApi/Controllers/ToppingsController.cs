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
        using(SqlConnection myCon = new SqlConnection(SqlDatasource))
        {
            myCon.Open();
            using(SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
            }
        }

        return new JsonResult(table);
    }

}