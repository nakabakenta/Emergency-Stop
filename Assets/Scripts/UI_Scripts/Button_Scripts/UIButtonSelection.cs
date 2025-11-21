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

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[(int)ButtonName.Yes].name)
        {
            SceneLoader.LoadScene(SceneName.Title.ToString());
        }
        else
        {
            UIMenu.uIMenu.SetMenu((int)UIMenu.UIName.Menu);
        }
    }
}
