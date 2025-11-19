using UnityEngine;

public class Stage : MonoBehaviour
{
    public static int putNum;      //設置数
    public static int status;      //状態
    private float waitTimer;       //待機タイマー
    public Transform train, target;
    private Vector3 startVec;      //

    //待機時間(難易度)
    private float[] waitTime
        = { 30, 20, 15 };//ノーマル, ハード, エキスパート

    private void Awake()
    {
        //デバック用
        GameBase.gameMode = 0;
        GameBase.gameLevel = 0;
        GameBase.stage = 0;

        putNum = 0;
        status = (int)GameStatus.GameStart;
        waitTimer = waitTime[GameBase.gameLevel];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startVec = target.position - train.position;
        SetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if(status == (int)GameStatus.GameStart)
        {

        }
        else if (status == (int)GameStatus.GamePrep)
        {
            SetTimer();
        }
        else if(status == (int)GameStatus.GameDep)
        {
            SetDistance();
        }
        else
        {
            GameStatus gameStatus = (GameStatus)status;
            UIStage.uIStage.SetGameStatus(gameStatus.ToString());
        }

        UIStage.uIStage.SetUI(status);
    }

    void SetTimer()
    {
        if (waitTimer <= 0.0f)
        {
            waitTimer = 0.0f;
            status++;
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }

        UIStage.uIStage.SetTextTimer(waitTimer);
    }

    void SetDistance()
    {
        Vector3 targetVec = target.position - train.position;

        if (Vector3.Dot(startVec, targetVec) <= 0.0f)
        {
            status = (int)GameStatus.GameOver;
        }
        else
        {
            UIStage.uIStage.SetTextDistance(Vector3.Distance(train.position, target.position));
        }
    }
}
