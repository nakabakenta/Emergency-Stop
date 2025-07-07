using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected string[] excludeName;  //除外する名前
    protected GameObject[] objButton;//ボタンオブジェクト
    protected Button button;         //Buttonコンポーネント

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //取得
        button = this.GetComponent<Button>();//Button
    }

    //クリックされた場合
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }

    //マウスが重なった場合
    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    //マウスが離れた場合
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
