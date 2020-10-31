using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameRunning;
    public float playerMoney;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TMP_Text scoreText;
    
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        gameRunning = true;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        gameRunning = false;
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        gameRunning = true;
        Time.timeScale = 1;
    }
    
    public void TriggerEndGame()
    {
        if (!gameRunning) return;
        
        gameRunning = false;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        scoreText.text = "You made " + playerMoney.ToString("C");
        PostHighScore();
    }

    private void PostHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            var highScore = PlayerPrefs.GetFloat("HighScore");
            if (highScore < playerMoney)
            {
                PlayerPrefs.SetFloat("HighScore", playerMoney);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", playerMoney);
        }
        
    }
}