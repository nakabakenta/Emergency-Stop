using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Stage;

public class UIButtonGameMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image[] imgUIBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        nowButton = GetButton(eventData);
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        nowButton = GetButton(eventData);
        imgUIBase[nowButton].color = new Color32(255, 191, 0, 255);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        imgUIBase[nowButton].color = new Color32(255, 255, 255, 255);
    }
}
