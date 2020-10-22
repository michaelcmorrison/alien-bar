using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        string moneyString = GameManager.Instance.playerMoney.ToString("C");
        _text.text = moneyString;
    }
}
