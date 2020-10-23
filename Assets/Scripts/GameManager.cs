using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameRunning;
    public float playerMoney = 0;

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
        gameRunning = false;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        gameRunning = true;
        pauseMenu.SetActive(false);
    }
    
    public void TriggerEndGame()
    {
        gameRunning = false;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        scoreText.text = "You made " + playerMoney.ToString("C");
        PostHighScore(playerMoney);
    }

    public void PostHighScore(float score)
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