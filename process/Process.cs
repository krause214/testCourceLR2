using lr2.actor;
using lr2.entity;

namespace lr2.process;

public abstract class Process(WorkerType requiredWorkerType, int requiredWorkerAmount)
{
    private List<Worker> _workers = [];
    private List<Material> _materials = []; 

    protected int PreparedAmount = 0;

    void DoProcess()
    {
        while (HasEnoughWorkers() && _materials.Count() > 0)
        {
            PreparedAmount++;
        }
    }
    protected abstract Detail? GetNewDetail();

    private bool HasEnoughWorkers()
    {
        return _workers.Count >= requiredWorkerAmount;
    }

    public void AddWorker(Worker worker)
    {
        if (worker.GetWorkerType().Equals(requiredWorkerType))
        {
            _workers.Add(worker);
        }
    }
    
    public void AddMaterial(Material material)
    {
        _materials.Add(material);
    }

    public void RemoveWorker()
    {
        if (_workers.Count > 0)
        {
            _workers.Remove(_workers[0]);   
        }
    }
    
}