using JetBrains.Annotations;
using lr2.actor;
using lr2.process;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.process;

[TestClass]
[TestSubject(typeof(CarFactory))]
public class CarFactoryTest
{
    [TestMethod]
    public void GetCars_test()
    {
        StampingProcess _stampingProcess = new StampingProcess(WorkerType.Stamper, 1);
        _stampingProcess.AddWorker(new Worker(WorkerType.Stamper));
        
        ForgingProcess _forgingProcess = new ForgingProcess(WorkerType.Forger, 1);
        _forgingProcess.AddWorker(new Worker(WorkerType.Forger));
        
        CastingProcess _castingProcess = new CastingProcess(WorkerType.Caster, 1);
        _castingProcess.AddWorker(new Worker(WorkerType.Caster));
        
        CarFactory _carFactory = new CarFactory(_castingProcess, _forgingProcess, _stampingProcess);

        Assert.AreEqual(0, _carFactory.preparedCarAmount);
        Assert.AreEqual(0, _carFactory.enginesAmount);
        Assert.AreEqual(0, _carFactory.framesAmount);
        Assert.AreEqual(0, _carFactory.chassisAmount);

        Assert.AreEqual(0, _carFactory.GetCars());
    }
    
    [TestMethod]
    public void ReleaseCars_test()
    {
        StampingProcess _stampingProcess = new StampingProcess(WorkerType.Stamper, 1);
        _stampingProcess.AddWorker(new Worker(WorkerType.Stamper));
        
        ForgingProcess _forgingProcess = new ForgingProcess(WorkerType.Forger, 1);
        _forgingProcess.AddWorker(new Worker(WorkerType.Forger));
        
        CastingProcess _castingProcess = new CastingProcess(WorkerType.Caster, 1);
        _castingProcess.AddWorker(new Worker(WorkerType.Caster));
        
        CarFactory _carFactory = new CarFactory(_castingProcess, _forgingProcess, _stampingProcess);

        _carFactory.enginesAmount = 1;
        _carFactory.framesAmount = 1;
        _carFactory.chassisAmount = 1;
        
        _carFactory.ReleaseCars();
        
        Assert.AreEqual(1, _carFactory.preparedCarAmount);
        Assert.AreEqual(0, _carFactory.enginesAmount);
        Assert.AreEqual(0, _carFactory.framesAmount);
        Assert.AreEqual(0, _carFactory.chassisAmount);

        Assert.AreEqual(1, _carFactory.GetCars());
    }
}