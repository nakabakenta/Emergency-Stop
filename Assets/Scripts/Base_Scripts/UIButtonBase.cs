using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    protected Button button;       //Buttonコンポーネント
    public SetUIButton setUIButton;//SetUIButtonスクリプト
    public static UIMenu uIMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //取得
        button = this.GetComponent<Button>();//Button

        if(GameBase.nowScene == SceneName.Menu.ToString())
        {
            if (uIMenu == null)
            {
                uIMenu = GameObject.Find("Canvas_" + GameBase.nowScene).GetComponent<UIMenu>();
            }
        }
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

    //スクロール操作が行われた場合
    public virtual void OnScroll(PointerEventData eventData)
    {

    }
}
