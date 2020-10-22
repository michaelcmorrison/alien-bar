using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    public Image drinkImage;
    public Image[] orbImages;
    public TMP_Text text;

    public void FillPanel(DrinkOrder order)
    {
        var drink = order.Drink;
        drinkImage.sprite = drink.drinkSprite;
        var orbSprites = GetOrbSprites(drink);
        for (int i = 0; i < orbImages.Length; i++)
        {
            orbImages[i].sprite = orbSprites[i];
        }
        text.text = drink.drinkPrice.ToString("C2");
    }

    private List<Sprite> GetOrbSprites(Drink drink)
    {
        var orbTypes = (OrbType[]) Enum.GetValues(typeof(OrbType)).Cast<OrbType>();
        var orbSprites = new List<Sprite>();

        foreach (var character in drink.drinkId.ToCharArray())
        {
            var num = (int) char.GetNumericValue(character);
            orbSprites.Add(Resources.Load<Sprite>(orbTypes[num].ToString()));
        }

        return orbSprites;
    }
}