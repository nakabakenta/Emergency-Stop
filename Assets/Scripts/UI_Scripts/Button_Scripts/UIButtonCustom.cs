using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonCustom : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image imgUIBase;
    public TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        int index = GetButton(eventData);
        text.enabled = !text.enabled;
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        nowButton = GetButton(eventData);
        imgUIBase.color = new Color32(255, 191, 0, 255);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        imgUIBase.color = new Color32(255, 255, 255, 255);
    }
}
