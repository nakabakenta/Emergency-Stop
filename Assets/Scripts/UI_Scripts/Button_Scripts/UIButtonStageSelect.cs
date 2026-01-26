using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonStageSelect : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float moveTime;
    public RectTransform rtStageSelect, rtHighlight;
    private Vector2 defPos;
    private Vector2 targetPos = new Vector2(-450, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        int index = GetButton(eventData);

        StopAllCoroutines();
        StartCoroutine(IEMove());
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        int index = GetButton(eventData);
        rtHighlight.anchoredPosition = Function.AlignRectTransform(rt[index], rtHighlight);
    }

    public IEnumerator IEMove()
    {
        defPos = rtStageSelect.anchoredPosition;
        Vector2 startPos = defPos;
        float timer = 0f;

        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            float rate = timer / moveTime;

            rtStageSelect.anchoredPosition = Vector2.Lerp(startPos, targetPos, rate);
            yield return null;
        }

        rtStageSelect.anchoredPosition = targetPos;
    }
}
