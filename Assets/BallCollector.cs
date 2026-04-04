using UnityEngine;

public class BallCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallObject ball = other.GetComponent<BallObject>();
        if (ball == null) return;

        BallPickupData data = ball.GetData();
        if (data == null) return;

        InventoryManager.Instance.AddItem(data);

        if (data.pickupType == PickupType.SpikeBall)
        {
            LevelManager.Instance.LoseLife();
            Debug.Log("Tocaste una SpikeBall.");
        }
        else
        {
            Debug.Log("Recogiste: " + data.pickupName);
        }

        Destroy(other.gameObject);
    }
}