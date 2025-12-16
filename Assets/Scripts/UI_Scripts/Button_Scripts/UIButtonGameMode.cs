using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonGameMode : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    //クリックされた場合
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[state].transform) == objButton[state])
        {
            GameBase.gameMode = (int)(GameMode)state;//現在のボタン番号をゲームモード名に変換する

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
          
    }

    //マウスが離れた場合
    public override void OnPointerExit(PointerEventData eventData)
    {
        
    }

    //スクロール操作が行われた場合
    public override void OnScroll(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[state].transform) == objButton[state])
        {
            float scroll = eventData.scrollDelta.y;//スクロールの回転量

            if (scroll != 0)
            {
                //上にスクロールされた場合は-1、それ以外は1
                int vertical = (scroll > 0) ? -1 : 1;

                if ((state == (int)GameMode.Normal && vertical == -1) ||
                    (state == (int)GameMode.Free && vertical == 1))
                    return;

                ButtonScroll(vertical);
            }
        }
    }

    void ButtonScroll(int vertical)
    {
        for (int i = 0; i < objButton.Length; i++)
        {
            RectTransform rectTransform
                = objButton[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition
                = new Vector2(rectTransform.anchoredPosition.x + vertical * 100, rectTransform.anchoredPosition.y + vertical * 200);

            if (i == state)
            {
                rectTransform.localScale = Function.SetVector3(0.75f);
            }
            else if (i == state + vertical)
            {
                rectTransform.localScale = Vector3.one;
            }
        }

        state += vertical;
    }
}
