using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; private set; }

    [SerializeField] private BallDatabase ballDatabase;
    [SerializeField] private Transform playerTransform;

    private string savePath;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        savePath = Path.Combine(Application.persistentDataPath, "savegame.json");
    }

    public void SaveGame()
    {
        if (LevelManager.Instance != null && LevelManager.Instance.GameOver)
        {
            Debug.LogWarning("No se puede guardar porque el juego terminó.");
            return;
        }

        GameSaveData saveData = new GameSaveData();

        foreach (InventoryItem item in InventoryManager.Instance.Items)
        {
            if (item.data == null) continue;

            InventoryItemSaveData itemSave = new InventoryItemSaveData();
            itemSave.pickupID = item.data.pickupID;
            itemSave.amount = item.amount;
            saveData.inventory.Add(itemSave);
        }

        saveData.totalScore = InventoryManager.Instance.totalScore;
        saveData.totalBallsCaught = InventoryManager.Instance.totalBallsCaught;
        saveData.totalSpikeBallsCaught = InventoryManager.Instance.totalSpikeBallsCaught;
        saveData.currentLives = LevelManager.Instance.CurrentLives;

        if (playerTransform != null)
        {
            saveData.playerPosX = playerTransform.position.x;
            saveData.playerPosY = playerTransform.position.y;
            saveData.playerPosZ = playerTransform.position.z;
        }

        saveData.lastSaveTime = System.DateTime.Now.ToString();

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Juego guardado en: " + savePath);
    }

    public void LoadGame()
    {
        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager.Instance es null.");
            return;
        }

        if (LevelManager.Instance == null)
        {
            Debug.LogError("LevelManager.Instance es null.");
            return;
        }

        if (ballDatabase == null)
        {
            Debug.LogError("ballDatabase no está asignado en PersistenceManager.");
            return;
        }

        if (!File.Exists(savePath))
        {
            Debug.LogWarning("No existe archivo de guardado. Se iniciará una partida nueva.");

            InventoryManager.Instance.ClearInventory();
            LevelManager.Instance.ResetGameState();
            return;
        }

        string json = File.ReadAllText(savePath);
        GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(json);

        if (saveData == null)
        {
            Debug.LogError("No se pudo leer el archivo de guardado.");
            return;
        }

        if (saveData.inventory == null)
        {
            Debug.LogWarning("El inventario cargado venía null. Se inicializará vacío.");
            saveData.inventory = new System.Collections.Generic.List<InventoryItemSaveData>();
        }

        InventoryManager.Instance.ClearInventory();

        foreach (InventoryItemSaveData itemSave in saveData.inventory)
        {
            if (itemSave == null)
                continue;

            BallPickupData ballData = ballDatabase.GetByID(itemSave.pickupID);

            if (ballData == null)
            {
                Debug.LogWarning("No se encontró BallPickupData con ID: " + itemSave.pickupID);
                continue;
            }

            InventoryManager.Instance.AddRestoredItem(ballData, itemSave.amount);
        }

        InventoryManager.Instance.RestoreStats(
            saveData.totalScore,
            saveData.totalBallsCaught,
            saveData.totalSpikeBallsCaught
        );

        LevelManager.Instance.SetLives(saveData.currentLives);

        if (playerTransform != null)
        {
            playerTransform.position = new Vector3(
                saveData.playerPosX,
                saveData.playerPosY,
                saveData.playerPosZ
            );
        }

        Debug.Log("Juego cargado correctamente.");
        Debug.Log("Vidas cargadas: " + saveData.currentLives);
        Debug.Log("Último guardado: " + saveData.lastSaveTime);
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Archivo de guardado eliminado.");
        }
    }
}