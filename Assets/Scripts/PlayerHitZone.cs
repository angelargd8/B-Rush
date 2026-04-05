using UnityEngine;

public class PlayerHitZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallObject ball = other.GetComponent<BallObject>();
        if (ball == null) return;

        Debug.Log("Pelota llegó al jugador: " + ball.GetData().pickupName);

        Destroy(other.gameObject);
    }
}
