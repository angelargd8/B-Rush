using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private List<InventoryItem> items = new List<InventoryItem>();
    public List<InventoryItem> Items => items;

    public int totalScore;
    public int totalBallsCaught;
    public int totalSpikeBallsCaught;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddItem(BallPickupData data)
    {
        if (data == null) return;

        if (data.addToInventory)
        {
            InventoryItem existingItem = items.Find(item => item.data == data);

            if (existingItem != null)
            {
                existingItem.amount++;
            }
            else
            {
                items.Add(new InventoryItem(data, 1));
            }
        }

        totalScore += data.scoreValue;

        if (data.pickupType == PickupType.SpikeBall)
        {
            totalSpikeBallsCaught++;
        }
        else
        {
            totalBallsCaught++;
        }
    }

    public void ClearInventory()
    {
        items.Clear();
        totalScore = 0;
        totalBallsCaught = 0;
        totalSpikeBallsCaught = 0;
    }

    public void RestoreStats(int score, int ballsCaught, int SpikeBallsCaught)
    {
        totalScore = score;
        totalBallsCaught = ballsCaught;
        totalSpikeBallsCaught = SpikeBallsCaught;
    }

    public void AddRestoredItem(BallPickupData data, int amount)
    {
        if (data == null || amount <= 0) return;

        InventoryItem existingItem = items.Find(item => item.data == data);

        if (existingItem != null)
        {
            existingItem.amount += amount;
        }
        else
        {
            items.Add(new InventoryItem(data, amount));
        }
    }

}