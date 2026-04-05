using UnityEngine;

public class SaveLoadInput : MonoBehaviour
{
    private void Update()
    {
        if (PersistenceManager.Instance == null)
            return;

        if (Input.GetKeyDown(KeyCode.K))
        {
            PersistenceManager.Instance.SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PersistenceManager.Instance.LoadGame();
        }
    }
}