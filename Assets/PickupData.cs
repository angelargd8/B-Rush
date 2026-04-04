using UnityEngine;

[CreateAssetMenu(fileName = "PickupData", menuName = "Scriptable Objects/PickupData")]
public class PickupData : ScriptableObject
{
    [Header("Basic info")]
    public string pickupID;
    public string pickupName;


}
