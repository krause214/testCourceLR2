using JetBrains.Annotations;
using lr2.actor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.actor;

[TestClass]
[TestSubject(typeof(Manager))]
public class ManagerTest
{

    [TestMethod]
    public void HandleOrder_test()
    {
        Manager manager = new Manager();
        manager.HandleOrder(3);
        Assert.AreEqual(3, manager.ReadyToSaleCars);
    }
    
    [TestMethod]
    public void InitFabric_test()
    {
        Manager manager = new Manager();
        Assert.IsNotNull(manager._carFactory);
        Assert.IsNotNull(manager._castingProcess);
        Assert.IsNotNull(manager._forgingProcess);
        Assert.IsNotNull(manager._stampingProcess);
    }
}