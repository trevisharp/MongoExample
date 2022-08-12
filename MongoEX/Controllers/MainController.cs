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
        message.Moment = DateTime.Now;

        var coll = mongo.GetCollection<Message>();
        await coll.InsertOneAsync(message);

        return new {
            Status = "Success"
        };
    }

    [HttpGet("/receive")]
    public async Task<object> Receive(
        [FromServices]MongoService mongo,
        int page = 0,
        int pagesize = 50
    )
    {
        var coll = mongo.GetCollection<Message>();
        var messages = coll.AsQueryable()
            .OrderByDescending(
                m => m.Moment)
            .Skip(page * pagesize)
            .Take(pagesize)
            .ToArray();
        
        return new {
            status = "Success",
            messages = messages
        };
    }
}