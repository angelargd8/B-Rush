using UnityEngine;

public class InventoryDebugger : MonoBehaviour
{
    public void PrintInventory()
    {
        foreach (InventoryItem item in InventoryManager.Instance.Items)
        {
            if (item.data != null)
            {
                Debug.Log(item.data.pickupName + " x" + item.amount);
            }
        }

        Debug.Log("Score: " + InventoryManager.Instance.totalScore);
        Debug.Log("Balls: " + InventoryManager.Instance.totalBallsCaught);
        Debug.Log("SpikeBall: " + InventoryManager.Instance.totalSpikeBallsCaught);
    }
}