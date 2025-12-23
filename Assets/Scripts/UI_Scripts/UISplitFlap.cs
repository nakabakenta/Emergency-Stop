using System.Collections;
using TMPro;
using UnityEngine;

public class UISplitFlap : MonoBehaviour
{
    public float splitFlapDur;
    public string[] str;
    public TMP_Text[] textF, textB;
    public RectTransform[] rectTrans;
    private float[] maxRotate
        = new float[2] { -180, 180 };
    private bool isSplitFlap = false;

    public IEnumerator SplitFlap(int num, string argStr)
    {
        if(!isSplitFlap)
        {
            isSplitFlap = true;

            for (int index = 0; index < textB.Length; index++)
            {
                if (textB[index].name.Contains("En")) textB[index].text = argStr;
                else textB[index].text = str[num];
            }

            float elapsed = 0f;

            Vector3[] startRotate = new Vector3[maxRotate.Length];
            float[] startX = new float[maxRotate.Length];
            float[] targetX = new float[maxRotate.Length];

            for (int i = 0; i < maxRotate.Length; i++)
            {
                startRotate[i] = rectTrans[i].localEulerAngles;
                startX[i] = startRotate[i].x > 180 ? startRotate[i].x - 360 : startRotate[i].x;
                targetX[i] = startX[i] + maxRotate[i];
            }

            while (elapsed < splitFlapDur)
            {
                elapsed += Time.deltaTime;
                float timer = Mathf.Clamp01(elapsed / splitFlapDur);

                for (int i = 0; i < maxRotate.Length; i++)
                {
                    float now = Mathf.Lerp(startX[i], targetX[i], timer);
                    rectTrans[i].localEulerAngles =
                        new Vector3(now, startRotate[i].y, startRotate[i].z);

                    if (i == 0 && now <= -90f)
                        rectTrans[0].gameObject.SetActive(false);
                    if (i == 1 && now >= 180f)
                        rectTrans[3].gameObject.SetActive(false);
                }

                yield return null;
            }

            for (int i = 0; i < textF.Length; i++)
                textF[i].text = textB[i].text;

            for (int i = 0; i < rectTrans.Length; i++)
                rectTrans[i].gameObject.SetActive(true);

            for (int i = 0; i < maxRotate.Length; i++)
                rectTrans[i].localEulerAngles = startRotate[i];

            isSplitFlap = false;
        }
    }
}
