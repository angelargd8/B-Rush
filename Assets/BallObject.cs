using UnityEngine;

public class BallObject : MonoBehaviour
{
    private BallPickupData data;
    private Transform playerTarget;

    public void Initialize(BallPickupData ballData, Transform target)
    {
        data = ballData;
        playerTarget = target;

    }
    
    private void Update()
    {
        if (data == null || playerTarget == null) return;

        Vector3 targetPosition = new Vector3(
            playerTarget.position.x,
            transform.position.y,
            playerTarget.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            data.speed * Time.deltaTime
        );
    }

    public BallPickupData GetData()
    {
        return data;
    }
}