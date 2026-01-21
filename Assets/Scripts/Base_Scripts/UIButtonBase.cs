using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    protected const int other = -1;  //ボタン以外
    protected int nowButton = 0;     //現在のボタン
    protected GameObject[] objButton;//ボタンオブジェクト
    protected RectTransform[] rt;    //ボタントランスフォーム

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        var list = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if (child.name == "UI_Button_Back") continue;
            list.Add(child.gameObject);
        }

        objButton = list.ToArray();
        rt = new RectTransform[objButton.Length];

        for (int index = 0; index < rt.Length; index++)
            rt[index] = objButton[index].GetComponent<RectTransform>();
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

    //カーソルのボタン取得
    public int GetButton(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null) return other;

        for (int index = 0; index < objButton.Length; index++)
            if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[index].transform)) return index;

        return other;
    }
}
