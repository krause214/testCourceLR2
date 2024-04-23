using lr2.actor;
using lr2.entity;

namespace lr2.process;

public class StampingProcess(WorkerType requiredWorkerType, int requiredWorkerAmount) : Process(requiredWorkerType, requiredWorkerAmount)
{
    protected override Detail? GetNewDetail()
    {
        if (PreparedAmount > 0)
        {
            PreparedAmount--;
            return new Detail(DetailType.Frame);
        }
        return null;
    }
}