using System.Collections.Generic;
using JetBrains.Annotations;
using lr2.actor;
using lr2.entity;
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
    
    [TestMethod]
    public void Materials_test()
    {
        Manager manager = new Manager();
        manager._castingProcess.Workers = new List<Worker>();
        manager._castingProcess.Materials = new List<Material>();
        manager._castingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
        
        Assert.AreEqual(1, manager._castingProcess.Materials.Count);
    }
    
    [TestMethod]
    public void Worker_test()
    {
        Manager manager = new Manager();
        manager._castingProcess.Workers = new List<Worker>();
        manager._castingProcess.AddWorker(new Worker(WorkerType.Caster));
        
        Assert.AreEqual(1, manager._castingProcess.Workers.Count);
        
        manager._castingProcess.RemoveWorker();
        
        Assert.AreEqual(0, manager._castingProcess.Workers.Count);
    }
}