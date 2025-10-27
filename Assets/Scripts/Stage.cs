using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int maxPutNum;       //最大設置数
    public float waitTime;      //待機時間
    private float waitTimer;    //待機タイマー
    public static int nowPutNum;//現在の設置数
    public static bool dep;     //発車フラグ
    public static string status;//状態

    public Transform trainForm;
    public Transform target;

    private Vector3 startVec;//

    private void Awake()
    {
        waitTimer = waitTime;
        nowPutNum = maxPutNum;
        startVec = target.position - trainForm.position;
        dep = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if(dep)
        {
            SetDistance();
        }
        else
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0.0f)
            {
                waitTimer = 0.0f;
                dep = true;
            }

            UIStage.uIStage.SetTextTimer(waitTimer);
        }
    }

    void SetDistance()
    {
        Vector3 targetVec = target.position - trainForm.position;

        if (Vector3.Dot(startVec, targetVec) <= 0.0f)
        {
            status = StageStatus.GameOver.ToString();
        }
        else
        {
            UIStage.uIStage.SetTextDistance(Vector3.Distance(trainForm.position, target.position));
        }
    }
}
