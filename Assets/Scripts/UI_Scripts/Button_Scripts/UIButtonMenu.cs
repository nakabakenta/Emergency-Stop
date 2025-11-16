using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public static int nowButton;//現在のボタン

    //メニュー名一覧
    enum MenuName
    {
        GameModeSelect,//ゲームモード選択
        Museum,        //資料館
        Option,        //オプション
        BackToTtle,    //タイトルに戻る
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        uIMenu.SetText(nowButton);
    }

    //クリックされた場合
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            switch (nowButton)
            {
                case (int)MenuName.GameModeSelect:
                    UIMenu.nowStatus = nowButton + 1;
                    uIMenu.SetMenu();
                    break;
                case (int)MenuName.Museum:
                    break;
                case (int)MenuName.Option:
                    break;
                case (int)MenuName.BackToTtle:
                    UIMenu.nowStatus = nowButton;
                    uIMenu.SetMenu();
                    break;
            }
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

                if ((nowButton == (int)MenuName.GameModeSelect && vertical == -1) ||
                    (nowButton == (int)MenuName.BackToTtle && vertical == 1))
                {
                    return;
                }

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

            if(i == nowButton)
            {
                rectTransform.localScale = Function.SetVector3(0.75f);
            }
            else if( i == nowButton + vertical)
            {
                rectTransform.localScale = Vector3.one;
            }
        }

        nowButton += vertical;
        uIMenu.SetText(nowButton);
    }
}
