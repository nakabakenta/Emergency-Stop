using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonReturn : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        UIMenu.nowStatus = (int)UIMenu.UIName.Menu;
        uIMenu.SetMenu();
    }
}
