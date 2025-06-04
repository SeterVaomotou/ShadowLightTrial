using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text livesText;
    public TMP_Text timerText;
    public GameObject gameOverPanel;

    private int lives = 3;
    private Vector2 spawnPoint;
    private Vector2? checkpoint = null;
    public GameObject gameCompletePanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        spawnPoint = GameObject.FindWithTag("Player").transform.position;
        UpdateLivesUI();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Time.timeSinceLevelLoad.ToString("F1");
        }
    }



    public void PlayerDie()
    {
        lives--;

        if (livesText != null)
            livesText.text = "Lives: " + lives;

        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            GameOver();
        }
    }

    public void SetCheckpoint(Vector2 pos)
    {
        checkpoint = pos;
        Debug.Log("Checkpoint position saved: " + checkpoint.Value);
    }


    void Respawn()
    {
        GameObject player = GameObject.FindWithTag("Player"); // Define it here

        if (player != null)
        {
            Vector2 respawnPosition = checkpoint.HasValue ? checkpoint.Value : spawnPoint;
            player.transform.position = respawnPosition;

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

            Debug.Log("Respawned at " + (checkpoint.HasValue ? "Checkpoint" : "Spawn Point"));
        }
        else
        {
            Debug.LogError("Player not found for respawn.");
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trial_1");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void GameComplete()
    {
        Time.timeScale = 0f;
        gameCompletePanel.SetActive(true);
        AudioManager.Instance.PlayEndTrial();
    }
}
