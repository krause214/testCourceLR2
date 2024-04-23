namespace lr2.actor;

public class Buyer(Manager manager)
{
    public void OrderCars(int amount)
    {
        manager.HandleOrder(amount);
    }
}