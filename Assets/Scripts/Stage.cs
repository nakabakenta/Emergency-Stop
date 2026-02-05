using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

public class Stage : MonoBehaviour
{
    private int putNum;            //設置数
    private float timer;           //タイマー
    public Transform train, target;
    private Vector3 startVec;      //
    private UIStage uIStage;       //

    //準備時間(難易度)
    private float[] depTime
        = { 20, 15};//ノーマル, ハード

    private bool isGamePrepRunning = false;
    private bool isTimerRunning = false;
    public RectTransform rtTimer;

    public float rtFlashTime;
    public float rtMoveTime;

    public enum GameState { GamePrep, GameStart, GameDep, GameMenu, GameClear, GameOver };
    private GameState gameState = GameState.GamePrep;                         //状態

    public PlayerController cSPlayerController;
    public TrainFormation[] cSTrainFormation;

    private void Awake()
    {
        putNum = 0;
        Stage cSStage = this.GetComponent<Stage>();

        uIStage = this.GetComponent<UIStage>();
        timer = depTime[GameBase.gameLevel];

        uIStage.SetStartUI((int)gameState, GameBase.gameMode, cSStage);
        cSPlayerController.SetStage(cSStage);
        for (int index = 0; index < cSTrainFormation.Length; index++)
            cSTrainFormation[index].SetStage(cSStage);
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
        switch (gameState)
        {
            case GameState.GamePrep:
                // GamePrep状態では演出を開始
                if (!isGamePrepRunning)
                {
                    StartCoroutine(GamePrepSequence());
                }
                break;
            case GameState.GameStart:
                // タイマーが動く状態のみ SetTimer
                if (isTimerRunning)
                {
                    SetTimer();
                }
                break;
            case GameState.GameDep:
                SetDistance();
                break;
        }
    }

    void SetTimer()
    {
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            SetState(GameState.GameDep);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        uIStage.SetTextTimer(timer);
    }

    void SetDistance()
    {
        Vector3 targetVec = target.position - train.position;

        if (Vector3.Dot(startVec, targetVec) <= 0.0f) SetState(GameState.GameOver);
        else
        {
            uIStage.SetTextDistance(Vector3.Distance(train.position, target.position));
        }
    }

    public IEnumerator MoveAndScaleCoroutine(Vector2 targetPos, Vector2 targetScale, float duration)
    {
        Vector2 startPos = rtTimer.anchoredPosition;
        Vector3 startScale = rtTimer.localScale;
        Vector3 endScale = new Vector3(targetScale.x, targetScale.y, 1f);

        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            t = Mathf.SmoothStep(0f, 1f, t);

            rtTimer.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            rtTimer.localScale = Vector3.Lerp(startScale, endScale, t);

            time += Time.deltaTime;
            yield return null;
        }

        // 誤差防止
        rtTimer.anchoredPosition = targetPos;
        rtTimer.localScale = endScale;
    }

    private IEnumerator GamePrepSequence()
    {
        isGamePrepRunning = true;

        // 移動前にタイマー初期値を表示
        uIStage.SetTextTimer(timer);

        isTimerRunning = false;

        // UI移動開始
        yield return StartCoroutine(
            MoveAndScaleCoroutine(
                new Vector2(-700f, 400f),
                new Vector2(1f, 1f), 2f
            )
        );

        // 移動完了！タイマー開始
        isTimerRunning = true;

        isGamePrepRunning = false;
    }

    public void SetState(GameState state)
    {
        gameState = state;
        uIStage.SetGameStateUI((int)gameState);

        if (gameState >= GameState.GameStart && gameState <= GameState.GameMenu)
        {
            
        }
        else if(gameState == GameState.GameClear || gameState == GameState.GameOver)
        {
            uIStage.SetGameStateUI((int)gameState - 4);
        }
    }

    public GameState GetState()
    {
        return gameState;
    }

    public void ObjPut()
    {
        putNum++;
        uIStage.SetTextObject(putNum);
    }

    public bool SetTrainSpeed(float moveSpeed, bool isMaxSpeed)
    {
        uIStage.SetTextSpeed(Function.SetSpeed(moveSpeed));

        if(moveSpeed <= 0.0f && isMaxSpeed) 
        {
            SetState(GameState.GameClear);

            return true;
        }

        return false;
    }
}
