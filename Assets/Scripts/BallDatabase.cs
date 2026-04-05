using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BallDatabase", menuName = "Scriptable Objects/Ball Database")]
public class BallDatabase : ScriptableObject
{
    public List<BallPickupData> balls;

    public BallPickupData GetByID(string id)
    {
        return balls.Find(ball => ball.pickupID == id);
    }
}