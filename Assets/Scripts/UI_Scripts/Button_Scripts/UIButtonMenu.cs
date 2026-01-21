using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public float scaleTime, scrollTime;
    public Image imgBaseColor;
    public GameObject objBackGround;

    private int nowCursor = other; //現在のカーソル
    private bool isScroll = false; //スクロール中かどうか
    private Coroutine nowCoroutine;

    private Color32[] colorBase
       = { new Color32(255, 0, 0, 255), new Color32(0, 191, 0, 255), new Color32(0, 128, 255, 255), new Color32(76, 76, 76, 255) };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if(!objBackGround.activeSelf)
        {
            float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
            Scroll(scroll);
        }
    }

    public override void InputButtonLeft(PointerEventData eventData)
    {
        if (!isScroll && CheckButton(nowButton, eventData)) UIMenu.uIMenu.SetMenu(nowButton);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (isScroll) return;//スクロール中は無視

        int index = GetButton(eventData);
        if (index != nowButton) return;  //nowButton以外にマウスが乗っても無視

        nowCursor = nowButton;//現在のカーソルを現在のボタンに設定

        if (nowCoroutine != null) StopCoroutine(nowCoroutine);//既存コルーチンがあれば停止

        // PingPong アニメーション開始
        nowCoroutine = StartCoroutine(PingPong(nowButton));
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        int index = GetButton(eventData);

        if (nowCursor == nowButton) ResetButton();//nowButtonから出た場合のみリセット
    }

    private bool CheckButton(int index, PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null) return false;
        return eventData.pointerCurrentRaycast.gameObject.transform.IsChildOf(objButton[index].transform);
    }

    private void ResetButton()
    {
        if (nowCoroutine != null)
        {
            StopCoroutine(nowCoroutine);
            nowCoroutine = null;
        }

        if (nowCursor != other)
        {
            rt[nowCursor].localScale = Vector3.one;//サイズを元に戻す
            nowCursor = other;
        }
    }

    //スクロール操作が行われた場合
    void Scroll(float scroll)
    {
        if (scroll == 0 || isScroll) return;

        int vertical = (scroll > 0) ? -1 : 1;

        if ((nowButton == 0 && vertical == -1) || (nowButton == objButton.Length - 1 && vertical == 1)) return;//上下端チェック

        ResetButton();//前のボタンのアニメーションを止めてリセット
        StartCoroutine(IEScroll(vertical));
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
            timer += Time.deltaTime / scrollTime;
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

        if (IsPointerOverButton(nowButton))//ここで「マウスが nowButton に重なっているか」をチェック
        {
            nowCursor = nowButton;
            nowCoroutine = StartCoroutine(PingPong(nowButton));
        }
    }

    private bool IsPointerOverButton(int index)
    {
        if (!EventSystem.current.IsPointerOverGameObject()) return false;
        
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        var results = new System.Collections.Generic.List<RaycastResult>();//画面上のオブジェクトを raycast
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var result in results)
            if (result.gameObject.transform.IsChildOf(objButton[index].transform)) return true;

        return false;
    }

    IEnumerator PingPong(int index)
    {
        Vector3 small = Function.SetVector3(0.875f);
        Vector3 big = Vector3.one;

        while (true)
        {
            yield return IEScale(index, big, small);//縮小
            yield return IEScale(index, small, big);//拡大 
        }
    }

    IEnumerator IEScale(int index, Vector3 start, Vector3 end)
    {
        float time = 0f;

        while (time < scaleTime)
        {
            time += Time.deltaTime;
            float t = time / scaleTime;

            t = t * t * (3f - 2f * t);// SmoothStep（自然な加速減速）

            rt[index].localScale = Vector3.Lerp(start, end, t);
            yield return null;
        }

        rt[index].localScale = end;
    }
}
