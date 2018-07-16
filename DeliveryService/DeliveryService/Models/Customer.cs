using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryService.Models
{
    public class Customer
    {
        [Index("UniqueCustomerId")]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Distance { get; set; }

        public int FloorNumber { get; set; }

        public bool HasCoupon { get; set; }

        public bool IsNewCustomer { get; set; }

        public bool IsGoldRatedCustomer { get; set; }
    }
}