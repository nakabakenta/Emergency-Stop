using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSkip : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    //ƒNƒŠƒbƒN‚³‚ê‚½ê‡
    public override void OnPointerClick(PointerEventData eventData)
    {
        Stage.status = (int)GameStatus.GameDep;
    }
}
