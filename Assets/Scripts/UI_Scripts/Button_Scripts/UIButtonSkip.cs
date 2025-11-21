using UnityEngine.EventSystems;

public class UIButtonSkip : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public override void InputButtonLeft()
    {
        Stage.status++;
    }
}
