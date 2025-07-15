using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonBackToScene : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //ƒ{ƒ^ƒ“–¼ˆê——
    enum ButtonName
    {
        Yes,
        No,
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[(int)ButtonName.Yes].name)
        {
            SceneLoader.LoadScene(SceneName.Title.ToString());
        }
        else
        {
            UIMenu.nowStatus = (int)UIMenu.UIName.Menu;
            uIMenu.SetMenu();
        }
    }
}
