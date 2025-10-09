using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIEffect : MonoBehaviour
{
    public TextMeshProUGUI text;  //フェードさせるテキスト
    public float fadeInterval;    //フェードの周期(秒)
    private bool isFade = true;   //フェードフラグ
    private float startAlpha = 1f;//フェード開始時の透明度
    private float endAlpha = 0f;  //目標透明度
    private float fadeTimer = 0f; //フェードのタイマー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //フェードを進める
        fadeTimer += Time.deltaTime;

        //現在の透明度を計算
        float alpha = Mathf.Lerp(startAlpha, endAlpha, fadeTimer / fadeInterval);
        //透明度を設定
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        // フェードが終わったら、次のフェードに切り替える
        if (fadeTimer >= fadeInterval)
        {
            fadeTimer = 0f;// タイマーをリセット
            // フェードイン・フェードアウトを切り替える
            isFade = !isFade;
            startAlpha = endAlpha;
            endAlpha = isFade ? 0f : 1f;//目標透明度を切り替え
        }
    }
}
