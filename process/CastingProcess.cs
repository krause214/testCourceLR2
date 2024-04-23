using lr2.actor;
using lr2.entity;

namespace lr2.process;

public class CastingProcess(WorkerType requiredWorkerType, int requiredWorkerAmount) : Process(requiredWorkerType, requiredWorkerAmount)
{
    protected override Detail? PrepareNewDetail()
    {
        return new Detail(DetailType.Engine);
    }
}