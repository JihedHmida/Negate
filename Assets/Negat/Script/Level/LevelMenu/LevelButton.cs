using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public LevelSelectMenu menu;
    public Sprite lockSprite;
    public Text leveltext;
    public GameObject levelStarPrefab;
    private int level = 0;
    private Button button;
    private Image image;
    private LevelStar levelStar;
    private void OnEnable()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        levelStar = Instantiate(levelStarPrefab, this.transform).GetComponent<LevelStar>();
    }

    public void Setup(int level, int star, bool isUnlocked)
    {
        this.level = level;
        leveltext.text = level.ToString();
        if (isUnlocked)
        {
            image.sprite = null;
            button.enabled = true;
            leveltext.gameObject.SetActive(true);
            levelStar.SetStarSprite(star);
            levelStar.gameObject.SetActive(true);
        }
        else
        {
            image.sprite = lockSprite;
            button.enabled = false;
            leveltext.gameObject.SetActive(false);
            levelStar.gameObject.SetActive(false);

        }
    }

    public void OnClick()
    {
        menu.StartLevel(level);
    }

}
