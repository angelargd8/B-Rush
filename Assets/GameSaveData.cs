using System;
using System.Collections.Generic;

[Serializable]
public class GameSaveData
{
    public List<InventoryItemSaveData> inventory = new List<InventoryItemSaveData>();

    public int totalScore;
    public int totalBallsCaught;
    public int totalSpikeBallsCaught;
    public int currentLives;
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;
    public string lastSaveTime;
}