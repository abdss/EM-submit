using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Models
{
    public class Order
    {
        [Index("UniqueOrderId")]
        public long ID { get; set; }

        public double BaseCost { get; set; }

        public Customer OrderedCustomer { get; set; }

        public bool IsPlacedOnWeekend { get; set; }
    }
}