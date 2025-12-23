using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILED : MonoBehaviour
{
    public float moveTime;        //移動時間
    public float startPos, endPos;//開始・終了位置
    public string[] str;

    private float timer;
    private Coroutine loopCoroutine;
    private Image image;
    private TMP_Text text;
    private RectTransform rectTrans;

    private void Start()
    {
        TryGetComponent<Image>(out image);
        TryGetComponent<TMP_Text>(out text);
        rectTrans = this.GetComponent<RectTransform>();
        loopCoroutine = StartCoroutine(IELoop());
    }

    public void SetLED(int num)
    {
        if (str != null) text.text = "【現在の設定：" + str[num].ToString() + "】<space=50>" + str[num].ToString() + "の設定を確認・変更できます。";

        if (loopCoroutine != null)
        {
            StopCoroutine(loopCoroutine);
            loopCoroutine = null;
        }

        ResetLED();
        loopCoroutine = StartCoroutine(IELoop());
    }

    void ResetLED()
    {
        timer = 0f;
        rectTrans.anchoredPosition =
            new Vector2(startPos, rectTrans.anchoredPosition.y);
    }

    IEnumerator IELoop()
    {
        if (moveTime <= 0f) yield break;

        while (true)
        {
            timer += Time.deltaTime;
            float nowTimer = timer / moveTime;

            float nowPos = Mathf.Lerp(startPos, endPos, nowTimer);
            rectTrans.anchoredPosition =
                new Vector2(nowPos, rectTrans.anchoredPosition.y);

            if (nowTimer >= 1f) ResetLED();
            yield return null;
        }
    }
}
