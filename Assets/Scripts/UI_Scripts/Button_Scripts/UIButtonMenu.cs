using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    private enum Button { GameModeSelect, Museum, Option, BackToTtle }//ボタン一覧

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[state].transform) == objButton[state]) UIMenu.uIMenu.SetMenu(state);
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

                if ((state == (int)Button.GameModeSelect && vertical == -1) ||
                    (state == (int)Button.BackToTtle && vertical == 1))
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

            if (i == state) rectTransform.localScale = Function.SetVector3(0.75f);
            else if (i == state + vertical) rectTransform.localScale = Vector3.one;
        }

        state += vertical;
    }
}
