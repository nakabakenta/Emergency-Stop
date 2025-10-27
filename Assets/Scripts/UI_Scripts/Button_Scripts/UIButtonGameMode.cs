using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonGameMode : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public static int nowButton;//現在のボタン

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    //クリックされた場合
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            GameBase.nowGameMode = ((GameMode)nowButton).ToString();//現在のボタン番号をゲームモード名に変換する

            //if(GameBase.gameMode == GameModeName.Normal.ToString())
            //{
            //    SceneLoader.LoadScene(SceneName.StageSelect.ToString());
            //}

            SceneLoader.LoadScene(Scene.StageSelect.ToString());
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

                if ((nowButton == (int)GameMode.Normal && vertical == -1) ||
                    (nowButton == (int)GameMode.Free && vertical == 1))
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

            if (i == nowButton)
            {
                rectTransform.localScale = Function.ResetVector3(0.75f);
            }
            else if (i == nowButton + vertical)
            {
                rectTransform.localScale = Vector3.one;
            }
        }

        nowButton += vertical;
        //uIMenu.SetText(nowButton);
    }
}
