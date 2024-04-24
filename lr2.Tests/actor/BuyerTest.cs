using JetBrains.Annotations;
using lr2.actor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.actor;

[TestClass]
[TestSubject(typeof(Buyer))]
public class BuyerTest
{

    [TestMethod]
    public void OrderCars_test()
    {
        Manager manager = new Manager();
        Buyer buyer = new Buyer(manager);
        buyer.OrderCars(2);
        
        Assert.AreEqual(2, buyer.OrderCarsAmount);
    }

    [TestMethod]
    public void BuyCars_test()
    {
        Manager manager = new Manager();
        Buyer buyer = new Buyer(manager);
        buyer.OrderCars(2);
        buyer.BuyCars();
        
        Assert.AreEqual(0, buyer.OrderCarsAmount);
        Assert.IsTrue(buyer.IsHappy);
    }
}