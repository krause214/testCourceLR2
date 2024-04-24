using JetBrains.Annotations;
using lr2.actor;
using lr2.entity;
using lr2.process;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.process;

[TestClass]
[TestSubject(typeof(Process))]
public class ProcessTest
{
    class ProcessImpl(WorkerType requiredWorkerType, int requiredWorkerAmount) : Process(requiredWorkerType, requiredWorkerAmount)
    {
        public override Detail GetNewDetail()
        {
            if (PreparedAmount > 0)
            {
                PreparedAmount--;
                return new Detail(DetailType.Engine);
            }

            return null;
        }
    }

    [TestMethod]
    public void DoProcess_test()
    {
        Process process = new ProcessImpl(WorkerType.Stamper, 1);
        Assert.IsNull(process.GetNewDetail());
        
        process.AddMaterial(new Material(MaterialQuality.Defective));
        Assert.IsNull(process.GetNewDetail());
        Assert.AreEqual(0, process.Materials.Count);
        
        process.AddWorker(new Worker(WorkerType.Caster));
        Assert.AreEqual(0, process.Workers.Count);
        Assert.IsNull(process.GetNewDetail());
        process.AddMaterial(new Material(MaterialQuality.Qualitative));
        Assert.IsNull(process.GetNewDetail());
        
        process.AddWorker(new Worker(WorkerType.Stamper));
        Assert.IsNotNull(process.GetNewDetail());
        
        Assert.IsNull(process.GetNewDetail());
    }
    
    [TestMethod]
    public void HasEnoughWorkers_test()
    {
        Process process1 = new ProcessImpl(WorkerType.Stamper, 1);
        Process process2 = new ProcessImpl(WorkerType.Stamper, 2);

        process1.AddWorker(new Worker(WorkerType.Stamper));
        process2.AddWorker(new Worker(WorkerType.Stamper));
        
        Assert.IsTrue(process1.HasEnoughWorkers());
    }
    
    [TestMethod]
    public void AddWorker_test()
    {
        Process process1 = new ProcessImpl(WorkerType.Stamper, 1);
        
        Assert.AreEqual(0 , process1.Workers.Count);
        
        process1.AddWorker(new Worker(WorkerType.Stamper));
        Assert.AreEqual(1, process1.Workers.Count);
        
        process1.AddWorker(new Worker(WorkerType.Forger));
        Assert.AreEqual(1, process1.Workers.Count);
    }
    
    [TestMethod]
    public void AddMaterial_test()
    {
        Process process1 = new ProcessImpl(WorkerType.Stamper, 1);
        
        Assert.AreEqual(0 , process1.Materials.Count);
        
        process1.AddMaterial(new Material(MaterialQuality.Qualitative));
        Assert.AreEqual(1, process1.Materials.Count);
        
        process1.AddMaterial(new Material(MaterialQuality.Defective));
        Assert.AreEqual(1, process1.Materials.Count);
    }
    
    [TestMethod]
    public void RemoveWorker_test()
    {
        Process process1 = new ProcessImpl(WorkerType.Stamper, 1);
        
        process1.AddWorker(new Worker(WorkerType.Stamper));
        Assert.AreEqual(1, process1.Workers.Count);
        
        process1.RemoveWorker();
        Assert.AreEqual(0, process1.Workers.Count);
        
        process1.RemoveWorker();
        Assert.AreEqual(0, process1.Workers.Count);
    }
    
}