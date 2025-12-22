using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    protected int nowButton = 0;
    protected GameObject[] objButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        List<GameObject> list = new List<GameObject>();

        for (int index = 0; index < this.transform.childCount; index++)
        {
            GameObject objChild = transform.GetChild(index).gameObject;
            if (objChild.name == "UI_Button_Back") continue;
            list.Add(objChild);
        }

        objButton = list.ToArray();
    }

    //クリックされた場合
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) InputButtonLeft(eventData);//左ボタン入力
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
    public virtual void InputButtonLeft(PointerEventData eventData) {}
}
