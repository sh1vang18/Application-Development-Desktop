using FarmersMartketAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FarmersMartketAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetFullList")]
        public Response GetFullList()
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmersMarketDB"));
            DatabaseHelper db = new DatabaseHelper();
            response = db.GetFullList(con);
            return response;
        }

        [HttpPost]
        [Route("AddInfo")]
        public Response AddInfo(Product product)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmersMarketDB"));
            DatabaseHelper db = new DatabaseHelper();
            response = db.AddInfo(con, product);
            return response;
        }

        [HttpPost]
        [Route("DeleteById/{id}")]
        public Response DeleteById(int id)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmersMarketDB"));
            DatabaseHelper db = new DatabaseHelper();
            response = db.DeleteInfo(con, id);
            return response;
        }

        [HttpPost]
        [Route("UpdateById/{id}")]
        public Response UpdateById(int id, [FromBody] Product updatedInfo)
        {
            Response response = new Response();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FarmersMarketDB"));
            DatabaseHelper db = new DatabaseHelper();
            response = db.UpdateInfo(con, id, updatedInfo);
            return response;
        }
    }
}
