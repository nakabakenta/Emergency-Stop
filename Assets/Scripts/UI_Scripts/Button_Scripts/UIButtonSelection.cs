using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSelection : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static int nowButton;//現在のボタン

    //ボタン名一覧
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
            SceneLoader.LoadScene(Scene.Title.ToString());
        }
        else
        {
            UIMenu.nowStatus = (int)UIMenu.UIName.Menu;
            uIMenu.SetMenu();
        }
    }
}
