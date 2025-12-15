using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    //メニュー名一覧
    enum Menu
    {
        GameModeSelect,//ゲームモード選択
        Museum,        //資料館
        Option,        //オプション
        BackToTtle,    //タイトルに戻る
    }

    Menu menu = Menu.GameModeSelect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIMenu.uIMenu.SetTextDes((int)menu);
    }

    public override void InputButtonLeft()
    {
        if (this.name == setUIButton.objUIButton[(int)menu].name)
        {
            switch (menu)
            {
                case Menu.GameModeSelect:
                    UIMenu.uIMenu.SetMenu(1);
                    break;
                case Menu.Museum:
                    break;
                case Menu.Option:
                    break;
                case Menu.BackToTtle:
                    UIMenu.uIMenu.SetMenu((int)menu);
                    break;
            }
        }
    }

    //スクロール操作が行われた場合
    public override void OnScroll(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[(int)menu].name)
        {
            float scrollDelta = eventData.scrollDelta.y;//スクロールの回転量

            if (scrollDelta != 0)
            {
                //上にスクロールされた場合は-1、それ以外は1
                int vertical = (scrollDelta > 0) ? -1 : 1;

                if ((menu == Menu.GameModeSelect && vertical == -1) ||
                    (menu == Menu.BackToTtle && vertical == 1))
                    return;

                ButtonScroll(vertical);
            }
        }
    }

    void ButtonScroll(int vertical)
    {
        for (int i = 0; i < setUIButton.objUIButton.Length; i++)
        {
            RectTransform rectTransform
                = setUIButton.objUIButton[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition
                = new Vector2(rectTransform.anchoredPosition.x + vertical * 100, rectTransform.anchoredPosition.y + vertical * 200);

            if (i == (int)menu) rectTransform.localScale = Function.SetVector3(0.75f);
            else if (i == (int)menu + vertical) rectTransform.localScale = Vector3.one;
        }

        menu += vertical;
        UIMenu.uIMenu.SetTextDes((int)menu);
    }
}
