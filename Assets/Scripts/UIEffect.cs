using TMPro;
using UnityEngine;

public class UIEffect : MonoBehaviour
{
    public bool useFade;
    public bool useMove;

    //UIフェード構造体
    [System.Serializable]
    public struct UIFade
    {
        public float interval;//フェードの周期(秒)
    }

    //UI移動構造体
    [System.Serializable]
    public struct UIMove
    {
        public float moveSpeed;       //移動速度
        public float startPos, endPos;//開始・終了位置
    }

    private bool isFade = true;   //フェードフラグ
    private float startAlpha = 1f;//フェード開始時の透明度
    private float endAlpha = 0f;  //目標透明度
    private float fadeTimer = 0f; //フェードのタイマー

    public UIFade uIFade;//UIフェード構造体
    public UIMove uIMove;//UI移動構造体

    private TMP_Text text;//テキスト
    private RectTransform thisTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetComponent<TMP_Text>(out text);
        TryGetComponent<RectTransform>(out thisTransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (useFade) Fade();                //フェード
        if (useMove) Move(uIMove.moveSpeed);//移動
    }

    void Fade()
    {
        //フェードを進める
        fadeTimer += Time.deltaTime;

        //現在の透明度を計算
        float alpha = Mathf.Lerp(startAlpha, endAlpha, fadeTimer / uIFade.interval);
        //透明度を設定
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        // フェードが終わったら、次のフェードに切り替える
        if (fadeTimer >= uIFade.interval)
        {
            fadeTimer = 0f;// タイマーをリセット
            // フェードイン・フェードアウトを切り替える
            isFade = !isFade;
            startAlpha = endAlpha;
            endAlpha = isFade ? 0f : 1f;//目標透明度を切り替え
        }
    }

    void Move(float speed)
    {
        if (uIMove.startPos >= 0) speed *= -1;

        thisTransform.anchoredPosition = new Vector2(thisTransform.anchoredPosition.x + speed * Time.deltaTime, thisTransform.anchoredPosition.y);

        if ((uIMove.startPos >= 0 && thisTransform.anchoredPosition.x <= uIMove.endPos) || 
            (uIMove.startPos <= 0 && thisTransform.anchoredPosition.x >= uIMove.endPos))
            thisTransform.anchoredPosition = new Vector2(uIMove.startPos, thisTransform.anchoredPosition.y);
    }
}
