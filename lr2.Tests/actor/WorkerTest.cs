using JetBrains.Annotations;
using lr2.actor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.actor;

[TestClass]
[TestSubject(typeof(Worker))]
public class WorkerTest
{

    [TestMethod]
    public void GetWorkerType_test()
    {
        Worker caster = new Worker(WorkerType.Caster);
        Worker stamper = new Worker(WorkerType.Stamper);
        Worker forger = new Worker(WorkerType.Forger);
        
        Assert.AreEqual(WorkerType.Caster, caster.GetWorkerType());
        Assert.AreEqual(WorkerType.Stamper, stamper.GetWorkerType());
        Assert.AreEqual(WorkerType.Forger, forger.GetWorkerType());
    }
}