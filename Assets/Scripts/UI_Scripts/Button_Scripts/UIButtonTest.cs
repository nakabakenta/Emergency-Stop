using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonTest : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool openMenu = false;//メニューを開いたかどうかの可否

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    //クリックされた場合
    public override void OnPointerClick(PointerEventData eventData)
    {
        RectTransform rectTransform
            = this.transform.Find("UI_Menu").GetComponent<RectTransform>();

        openMenu = !openMenu;
        rectTransform.sizeDelta = (openMenu) ? new Vector2(450, 750) : new Vector2(0, 0);
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    //マウスが離れた場合
    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}
