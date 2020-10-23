using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    private TMP_Text _tmpText;

    private void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _tmpText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString("C");
        }
    }
}
