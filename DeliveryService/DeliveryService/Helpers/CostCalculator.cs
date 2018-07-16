using DeliveryService.Models;

namespace DeliveryService.Helpers
{
    public static class CostCalculator
    {
        public static double Compute(Order order)
        {
            var baseFare = order.BaseCost;
            if (order.OrderedCustomer.HasCoupon)
            {
                return 0.80 * baseFare;     // 20% discount
            }
            else if(order.OrderedCustomer.IsNewCustomer)
            {
                return 0.85 * baseFare;     // 15% discount
            }
            else if(order.OrderedCustomer.IsGoldRatedCustomer)
            {
                return 0.90 * baseFare;     // 10% discount
            }
            else if(order.IsPlacedOnWeekend)
            {
                return 1.50 * baseFare;     // 50% charges
            }
            else
            {
                return ComputeDeliveryCost(baseFare, order);
            }
        }

        public static double ComputeDeliveryCost(double baseFare, Order order)
        {            
            double a = ComputeDistanceCost(baseFare, order.OrderedCustomer.Distance);
            double b = ComputeFloorCost(baseFare, order.OrderedCustomer.FloorNumber);
            return baseFare + a + b;
        }

        public static double ComputeDistanceCost(double baseFare, int distance)
        {
            if (distance <= 10)
            {
                return 0.1 * baseFare;
            }
            else if (distance > 10 && distance <= 50)
            {
                return 0.25 * baseFare;
            }
            else
            {
                return 0.25 * baseFare + 0.25 * (distance - 50);
            }
        }

        public static double ComputeFloorCost(double baseFare, int floorNumber)
        {
            if(floorNumber == 0)
            {
                return 0;
            }
            else if(floorNumber < 6)
            {
                return 0.05 * baseFare;
            }
            else
            {
                return 0.05 * baseFare + 2 * (floorNumber - 5);
            }
        }
    }
}