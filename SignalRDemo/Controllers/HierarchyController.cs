using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Swashbuckle.AspNetCore.Annotations;

namespace SignalRDemo.Controllers
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

	[Route("api/[controller]")]
	[ApiController]
	public class HierarchyController(IHubContext<MessageHub, IMessageHubClient> messageHub, IUserConnector userConnector) : ControllerBase
	{
        [HttpGet]
        [Route("[action]")]
        [SwaggerOperation("Returns data across ALL connections by tenantId (4, 13, 16 ONLY!)")]
        public async Task<string> NotifyAllViaDataByTenantId(int tenantId)
		{
			using StreamReader sr = new ($"Data\\hierarchy_{tenantId}.json");
			var fileData = System.IO.File.ReadAllText($"Data\\hierarchy_{tenantId}.json");
			dynamic result = JObject.Parse(fileData);
			string resultStr = JsonConvert.SerializeObject(result);
			await messageHub.Clients.All.SendStringToUser(resultStr);
			return "Notified";
		}

		[HttpGet]
		[Route("[action]")]
		[SwaggerOperation("Returns data across ALL connections FOR ALL hierarchies (4, 13, 16 ONLY!). With simulating waiting")]
        public async Task<string> SendAllHierarchies()
		{
			using (StreamReader sr = new StreamReader("Data\\hierarchy_4.json"))
			{
				var fileData = System.IO.File.ReadAllText($"Data\\hierarchy_4.json");
				dynamic result = JObject.Parse(fileData);
				string resultStr = JsonConvert.SerializeObject(result);
				await messageHub.Clients.All.SendStringToUser(resultStr);
			}
			Thread.Sleep(TimeSpan.FromMilliseconds(5000));
            using (StreamReader sr = new StreamReader("Data\\hierarchy_13.json"))
			{
				var fileData = System.IO.File.ReadAllText($"Data\\hierarchy_13.json");
				dynamic result = JObject.Parse(fileData);
				string resultStr = JsonConvert.SerializeObject(result);
				await messageHub.Clients.All.SendStringToUser(resultStr);
            }
			Thread.Sleep(TimeSpan.FromMilliseconds(5000));
			using (StreamReader sr = new StreamReader("Data\\hierarchy_16.json"))
			{
				var fileData = System.IO.File.ReadAllText($"Data\\hierarchy_16.json");
				dynamic result = JObject.Parse(fileData);
				string resultStr = JsonConvert.SerializeObject(result);
				await messageHub.Clients.All.SendStringToUser(resultStr);
			}

			return "Notified";
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerOperation("Returns data across connection for specified User by tenantId (4, 13, 16 ONLY!)")]
        public async Task<string> NotifyTenantByIdAndUserName(string tenantId, string userName)
        {
	        var fileData = System.IO.File.ReadAllText($"Data\\hierarchy_{tenantId}.json");
	        dynamic result = JObject.Parse(fileData);
	        string resultStr = JsonConvert.SerializeObject(result);
            await messageHub.Clients.Client(userConnector.GetConnectionForUser(userName)).SendStringToUser(resultStr);
            return "Notified";
        }
    }
}