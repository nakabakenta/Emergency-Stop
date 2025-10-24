using UnityEngine;

public class Stage : MonoBehaviour
{
    public int maxPutNumber;       //最大設置数
    public static int nowPutNumber;//現在の設置数
    public float waitTime;         //待機時間
    private float waitTimer;       //待機タイマー
    public static string status;   //状態

    private UIStage uIStage;

    public Transform trainFormation;
    public Transform endPosition;

    private void Awake()
    {
        waitTimer = waitTime;
        nowPutNumber = maxPutNumber;

        uIStage = this.GetComponent<UIStage>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer != 0.0f)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0.0f)
            {
                waitTimer = 0.0f;
            }

            uIStage.SetTextTimer(waitTimer);
        }

        float distance = Vector3.Distance(trainFormation.position, endPosition.position);
        uIStage.SetTextDistance(distance);
    }
}
