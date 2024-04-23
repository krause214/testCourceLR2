using lr2.process;

namespace lr2.actor;

public class Manager
{
    private const int CASTING_PROCESS_WORKERS_AMOUNT = 4;
    private const int FORGING_PROCESS_WORKERS_AMOUNT = 4;
    private const int STAMPING_PROCESS_WORKERS_AMOUNT = 4;
    
    private CarFactory _carFactory;
    private CastingProcess _castingProcess;
    private ForgingProcess _forgingProcess;
    private StampingProcess _stampingProcess;
    
    
    private bool IsFabricInited = false;
    public void HandleOrder(int amount)
    {
        if (!IsFabricInited)
        {
            InitFabric();
            IsFabricInited = true;
        }
        
    }

    private void InitFabric()
    {
        
    }
}