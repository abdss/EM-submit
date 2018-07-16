using DeliveryService.Helpers;
using DeliveryService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryService.Tests
{
    [TestClass]
    public class CostCalculatorTest
    {
        Customer myCustomer;
        Order myOrder;

        [TestInitialize]
        public void Initialize()
        {
            myCustomer = new Customer();
            myOrder = new Order();
            myOrder.OrderedCustomer = myCustomer;
        }

        [TestCleanup]
        public void Cleanup()
        {
            myCustomer = null;
            myOrder = null;
        }

        [TestMethod]
        public void TestCompute_WhenCustomerHasGotACoupon_ReturnsCorrespondingCost()
        {
            myOrder.OrderedCustomer.HasCoupon = true;

            var result = CostCalculator.Compute(999, myOrder);

            Assert.AreEqual(799.2, result);
        }

        [TestMethod]
        public void TestCompute_WhenCustomerIsNew_ReturnsCorrespondingCost()
        {
            myOrder.OrderedCustomer.IsNewCustomer = true;

            var result = CostCalculator.Compute(999, myOrder);

            Assert.AreEqual(849.15, result);
        }

        [TestMethod]
        public void TestCompute_WhenCustomerIsGoldRated_ReturnsCorrespondingCost()
        {
            myOrder.OrderedCustomer.IsGoldRatedCustomer = true;

            var result = CostCalculator.Compute(999, myOrder);

            Assert.AreEqual(899.1, result);
        }

        [TestMethod]
        public void TestCompute_WhenOrderIsPlacedOnWeekend_ReturnsCorrespondingCost()
        {
            myOrder.IsPlacedOnWeekend = true;

            var result = CostCalculator.Compute(999, myOrder);

            Assert.AreEqual(1498.5, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForShortDistance_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 9;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1098.9, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForShortDistanceBoundary_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 10;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1098.9, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForMediumDistance_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 11;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1248.75, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForMediumDistanceBoundary_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 50;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1248.75, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForLongDistance_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 51;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1249, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForLongDistance1_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 58;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1250.75, result);
        }

        [TestMethod]
        public void TestComputeFloorCost_WhenCustomerIsOnFloor1_CalculatesCorrespondingFloorCost()
        {
            var result = CostCalculator.ComputeFloorCost(999, 1);

            Assert.AreEqual(49.95, result);
        }

        [TestMethod]
        public void TestComputeFloorCost_WhenCustomerIsOnFloor5_CalculatesCorrespondingFloorCost()
        {
            var result = CostCalculator.ComputeFloorCost(999, 5);

            Assert.AreEqual(49.95, result);
        }

        [TestMethod]
        public void TestComputeFloorCost_WhenCustomerIsOnFloor6_CalculatesCorrespondingFloorCost()
        {
            var result = CostCalculator.ComputeFloorCost(999, 6);

            Assert.AreEqual(51.95, result);
        }

        [TestMethod]
        public void TestComputeFloorCost_WhenCustomerIsOnFloor11_CalculatesCorrespondingFloorCost()
        {
            var result = CostCalculator.ComputeFloorCost(999, 11);

            Assert.AreEqual(61.95, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForLongDistance1AndCustomerIsInFloor5_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 58;
            myOrder.OrderedCustomer.FloorNumber = 5;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1250.75 + 49.95, result);
        }

        [TestMethod]
        public void TestComputeDeliveryCost_WhenOrderIsPlacedOnWeekdayForLongDistance1AndCustomerIsInFloor6_CalculatesCorrespondingDeliveryCost()
        {
            myOrder.OrderedCustomer.Distance = 58;
            myOrder.OrderedCustomer.FloorNumber = 6;

            var result = CostCalculator.ComputeDeliveryCost(999, myOrder);

            Assert.AreEqual(1250.75 + 49.95 + 2, result);
        }
    }
}