using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public SetUIButton setUIButton;//SetUIButtonスクリプト

    //クリックされた場合
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) InputButtonLeft();//左ボタン入力
    }

    //マウスが重なった場合
    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    //マウスが離れた場合
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }

    //スクロール操作が行われた場合
    public virtual void OnScroll(PointerEventData eventData)
    {

    }

    //左ボタン入力
    public virtual void InputButtonLeft() {}
}
