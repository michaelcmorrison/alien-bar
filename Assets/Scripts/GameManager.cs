using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float playerMoney = 0;
    
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
    }

    public void TriggerEndGame()
    {
        Debug.Log("Endgame triggered");
    }
}