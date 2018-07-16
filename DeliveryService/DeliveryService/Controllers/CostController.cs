using DeliveryService.DAL;
using DeliveryService.Helpers;
using DeliveryService.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeliveryService.Controllers
{
    public class CostController : ApiController
    {

        private OrdersContext db = new OrdersContext();

        [HttpGet]
        [Route("api/cost/order/{orderId}")]
        public double GetCost(long orderId)
        {
            // return orderId;
            Order order = db.Orders.Find(orderId);

            return CostCalculator.Compute(order);
        }
    }
}
