using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonGameLevel : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text textButton;
    private string[] strButton = { "ノーマル", "ハード" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        textButton.text = strButton[GameBase.gameLevel];
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        int index = GetButton(eventData);
        int gameLevel = GameBase.gameLevel == 0 ? 1 : 0;
        textButton.text = strButton[gameLevel];
        GameBase.gameLevel = gameLevel;
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        nowButton = GetButton(eventData);
        imgButton[nowButton].color = new Color32(255, 191, 0, 255);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        imgButton[nowButton].color = new Color32(255, 255, 255, 255);
    }
}
