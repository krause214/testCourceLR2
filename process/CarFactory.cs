using lr2.entity;

namespace lr2.process;

public class CarFactory(CastingProcess castingProcess, ForgingProcess forgingProcess, StampingProcess stampingProcess)
{
    private int preparedCarAmount = 0;
    public int enginesAmount = 0;
    public int framesAmount = 0;
    public int chassisAmount = 0;
    
    public int GetCars()
    {
        return preparedCarAmount;
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

        while (enginesAmount - 1 > 0 
               && chassisAmount - 1 > 0
               && framesAmount - 1 > 0) 
        {
            enginesAmount--;
            chassisAmount--;
            framesAmount--;
            preparedCarAmount++;
        }
    }
}