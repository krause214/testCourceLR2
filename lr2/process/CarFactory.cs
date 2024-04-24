using lr2.entity;

namespace lr2.process;

public class CarFactory(CastingProcess castingProcess, ForgingProcess forgingProcess, StampingProcess stampingProcess)
{
    public int preparedCarAmount = 0;
    public int enginesAmount = 0;
    public int framesAmount = 0;
    public int chassisAmount = 0;
    
    public int GetCars()
    {
        int prepared = preparedCarAmount;
        preparedCarAmount = 0;
        return prepared;
    }

    public void ReleaseCars()
    {
        while (castingProcess.GetNewDetail() != null)
        {
            enginesAmount++;
        }
        while (forgingProcess.GetNewDetail() != null)
        {
            chassisAmount++;
        }
        while (stampingProcess.GetNewDetail() != null)
        {
            framesAmount++;
        }

        while (enginesAmount > 0 
               && chassisAmount > 0
               && framesAmount > 0) 
        {
            enginesAmount--;
            chassisAmount--;
            framesAmount--;
            preparedCarAmount++;
        }
    }
}