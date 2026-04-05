using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Game State")]
    [SerializeField] private int maxLives = 3;

    public int CurrentLives { get; private set; }
    public int CurrentScore { get; private set; }
    public bool GameOver { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        CurrentLives = maxLives;
        CurrentScore = 0;
        GameOver = false;
    }

    public void ResetGameState()
    {
        CurrentLives = maxLives;
        CurrentScore = 0;
        GameOver = false;
    }

    public void LoseLife()
    {
        if (GameOver) return;

        CurrentLives--;
        Debug.Log("Perdiste una vida. Vidas restantes: " + CurrentLives);

        if (CurrentLives <= 0)
        {
            TriggerGameOver();
        }
    }

    public void AddScore(int amount)
    {
        if (GameOver) return;

        CurrentScore += amount;

        if (CurrentScore < 0)
            CurrentScore = 0;

        Debug.Log("Score actual: " + CurrentScore);
    }

    public void SetScore(int score)
    {
        CurrentScore = Mathf.Max(0, score);
    }

    private void TriggerGameOver()
    {
        GameOver = true;
        Debug.Log("Game Over. Perdiste todas las vidas.");

        if (PersistenceManager.Instance != null)
        {
            PersistenceManager.Instance.DeleteSaveFile();
        }
    }

    public void SetLives(int lives)
    {
        CurrentLives = Mathf.Clamp(lives, 0, maxLives);
        GameOver = CurrentLives <= 0;
    }
}