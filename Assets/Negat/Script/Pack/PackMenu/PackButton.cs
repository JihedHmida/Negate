using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackButton : MonoBehaviour
{
    public PackSelectMenu menu;
    public Sprite lockSprite;
    public Text packtext;
    private int pack = 0;
    private Button button;
    private Image image;
    private void OnEnable()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void Setup(int pack, bool isUnlocked)
    {
        this.pack = pack;
        packtext.text = pack.ToString();
        if (isUnlocked)
        {
            image.sprite = null;
            button.enabled = true;
            packtext.gameObject.SetActive(true);
        }
        else
        {
            image.sprite = lockSprite;
            button.enabled = false;
            packtext.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        menu.LoadPack(pack);
    }
}
