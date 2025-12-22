using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UITitle : MonoBehaviour
{
    public float fadeTime, blankTime;
    public float[] waitTime;
    public Image blackout;
    public GameObject[] objUI;
    public TMP_Text[] fadeText;

    public float fadeInterval;                              //フェードの間隔
    private float fadeTimer, startAlpha = 1f, endAlpha = 0f;//フェード開始時の透明度
    private bool isFade = true, input = false;

    private enum TitleState { Warning, Title, LoadScene }
    private TitleState state = TitleState.Warning;

    void Start() => StartCoroutine(Title());
    
    void Update()
    {
        if (state != TitleState.Title) return;

        fadeTimer += Time.deltaTime;

        foreach (var text in fadeText)
            UIEffect.AAA(text, startAlpha, endAlpha, fadeTimer, fadeInterval);

        if(!input)
        {
            if (Function.Timer(fadeTimer, fadeInterval))
            {
                fadeTimer = 0f;             //タイマーをリセット      
                isFade = !isFade;           //フェードイン・フェードアウトを切り替える
                startAlpha = endAlpha;
                endAlpha = isFade ? 0f : 1f;//目標透明度を切り替え
            }

            if (Input.anyKeyDown)
            {
                fadeTimer = 0f;
                isFade = false;
                input = true;

                foreach (var text in fadeText)
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
            }
        }
        else
        {



            SceneLoader.LoadScene(SceneName.Menu.ToString());
        } 
    }

    IEnumerator Title()
    {
        yield return UIEffect.BBB(blackout, 1f, 0f, fadeTime);
        yield return new WaitForSeconds(waitTime[(int)TitleState.Warning]);
        yield return UIEffect.BBB(blackout, 0f, 1f, fadeTime);
        SetActiveUI(TitleState.Title);
        yield return new WaitForSeconds(blankTime);
        yield return UIEffect.BBB(blackout, 1f, 0f, fadeTime);
        state = TitleState.Title;
        yield return new WaitForSeconds(waitTime[(int)TitleState.Title]);

        if(input)
        {
            state = TitleState.LoadScene;
            yield return UIEffect.BBB(blackout, 0f, 1f, fadeTime);
            SceneLoader.LoadScene(SceneName.Title.ToString());
        }
    }
    
    void SetActiveUI(TitleState s)
    {
        for (int i = 0; i < objUI.Length; i++)
            objUI[i].SetActive(i == (int)s);
    }
}