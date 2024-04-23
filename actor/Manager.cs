using lr2.entity;
using lr2.process;

namespace lr2.actor;

public class Manager
{
    Manager()
    {
        InitFabric();
    }
    
    public const int CASTING_PROCESS_WORKERS_AMOUNT = 4;
    public const int FORGING_PROCESS_WORKERS_AMOUNT = 4;
    public const int STAMPING_PROCESS_WORKERS_AMOUNT = 4;
    
    public CarFactory _carFactory;
    public CastingProcess _castingProcess;
    public ForgingProcess _forgingProcess;
    public StampingProcess _stampingProcess;

    public int ReadyToSaleCars = 0; 
    
    public void HandleOrder(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _castingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            _forgingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
            _stampingProcess.AddMaterial(new Material(MaterialQuality.Qualitative));
        }

        _carFactory.ReleaseCars();
    }

    public void SaleCars()
    {
        ReadyToSaleCars = _carFactory.GetCars();
    }

    private void InitFabric()
    {
        _stampingProcess = new StampingProcess(WorkerType.Stamper, STAMPING_PROCESS_WORKERS_AMOUNT);
        for (int i = 0; i < STAMPING_PROCESS_WORKERS_AMOUNT; i++)
        {
            _stampingProcess.AddWorker(new Worker(WorkerType.Stamper));
        }
        
        _forgingProcess = new ForgingProcess(WorkerType.Forger, FORGING_PROCESS_WORKERS_AMOUNT);
        for (int i = 0; i < FORGING_PROCESS_WORKERS_AMOUNT; i++)
        {
            _stampingProcess.AddWorker(new Worker(WorkerType.Forger));
        }
        
        _castingProcess = new CastingProcess(WorkerType.Caster, CASTING_PROCESS_WORKERS_AMOUNT);
        for (int i = 0; i < CASTING_PROCESS_WORKERS_AMOUNT; i++)
        {
            _stampingProcess.AddWorker(new Worker(WorkerType.Caster));
        }

        _carFactory = new CarFactory(_castingProcess, _forgingProcess, _stampingProcess);
    }
}