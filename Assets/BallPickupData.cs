using UnityEngine;

[CreateAssetMenu(fileName = "NewBallPickup", menuName = "Scriptable Objects/Ball Pickup")]
public class BallPickupData : PickupData
{
    [Header("BallPickUp")]
    public PickupType pickupType;
    public int scoreValue = 1;
    public float speed = 3f;
    public bool addToInventory = true;

}
