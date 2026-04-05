using UnityEngine;

public class BallCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (LevelManager.Instance == null || LevelManager.Instance.GameOver)
            return;

        BallObject ball = other.GetComponent<BallObject>();
        if (ball == null) return;

        BallPickupData data = ball.GetData();
        if (data == null) return;

        if (data.pickupType == PickupType.SpikeBall)
        {
            LevelManager.Instance.LoseLife();
            InventoryManager.Instance.totalSpikeBallsCaught++;
            Debug.Log("Tocaste una SpikeBall.");
        }
        else
        {
            InventoryManager.Instance.AddItem(data);
            Debug.Log("Recogiste: " + data.pickupName);
        }

        Destroy(other.gameObject);
    }
}