using System;
using UnityEngine;
using UnityEngine.UI;

public class StackUI : MonoBehaviour
{

    public Image[] orbImages;
    [SerializeField] private OrbStack orbStack;

    private void Update()
    {
        var orbArr = orbStack.GetStack();

        for (int i = 0; i < orbImages.Length; i++)
        {
            if (i < orbArr.Length)
            {
                orbImages[i].gameObject.SetActive(true);
                orbImages[i].sprite = Resources.Load<Sprite>(orbArr[i].OrbType.ToString());    
            }
            else
            {
                orbImages[i].gameObject.SetActive(false);
            }
        }
    }
}
