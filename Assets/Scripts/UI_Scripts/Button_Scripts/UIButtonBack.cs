using UnityEngine.EventSystems;

public class UIButtonBack : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public override void InputButtonLeft(PointerEventData eventData)
    {
        UIMenu.uIMenu.SetMenu(4);
    }
}
