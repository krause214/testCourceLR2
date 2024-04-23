using lr2.actor;
using lr2.entity;

namespace lr2.process;

public abstract class Process(WorkerType requiredWorkerType, int requiredWorkerAmount)
{
    public List<Worker> Workers = [];
    public List<Material> Materials = []; 

    protected int PreparedAmount = 0;

    void DoProcess()
    {
        while (HasEnoughWorkers() && Materials.Count() > 0)
        {
            PreparedAmount++;
        }
    }
    public abstract Detail? GetNewDetail();

    private bool HasEnoughWorkers()
    {
        return Workers.Count >= requiredWorkerAmount;
    }

    public void AddWorker(Worker worker)
    {
        if (worker.GetWorkerType().Equals(requiredWorkerType))
        {
            Workers.Add(worker);
        }
    }
    
    public void AddMaterial(Material material)
    {
        Materials.Add(material);
    }

    public void RemoveWorker()
    {
        if (Workers.Count > 0)
        {
            Workers.Remove(Workers[0]);   
        }
    }
    
}