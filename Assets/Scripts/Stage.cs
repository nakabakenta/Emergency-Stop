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
        status = null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if(status == null)
        {
            SetTimer();
        }
        else if(status == GameStatus.GameStart.ToString())
        {
            SetDistance();
        }
        else
        {
            UIStage.uIStage.SetGameStatus(status);
        }
    }

    void SetTimer()
    {
        if (waitTimer <= 0.0f)
        {
            status = GameStatus.GameStart.ToString();
            waitTimer = 0.0f;
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }

        UIStage.uIStage.SetTextTimer(waitTimer);
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
