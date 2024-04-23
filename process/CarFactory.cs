namespace lr2.process;

public class CarFactory(CastingProcess castingProcess, ForgingProcess forgingProcess, StampingProcess stampingProcess)
{
    private int preparedCarAmount = 0;
    
    public bool GetCar()
    {
        if (preparedCarAmount <= 0) return false;
        preparedCarAmount--;
        return true;
    }

    public void ReleaseCar()
    {
        
    }
}