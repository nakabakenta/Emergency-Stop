using UnityEngine.EventSystems;

public class UIButtonSkip : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //ƒNƒŠƒbƒN‚³‚ê‚½ê‡
    public override void OnPointerClick(PointerEventData eventData)
    {
        NextStatus(eventData);
    }
}
