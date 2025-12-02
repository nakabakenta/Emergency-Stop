using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    public float fadeInterval;
    public float waitInterval;
    public Image blackout;
    public GameObject[] objUI;

    private readonly int[] fadeCount = { 2, 1 };

    private enum TitleState { Warning, Title }
    private TitleState state = TitleState.Warning;

    void Start()
    {
        StartCoroutine(State());
    }

    void Update()
    {
        // タイトル状態ならキー押下で遷移
        if (state == TitleState.Title && Input.anyKeyDown) SceneLoader.LoadScene(SceneName.Menu.ToString());
    }

    IEnumerator State()
    {
        // Warning フェード
        yield return StartCoroutine(FadeLoop(fadeCount[(int)state]));

        // ★ Title フェードをここで開始
        //yield return StartCoroutine(FadeLoop(fadeCount[(int)state]));
    }

    IEnumerator FadeLoop(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // ★ 最後のフェードが始まる直前に SetActive を切り替える
            if (state == TitleState.Warning && i == count - 1)
            {
                // 状態変更
                state = TitleState.Title;

                // Title UI を表示し Warning UI を非表示
                for (int index = 0; index < objUI.Length; index++)
                {
                    objUI[index].SetActive(index == (int)state);
                }
            }

            // フェードアウト
            yield return Fade(1f, 0f, fadeInterval);
            yield return new WaitForSeconds(waitInterval);

            // 最後のフェードならここで終了（フェードイン不要）
            if (i == count - 1) break;

            // フェードイン
            yield return Fade(0f, 1f, fadeInterval);
            yield return new WaitForSeconds(waitInterval);
        }
    }

    IEnumerator Fade(float from, float to, float duration)
    {
        float timer = 0f;
        Color c = blackout.color;

        while (timer < duration)
        {
            float t = timer / duration;
            c.a = Mathf.Lerp(from, to, t);
            blackout.color = c;

            timer += Time.deltaTime;
            yield return null;
        }

        // 最終値補正
        c.a = to;
        blackout.color = c;
    }
}
