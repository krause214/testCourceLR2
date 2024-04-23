namespace lr2.actor;

public class Buyer(Manager manager)
{
    public bool IsHappy = true;
    public int OrderCarsAmount = 0;
    
    public void OrderCars(int amount)
    {
        OrderCarsAmount += amount;
        manager.HandleOrder(amount);
    }

    public void BuyCars()
    {
        if (OrderCarsAmount > manager.ReadyToSaleCars)
        {
            IsHappy = false;
            OrderCarsAmount -= manager.ReadyToSaleCars;
            manager.ReadyToSaleCars = 0;
        }
        else
        {
            IsHappy = true;
            manager.ReadyToSaleCars -= OrderCarsAmount;
            OrderCarsAmount = 0;
        }
    }
}