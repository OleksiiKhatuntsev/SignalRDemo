using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace SignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemSolvingController(IHubContext<MessageHub, IMessageHubClient> messageHub) : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        [SwaggerOperation("Returns problemSolving for tenant №4")]
        public async Task<string> GetProblemSolving(int tenantId = 4)
        {
            var fileData = System.IO.File.ReadAllText($"Data\\problem_solving_{tenantId}.json");
            dynamic result = JObject.Parse(fileData);
            string resultStr = JsonConvert.SerializeObject(result);
            await messageHub.Clients.All.SendStringToUser(resultStr);
            return "Notified";
        }
    }
}
