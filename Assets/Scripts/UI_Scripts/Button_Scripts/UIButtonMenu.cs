using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public float scaleTime;
    public float changeTime;
    public Image imgBaseColor;
    private bool isScroll = false;
    private Color32[] colorBase
        = { new Color32(255, 0, 0, 255), new Color32(0, 191, 0, 255), new Color32(0, 128, 255, 255), new Color32(76, 76, 76, 255) };
    private Coroutine loopCoroutine;

    private enum Button { GameModeSelect, Museum, Option, BackToTtle }//ボタン一覧

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[nowButton].transform) && !isScroll) UIMenu.uIMenu.SetMenu(nowButton);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[nowButton].transform) && !isScroll)
        {
            StartCoroutine(PingPong());
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null || !isScroll) return;
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[nowButton].transform)) rt[nowButton].localScale = Vector3.one;
    }

    //スクロール操作が行われた場合
    public override void OnScroll(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[nowButton].transform) && !isScroll)
        {
            float scroll = eventData.scrollDelta.y;//スクロールの回転量

            if (scroll != 0)
            {
                //上にスクロールされた場合は-1、それ以外は1
                int vertical = (scroll > 0) ? -1 : 1;

                if ((nowButton == (int)Button.GameModeSelect && vertical == -1) ||
                    (nowButton == (int)Button.BackToTtle && vertical == 1))
                    return;

                StartCoroutine(IEScroll(vertical));
            }
        }
    }

    public IEnumerator IEScroll(int vertical)
    {
        isScroll = true;
        Function.FindAllChild(objButton[nowButton].transform, "UI_Alpha").SetActive(true);
        float timer = 0f;
        int count = objButton.Length;
        Vector2[] startPos = new Vector2[count], endPos = new Vector2[count];
        Color startColor = imgBaseColor.color, endColor = colorBase[nowButton + vertical];

        for (int index = 0; index < count; index++)
        {
            startPos[index] = rt[index].anchoredPosition;
            endPos[index] = startPos[index] + new Vector2(vertical * 100, vertical * 200);
            rt[index].localScale = Function.SetVector3(0.75f);
        }

        while (timer < 1f)
        {
            timer += Time.deltaTime / changeTime;
            float lerp = Mathf.Clamp01(timer);

            imgBaseColor.color = Color.Lerp(startColor, endColor, lerp);

            for (int index = 0; index < count; index++)
                rt[index].anchoredPosition = Vector2.Lerp(startPos[index], endPos[index], lerp);

            yield return null;
        }

        for (int index = 0; index < count; index++)
            rt[index].anchoredPosition = endPos[index];

        imgBaseColor.color = endColor;
        nowButton += vertical;
        rt[nowButton].localScale = Vector3.one;
        Function.FindAllChild(objButton[nowButton].transform, "UI_Alpha").SetActive(false);
        isScroll = false;
    }

    IEnumerator PingPong()
    {
        yield return ScaleTo(Function.SetVector3(0.75f), Vector3.one);
        yield return ScaleTo(Function.SetVector3(0.75f), Vector3.one);
    }

    IEnumerator ScaleTo(Vector3 from, Vector3 to)
    {
        float time = 0f;

        while (time < scaleTime)
        {
            time += Time.deltaTime;
            float t = time / scaleTime;

            // SmoothStep（自然な加速減速）
            t = t * t * (3f - 2f * t);

            rt[nowButton].localScale = Vector3.Lerp(from, to, t);
            yield return null;
        }

        rt[nowButton].localScale = to;
    }
}
