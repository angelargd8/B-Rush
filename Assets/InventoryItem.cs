using System;

[Serializable]
public class InventoryItem
{
    public BallPickupData data;
    public int amount;
    public InventoryItem(BallPickupData data, int amount)
    {
        this.data = data;
        this.amount = amount;

    }
}
