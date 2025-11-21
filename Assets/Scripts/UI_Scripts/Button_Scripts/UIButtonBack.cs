using UnityEngine.EventSystems;

public class UIButtonBack : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public override void InputButtonLeft()
    {
        UIMenu.uIMenu.SetMenu(0);
    }
}
