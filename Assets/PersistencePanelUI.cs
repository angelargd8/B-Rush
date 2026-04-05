using TMPro;
using UnityEngine;

public class PersistencePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    public void SaveGameFromUI()
    {
        if (PersistenceManager.Instance == null)
            return;

        PersistenceManager.Instance.SaveGame();

        if (statusText != null)
            statusText.text = "Status: Game saved";
    }

    public void LoadGameFromUI()
    {
        if (PersistenceManager.Instance == null)
            return;

        PersistenceManager.Instance.LoadGame();

        if (statusText != null)
            statusText.text = "Status: Game loaded";
    }

    public void DeleteSaveFromUI()
    {
        if (PersistenceManager.Instance == null)
            return;

        PersistenceManager.Instance.DeleteSaveFile();

        if (statusText != null)
            statusText.text = "Status: Save deleted";
    }
}