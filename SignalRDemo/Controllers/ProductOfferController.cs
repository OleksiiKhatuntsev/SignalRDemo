using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductOfferController(IHubContext<MessageHub, IMessageHubClient> messageHub) : ControllerBase
	{
		[HttpPost]
		[Route("productoffers")]
		public string Get()
		{
			var offers = new List<string>
			{
				"15% Off on HP Pavillion",
				"20% Off on IPhone 12",
				"25% Off on Samsung Smart TV"
			};
			messageHub.Clients.All.SendOffersToUser(offers);
			return "Offers sent successfully to all users!";
		}

		[HttpGet]
		public void GetSpecificClient([FromQuery] string connectionId)
		{
			var offers = new List<string>
			{
				"15% Off on HP Pavillion",
				"20% Off on IPhone 12",
				"25% Off on Samsung Smart TV"
			};
			messageHub.Clients.Client(connectionId).SendOffersToUser(offers);
        }
	}
}