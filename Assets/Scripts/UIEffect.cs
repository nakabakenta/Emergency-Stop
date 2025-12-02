using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEffect : MonoBehaviour
{
    public bool useFade;
    public bool useMove;

    //UIフェード構造体
    [System.Serializable]
    public struct UIFade
    {
        public bool loop;         //ループ
        public float fadeInterval;//フェードの間隔
        public float waitInterval;//
    }

    //UI移動構造体
    [System.Serializable]
    public struct UIMove
    {
        public float moveSpeed;       //移動速度
        public float startPos, endPos;//開始・終了位置
    }

    private bool isFade = true, actFade, isWait = false; //フェードフラグ
    private float startAlpha = 1f, endAlpha = 0f;        //フェード開始時の透明度
    private float fadeTimer = 0f;                        //フェードのタイマー

    public UIFade uIFade;//UIフェード構造体
    public UIMove uIMove;//UI移動構造体

    private Image image;
    private TMP_Text text;//テキスト
    private RectTransform thisTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryGetComponent<Image>(out image);
        TryGetComponent<TMP_Text>(out text);
        TryGetComponent<RectTransform>(out thisTransform);
        actFade = useFade;
    }

    // Update is called once per frame
    void Update()
    {
        if (useFade && actFade) Fade();     //フェード
        if (useMove) Move(uIMove.moveSpeed);//移動
    }

    void Fade()
    {
        //フェードを進める
        fadeTimer += Time.deltaTime;

        if (isWait)
        {
            if (fadeTimer >= uIFade.waitInterval)
            {
                fadeTimer = 0f;
                isWait = false;
            }
        }
        else
        {
            //現在の透明度を計算
            float alpha = Mathf.Lerp(startAlpha, endAlpha, fadeTimer / uIFade.fadeInterval);

            if (TryGetComponent<Image>(out image)) image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);//透明度を設定
            if (TryGetComponent<TMP_Text>(out text)) text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);  //透明度を設定

            // フェードが終わったら、次のフェードに切り替える
            if (fadeTimer >= uIFade.fadeInterval)
            {
                fadeTimer = 0f;// タイマーをリセット
                               // フェードイン・フェードアウトを切り替える
                isFade = !isFade;
                startAlpha = endAlpha;
                endAlpha = isFade ? 0f : 1f;         //目標透明度を切り替え

                //
                if (endAlpha == 0) actFade = uIFade.loop ? true : false;
                if (uIFade.waitInterval > 0) isWait = true;
            }
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
