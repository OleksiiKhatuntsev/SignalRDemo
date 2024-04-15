using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductOfferController(IHubContext<MessageHub, IMessageHubClient> messageHub, IUserConnector userConnector) : ControllerBase
	{
		[HttpPost]
		[Route("productoffers")]
		public async Task<string> Get()
		{
			var offers = new List<string>
			{
				"15% Off on HP Pavillion",
				"20% Off on IPhone 12",
				"25% Off on Samsung Smart TV"
			};
			await messageHub.Clients.All.SendOffersToUser(offers);
			return "Offers sent successfully to all users!";
		}

        [HttpGet]
        [Route("asd")]
        public async Task<string> GetByUserName(string userName)
        {
            var offers = new List<string>
            {
                "15% Off on HP Pavillion",
                "20% Off on IPhone 12",
                "25% Off on Samsung Smart TV"
            };
            await messageHub.Clients.Client(userConnector.GetConnectionForUser(userName)).SendOffersToUser(offers);
            return "asd";
        }

        [HttpGet]
        [Route("asdasd")]
        public async Task GetSpecificClient([FromQuery] string connectionId)
        {
            var offers = new List<string>
            {
                "15% Off on HP Pavillion",
                "20% Off on IPhone 12",
                "25% Off on Samsung Smart TV"
            };
            await messageHub.Clients.Client(connectionId).SendOffersToUser(offers);
        }
    }
}