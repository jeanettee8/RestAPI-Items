using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestAPI_Items.DatabaseContext;

namespace RestAPI_Items.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ItemController (ItemDatabaseContext context) : ControllerBase {
    [HttpGet("{itemID}")]
    public IActionResult Get(int itemID) {
        return Ok(context.Items.FirstOrDefault(item=>item.ItemID==itemID));
    }

}