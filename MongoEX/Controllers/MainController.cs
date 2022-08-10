using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MongoEX.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    [HttpPost("/send")]
    public async Task<object> Send(
        [FromBody]Message message,
        [FromServices]MongoService mongo)
    {
        var coll = mongo.GetCollection<Message>();
        await coll.InsertOneAsync(message);

        return new {
            Status = "Success"
        };
    }
}