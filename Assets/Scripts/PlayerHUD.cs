using System.Text;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text inventoryText;

    private void Update()
    {
        RefreshHUD();
    }

    private void RefreshHUD()
    {
        RefreshLives();
        RefreshScore();
        RefreshInventory();
    }

    private void RefreshLives()
    {
        if (livesText == null || LevelManager.Instance == null)
            return;

        livesText.text = "LIVES: " + LevelManager.Instance.CurrentLives;
    }

    private void RefreshScore()
    {
        if (scoreText == null || InventoryManager.Instance == null)
            return;

        scoreText.text = "SCORE: " + InventoryManager.Instance.totalScore;
    }

    private void RefreshInventory()
    {
        if (inventoryText == null || InventoryManager.Instance == null)
            return;

        var items = InventoryManager.Instance.Items;

        if (items == null || items.Count == 0)
        {
            inventoryText.text = "Inventory:\n- Empty";
            return;
        }

        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Inventory:");

        foreach (InventoryItem item in items)
        {
            if (item == null || item.data == null)
                continue;

            builder.AppendLine("- " + item.data.pickupName + " x" + item.amount);
        }

        inventoryText.text = builder.ToString();
    }
}