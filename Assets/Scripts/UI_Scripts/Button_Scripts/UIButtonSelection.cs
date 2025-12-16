using System;
using UnityEngine.EventSystems;

public class UIButtonSelection : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private enum Button { Yes, No }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[state].transform) == objButton[(int)Button.Yes].gameObject) SceneLoader.LoadScene(SceneName.Title.ToString());
        else UIMenu.uIMenu.SetMenu(4);
    }
}
