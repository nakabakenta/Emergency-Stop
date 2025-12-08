using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class UITitle : MonoBehaviour
{
    public float fadeTime, blankTime;
    public float[] waitTime;
    public Image blackout;
    public GameObject[] objUI;
    private float timer;
    private bool isFade = false;

    private enum TitleState { Warning, Title, LoadScene }
    private TitleState state = TitleState.Warning;

    void Start()
    {
        StartCoroutine(FadeLoop());
    }

    void Update()
    {
        //timer += Time.deltaTime;

        //if (Function.Timer(timer, waitTime[(int)state]))
        //{
        //    timer = 0;
        //}

        switch (state)
        {
            case TitleState.Warning:

                break;
            case TitleState.Title:
                if (Input.anyKeyDown)
                {
                    state = TitleState.LoadScene;
                    SceneLoader.LoadScene(SceneName.Menu.ToString());
                }

                if (!isFade) StartCoroutine(FadeLoop());

                break;
            case TitleState.LoadScene:

                break;
        }
    }

    IEnumerator FadeLoop()
    {
        isFade = true;

        switch (state)
        {
            case TitleState.Warning:
                yield return StateWarning();
                break;
            case TitleState.Title:
                yield return StateTitle();
                break;
        }

        isFade = false;
    }

    IEnumerator StateWarning()
    {
        yield return Fade(1f, 0f);
        yield return new WaitForSeconds(waitTime[(int)TitleState.Warning]);
        yield return Fade(0f, 1f);
        SetActiveUI(TitleState.Title);
        yield return new WaitForSeconds(blankTime);
        yield return Fade(1f, 0f);
        state = TitleState.Title;
    }

    IEnumerator StateTitle()
    {
        yield return new WaitForSeconds(waitTime[(int)TitleState.Title]);
        state = TitleState.LoadScene;
        yield return Fade(0f, 1f);
        SceneLoader.LoadScene(SceneName.Title.ToString());
    }
    
    void SetActiveUI(TitleState s)
    {
        for (int i = 0; i < objUI.Length; i++)
            objUI[i].SetActive(i == (int)s);
    }

    IEnumerator Fade(float start, float end)
    {
        float timer = 0f;
        Color c = blackout.color;

        while (timer < fadeTime)
        {
            float t = timer / fadeTime;
            c.a = Mathf.Lerp(start, end, t);
            blackout.color = c;

            timer += Time.deltaTime;
            yield return null;
        }

        c.a = end;
        blackout.color = c;
    }
}