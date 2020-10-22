using UnityEngine;
using UnityEngine.UI;

public class OrbQueueUI : MonoBehaviour
{
    public Image[] orbImages;
    [SerializeField] private OrbQueue orbQueue;
    
    private void Update()
    {
        UpdateOrbQueueSprites();
    }

    private void UpdateOrbQueueSprites()
    {
        var orbArr = orbQueue.GetQueue();

        for (int i = 0; i < orbImages.Length; i++)
        {
            orbImages[i].sprite = Resources.Load<Sprite>(orbArr[i].OrbType.ToString());
        }
    }
}
