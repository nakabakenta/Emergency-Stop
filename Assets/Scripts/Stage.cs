using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int maxPutNum;         //最大設置数
    public float waitTime;        //待機時間
    public static float waitTimer;//待機タイマー
    public static int nowPutNum;  //現在の設置数
    public static string status;  //状態

    public Transform trainForm;
    public Transform target;

    private Vector3 startVec;//

    private void Awake()
    {
        waitTimer = waitTime;
        nowPutNum = maxPutNum;
        startVec = target.position - trainForm.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer == 0.0f && (status != GameStatus.GameClear.ToString() || status != GameStatus.GameOver.ToString()))
        {
            SetDistance();
        }
        else
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0.0f)
            {
                waitTimer = 0.0f;
            }

            UIStage.uIStage.SetTextTimer(waitTimer);
        }

        if(status == GameStatus.GameClear.ToString() || status == GameStatus.GameOver.ToString())
        {
            UIStage.uIStage.SetGameStatus(status);
        }
    }

    void SetDistance()
    {
        Vector3 targetVec = target.position - trainForm.position;

        if (Vector3.Dot(startVec, targetVec) <= 0.0f)
        {
            status = GameStatus.GameOver.ToString();
        }
        else
        {
            UIStage.uIStage.SetTextDistance(Vector3.Distance(trainForm.position, target.position));
        }
    }
}
