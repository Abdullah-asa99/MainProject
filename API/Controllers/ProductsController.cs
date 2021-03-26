using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PproductsController : ControllerBase

    {
      [HttpGet]
      public string GetProduct(){

          return "this will return listt of products";
      }
      [HttpGet("{id}")]
      public string GetProduct(int id){

          return "single item";
      }


    }


}