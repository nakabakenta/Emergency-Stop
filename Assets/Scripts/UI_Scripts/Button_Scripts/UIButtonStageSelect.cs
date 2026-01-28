using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIButtonStageSelect : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objHighlight;
    public TMP_Text textLED;
    private RectTransform rtHighlight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        rtHighlight = objHighlight.GetComponent<RectTransform>();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        int index = GetButton(eventData);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        int index = GetButton(eventData);
        if(!objHighlight.activeSelf) objHighlight.SetActive(true);
        rtHighlight.anchoredPosition = Function.AlignRectTransform(rt[index], rtHighlight);
    }
}
