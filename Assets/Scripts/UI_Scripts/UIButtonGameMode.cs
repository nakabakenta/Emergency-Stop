using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIButtonGameMode : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    private static int nowButton;//現在のボタン

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        ResetButton(nowButton);
    }

    //クリックされた場合
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            GameBase.nowGameMode = ((GameModeName)nowButton).ToString();//現在のボタン番号をゲームモード名に変換する

            //if(GameBase.gameMode == GameModeName.Normal.ToString())
            //{
            //    SceneLoader.LoadScene(SceneName.StageSelect.ToString());
            //}

            SceneLoader.LoadScene(SceneName.StageSelect.ToString());
        }
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            
        }    
    }

    //マウスが離れた場合
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {

        }
    }

    //スクロール操作が行われた場合
    public override void OnScroll(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            float scrollDelta = eventData.scrollDelta.y;//スクロールの回転量

            if (scrollDelta != 0)
            {
                //上にスクロールされた場合は-1、それ以外は1
                int vertical = (scrollDelta > 0) ? -1 : 1;

                if ((nowButton == (int)GameModeName.Normal && vertical == -1) ||
                    (nowButton == (int)GameModeName.Free && vertical == 1))
                {
                    return;
                }

                ButtonScroll(vertical);
            }
        }
    }

    void ButtonScroll(int vertical)
    {
        for(int i = 0; i < setUIButton.objUIButton.Length; i++)
        {
            RectTransform rectTransform 
                = setUIButton.objUIButton[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition 
                = new Vector2(rectTransform.anchoredPosition.x + vertical * 100, rectTransform.anchoredPosition.y + vertical * 200);
        }

        nowButton += vertical;
    }
}
