using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Swashbuckle.AspNetCore.Annotations;

namespace SignalRDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductOfferController(IHubContext<MessageHub, IMessageHubClient> messageHub, IUserConnector userConnector) : ControllerBase
	{
        [HttpGet]
        [Route("[action]")]
        [SwaggerOperation("Returns data across ALL connections by tenantId (4, 13, 16 ONLY!)")]
        public async Task<string> NotifyAllViaDataByTenantId(int tenantId)
		{
			using StreamReader sr = new ($"Data\\hierarchy_{tenantId}.json");
			var fileData = await sr.ReadToEndAsync();
			await messageHub.Clients.All.SendStringToUser(fileData);
			return "Notified";
		}

		[HttpGet]
		[Route("[action]")]
		[SwaggerOperation("Returns data across ALL connections FOR ALL hierarchies (4, 13, 16 ONLY!). With simulating waiting")]
        public async Task<string> SendAllHierarchies()
		{
			using (StreamReader sr = new StreamReader("Data\\hierarchy_4.json"))
			{
				var fileData = await sr.ReadToEndAsync();
				await messageHub.Clients.All.SendStringToUser(fileData);
			}
			Thread.Sleep(TimeSpan.FromMilliseconds(5000));
            using (StreamReader sr = new StreamReader("Data\\hierarchy_13.json"))
			{
				var fileData = await sr.ReadToEndAsync();
				await messageHub.Clients.All.SendStringToUser(fileData);
            }
			Thread.Sleep(TimeSpan.FromMilliseconds(5000));
			using (StreamReader sr = new StreamReader("Data\\hierarchy_16.json"))
			{
				var fileData = await sr.ReadToEndAsync();
				await messageHub.Clients.All.SendStringToUser(fileData);
			}

			return "Notified";
        }

        [HttpGet]
        [Route("[action]")]
        [SwaggerOperation("Returns data across connection for specified User by tenantId (4, 13, 16 ONLY!)")]
        public async Task<string> NotifyTenantByIdAndUserName(string tenantId, string userName)
        {
	        using StreamReader sr = new($"Data\\hierarchy_{tenantId}.json");
	        var fileData = await sr.ReadToEndAsync();
            await messageHub.Clients.Client(userConnector.GetConnectionForUser(userName)).SendStringToUser(fileData);
            return "Notified";
        }
    }
}