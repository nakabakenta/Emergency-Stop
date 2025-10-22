using UnityEngine;

public class Stage : MonoBehaviour
{
    public float waitTime;        //待機時間
    public static float waitTimer;//待機タイマー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitTimer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer <= 0.0f)
        {
            waitTimer = 0.0f;
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }
    }
}
