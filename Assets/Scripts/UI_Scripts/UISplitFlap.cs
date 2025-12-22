using TMPro;
using UnityEngine;
using System.Collections;

public class UISplitFlap : MonoBehaviour
{
    public float splitFlapDur;
    public string[] str;
    public TMP_Text[] textF, textB;
    public RectTransform[] rectTrans;
    private float[] maxRotate
        = new float[2] { -180, 180 };
    private bool isSplitFlap = false;

    public IEnumerator SplitFlap(int num)
    {
        if(!isSplitFlap)
        {
            isSplitFlap = true;

            for (int i = 0; i < textB.Length; i++)
            {
                if (i > 2) textB[i].text = str[num].ToString();
                else textB[i].text = str[num].ToString();
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
                    float newX = Mathf.Lerp(startX[i], targetX[i], timer);
                    rectTrans[i].localEulerAngles =
                        new Vector3(newX, startRotate[i].y, startRotate[i].z);

                    if (i == 0 && newX <= -90f)
                        rectTrans[0].gameObject.SetActive(false);
                    if (i == 1 && newX >= 180f)
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
