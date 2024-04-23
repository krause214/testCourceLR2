using lr2.actor;
using lr2.entity;

namespace lr2.process;

public abstract class Process(WorkerType requiredWorkerType, int requiredWorkerAmount)
{
    private readonly List<Worker> _workers = [];

    private int _orderAmount = 0;

    Detail? DoProcess(Material material)
    {
        if (HasEnoughWorkers() && material.IsQualitative())
        {
            return PrepareNewDetail();
        }
        else {
            return null;
        }
    }
    protected abstract Detail? PrepareNewDetail();

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

    public void RemoveWorker()
    {
        if (_workers.Count > 0)
        {
            _workers.Remove(_workers[0]);   
        }
    }

    public void OrderDetails(int amount)
    {
        _orderAmount += amount;
    }
    
}