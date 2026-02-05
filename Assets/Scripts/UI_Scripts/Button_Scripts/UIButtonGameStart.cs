using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Stage;

public class UIButtonGameStart : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Stage cSStage;
    public Image imgUIBase;

    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        int index = GetButton(eventData);
        cSStage.SetState(GameState.GameStart);
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        nowButton = GetButton(eventData);
        imgUIBase.color = new Color32(255, 191, 0, 255);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        imgUIBase.color = new Color32(255, 255, 255, 255);
    }
}
