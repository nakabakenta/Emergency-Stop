using TMPro;
using UnityEngine;

public class UIStage : MonoBehaviour
{
    public GameObject[] objUI;       //UIオブジェクト
    public GameObject objUIClearCond;//UIクリア条件オブジェクト
    public TMP_Text textTimer;       //タイマーテキスト
    public TMP_Text textObject;      //オブジェクトテキスト
    public TMP_Text textSpeed;       //速度テキスト
    public TMP_Text textDistance;    //距離テキスト
    public TMP_Text textGameStatus;  //
    public TMP_Text textPos;         //

    public static UIStage uIStage;

    //ゲームモード
    private string[,] gameMode
        = {{ "ノーマル", "スコア", "ディフェンス", "エンドレス" },
           { "Normal", "Score", "Defense", "Endless" }};

    //クリア条件
    private string[] clearCond
        = { "・速度を0kmにする\n・0mまでに停止させる",
            "・とにかくスコアを上げろ",
            "・作業員を守る",
            "・速度を0kmにする\n・0mまでに停止させる" };

    private void Awake()
    {
        uIStage = this.GetComponent<UIStage>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //修正予定
        Transform[] chilled = objUI[0].GetComponentsInChildren<Transform>();
        foreach (Transform transform in chilled)
        {
            if (transform.name == "TMP_GameMode_JP")
            {
                TMP_Text text = transform.GetComponent<TMP_Text>();
                text.text = gameMode[0, GameBase.gameMode];
            }
            if (transform.name == "TMP_GameMode_EN")
            {
                TMP_Text text = transform.GetComponent<TMP_Text>();
                text.text = gameMode[1, GameBase.gameMode];
                break;
            }
        }

        chilled = objUIClearCond.GetComponentsInChildren<Transform>();
        foreach (Transform transform in chilled)
        {
            if (transform.name == "TMP_ClearCond")
            {
                TMP_Text text = transform.GetComponent<TMP_Text>();
                text.text = clearCond[GameBase.gameMode];
                break;
            }
        }
    }

    public void SetTextTimer(float timer)
    {
        textTimer.text = $"{timer:00.00}";
    }

    public void SetTextObject(int num)
    {
        textObject.text = $"{num:000}";
    }

    public void SetTextSpeed(float speed)
    {
        textSpeed.text = $"{speed:000.0} km/h";
    }

    public void SetTextDistance(float distance)
    {
        textDistance.text = $"{distance:0000} m";
    }

    public void SetGameStatus(string text)
    {
        textGameStatus.text = text;
    }

    public void SetUI(int num)
    {
        for (int index = 0; index < objUI.Length; index++)
        {
            if(index == num)
            {
                objUI[index].SetActive(true);
            }
            else
            {
                objUI[index].SetActive(false);
            }
        }

        switch (num)
        {
            case (int)GameStatus.GamePrep:
                objUIClearCond.SetActive(false);
                break;
            case (int)GameStatus.GameClear:
            case (int)GameStatus.GameOver:
                break;
        }
    }

    public void SetPos(Vector3 pos)
    {
        textPos.text = $"{pos.x:0.00}\n{pos.y:0.00}\n{pos.z:0.00}";
    }
}
