using JetBrains.Annotations;
using lr2.actor;
using lr2.entity;
using lr2.process;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.process;

[TestClass]
[TestSubject(typeof(CastingProcess))]
public class CastingProcessTest
{

    [TestMethod]
    public void GetNewDetail_test()
    {
        CastingProcess process = new CastingProcess(WorkerType.Stamper, 1);
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
        Detail detail = process.GetNewDetail();
        Assert.IsNotNull(detail);
        
        Assert.AreEqual(detail.GetDetailType(), DetailType.Engine);
        
    }
}