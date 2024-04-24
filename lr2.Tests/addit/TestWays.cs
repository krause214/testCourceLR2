using System.Collections.Generic;
using lr2.actor;
using lr2.entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.ways;

[TestClass]
public class TestWays
{
    [TestMethod]
    public void Test1()
    {
        Manager manager = new Manager();
        manager._forgingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger)
            };
        manager._stampingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper)
            };
        manager._castingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster)
            };
        Buyer buyer = new Buyer(manager);
        buyer.OrderCars(14);

        manager._carFactory.preparedCarAmount = 0;
        for (int i = 0; i < 14; i++)
        {
            manager._stampingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            manager._castingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            manager._forgingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
        }
        
        buyer.BuyCars();
        
        Assert.IsTrue(buyer.IsHappy);
    }
    
    [TestMethod]
    public void Test2()
    {
        Manager manager = new Manager();
        manager._forgingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger)
            };
        manager._stampingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper)
            };
        manager._castingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster)
            };
        Buyer buyer = new Buyer(manager);
        buyer.OrderCars(14);

        for (int i = 0; i < 14; i++)
        {
            manager._stampingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            manager._castingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            manager._forgingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
        }
        
        buyer.BuyCars();
        
        Assert.IsFalse(buyer.IsHappy);
    }
    
    [TestMethod]
    public void Test3()
    {
        Manager manager = new Manager();
        manager._forgingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger)
            };
        manager._stampingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper)
            };
        manager._castingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster)
            };
        Buyer buyer = new Buyer(manager);
        buyer.OrderCars(14);

        manager.ReadyToSaleCars = 0;
        for (int i = 0; i < 14 ; i++)
        {
            manager._stampingProcess.AddMaterial(new Material(MaterialQuality.Defective));
            manager._castingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            manager._forgingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
        }
        
        buyer.BuyCars();
        
        Assert.IsFalse(buyer.IsHappy);
    }
    
    [TestMethod]
    public void Test4()
    {
        Manager manager = new Manager();
        manager._forgingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger),
                new Worker(WorkerType.Forger)
            };
        manager._stampingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper),
                new Worker(WorkerType.Stamper)
            };
        manager._castingProcess.Workers =
            new List<Worker>()
            {
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster),
                new Worker(WorkerType.Caster)
            };
        Buyer buyer = new Buyer(manager);
        buyer.OrderCars(14);

        manager.ReadyToSaleCars = 0;
        for (int i = 0; i < 14 ; i++)
        {
            manager._stampingProcess.AddMaterial(new Material(MaterialQuality.Defective));
            manager._castingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            manager._forgingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
        }
        
        buyer.BuyCars();
        
        Assert.IsFalse(buyer.IsHappy);
    }
}