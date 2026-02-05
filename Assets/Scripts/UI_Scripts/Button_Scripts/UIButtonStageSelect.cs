using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonStageSelect : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objHighlight;
    public TMP_Text textLED;
    public UIStageSelect uIStageSelect;
    private RectTransform rtHighlight;
    private Image imgHighlight;

    public float clickTime;
    private bool isProcess = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        rtHighlight = objHighlight.GetComponent<RectTransform>();
        imgHighlight = objHighlight.GetComponent<Image>();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        StartCoroutine(IEInputButtonLeft(eventData));
    }

    private IEnumerator IEInputButtonLeft(PointerEventData eventData)
    {
        if (isProcess) yield break;

        int index = GetButton(eventData);
        if (PlayerPrefs.GetInt($"Stage{index + 1}") == 0) yield break;

        isProcess = true;

        uIStageSelect.SetStageInfo(index);
        yield return StartCoroutine(InstChangeColor(imgHighlight, new Color32(255, 191, 0, 255)));

        PointerEventData pointer = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        index = GetButtonUnderMouse();

        if (index == other)
        {
            isProcess = false;
            yield break;
        }
             
        rtHighlight.anchoredPosition = Function.AlignRectTransform(rtButton[index], rtHighlight);
        isProcess = false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (isProcess) return;

        int index = GetButton(eventData);
        rtHighlight.anchoredPosition = Function.AlignRectTransform(rtButton[index], rtHighlight);
    }

    IEnumerator InstChangeColor(Image image, Color32 color)
    {
        Color32 orig = image.color;
        image.color = color;
        yield return new WaitForSeconds(clickTime);
        image.color = orig;
    }

    private int GetButtonUnderMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results); // ƒ}ƒEƒX‰º‚ÌUI‚ð‚·‚×‚ÄŽæ“¾

        foreach (RaycastResult result in results)
        {
            for (int index = 0; index < objButton.Length; index++)
            {
                if (result.gameObject.transform.IsChildOf(objButton[index].transform))
                    return index;
            }
        }

        return other; // Œ©‚Â‚©‚ç‚È‚¯‚ê‚Î -1
    }
}
