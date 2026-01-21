using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonStageSelect : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rtHighlight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        int index = GetButton(eventData);

        rtHighlight = rt[index];
    }
}
