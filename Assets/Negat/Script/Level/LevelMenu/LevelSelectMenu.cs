using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    public int totalLevel = 3;
    public int unlockedLevel = 1;

    private int totalPage = 0;
    private int page = 0;
    private int pageItem = 9;

    public GameObject nextButton;
    public GameObject backButton;
    private LevelButton[] levelButtons;

    private void OnEnable()
    {
        levelButtons = GetComponentsInChildren<LevelButton>();
    }


    private void Start()
    {
        Refresh();
    }

    public void StartLevel(int level)
    {

        //Loader.LoadGameScene(level - 1);
        Debug.Log(level);
        if (level == unlockedLevel)
        {
            unlockedLevel++;
        }
        int star = GetStar(level);
        star = Mathf.Clamp(star + 1, 0, 3);
        SetStar(level, star);
        Refresh();

    }

    public void ClickNext()
    {
        page++;
        Refresh();
    }
    public void ClickBack()
    {
        page--;
        Refresh();
    }

    public void Refresh()
    {
        totalPage = totalLevel / pageItem;
        int index = page * pageItem;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = index + i + 1;
            if (level <= totalLevel)
            {
                levelButtons[i].gameObject.SetActive(true);
                levelButtons[i].Setup(level, GetStar(level), level <= unlockedLevel);
            }
            else
            {
                levelButtons[i].gameObject.SetActive(false);

            }
        }
        CheckButton();
    }

    private void CheckButton()
    {
        backButton.SetActive(page > 0);
        nextButton.SetActive(page < totalPage);
    }
    private void SetStar(int level, int starAmount)
    {
        PlayerPrefs.SetInt(GetKey(level), starAmount);
    }
    private int GetStar(int level)
    {
        return PlayerPrefs.GetInt(GetKey(level), 0);
    }
    private string GetKey(int level)
    {
        return "Level_" + level + "_Star";
    }

}
