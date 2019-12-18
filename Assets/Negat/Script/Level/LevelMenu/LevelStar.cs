using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStar : MonoBehaviour
{
    public Sprite[] starSprites ;

    public Image image;

    public void SetStarSprite(int starAmount){
        image.sprite = starSprites[starAmount];
    }
}
