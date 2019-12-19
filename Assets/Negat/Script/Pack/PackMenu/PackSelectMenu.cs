using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackSelectMenu : MonoBehaviour
{
    public int totalPack = 3;
    public int unlockedPack = 3;

    private int totalPage = 0;
    private int page = 0;
    private int pageItem = 9;

    public GameObject nextButton;
    public GameObject backButton;
    private PackButton[] packButtons;

    private void OnEnable()
    {
        totalPack = PackManager.PacksCount();
        packButtons = GetComponentsInChildren<PackButton>();
    }


    private void Start()
    {
        Refresh();
    }

    public void LoadPack(int pack)
    {
        LevelLoaderManager.Instance.pack = pack;
        Loader.LoadPackScene(pack);
        //Debug.Log(pack);
        // if (pack == unlockedLevel)
        // {
        //     unlockedLevel++;
        // }
        // int star = GetStar(pack);
        // star = Mathf.Clamp(star + 1, 0, 3);
        // SetStar(pack, star);
        // Refresh();

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
        totalPage = totalPack / pageItem;
        int index = page * pageItem;
        for (int i = 0; i < packButtons.Length; i++)
        {
            int pack = index + i + 1;
            if (pack <= totalPack)
            {
                packButtons[i].gameObject.SetActive(true);
                packButtons[i].Setup(pack, pack <= unlockedPack);
            }
            else
            {
                packButtons[i].gameObject.SetActive(false);

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
