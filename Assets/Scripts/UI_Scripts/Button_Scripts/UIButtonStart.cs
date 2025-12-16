using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonStart : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image[] imgSignal;     //
    public Color32 blank;         //空白色
    private Color32[] colorSignal;//

    private void Awake()
    {
        colorSignal = new Color32[imgSignal.Length];

        for (int index = 0; index < imgSignal.Length; index++)
        {
            colorSignal[index] = imgSignal[index].color;

            if(index == 1)
            {
                imgSignal[index - 1].color = Function.SetColor(blank);
            }
        }
    }

    //マウスが重なった場合
    public override void OnPointerEnter(PointerEventData eventData)
    {
        SetButton(1.25f);
    }

    //マウスが離れた場合
    public override void OnPointerExit(PointerEventData eventData)
    {
        SetButton(1.0f);
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        Stage.status++;
    }

    void SetButton(float value)
    {
        RectTransform thisTransform = this.GetComponent<RectTransform>();
        Image alpha = this.transform.Find("UI_Alpha").GetComponent<Image>();

        thisTransform.localScale = Function.SetVector3(value);
        alpha.enabled = !alpha.enabled;

        if(!alpha.enabled)
        {
            imgSignal[0].color = colorSignal[0];
            imgSignal[1].color = Function.SetColor(blank);
        }
        else
        {
            imgSignal[0].color = Function.SetColor(blank);
            imgSignal[1].color = colorSignal[1];
        }
    }
}
