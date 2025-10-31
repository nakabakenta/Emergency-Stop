using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIStage : MonoBehaviour
{
    public GameObject objUIGameDesc, objUIGamePrep;//UIオブジェクト
    public TMP_Text textTimer;     //タイマーテキスト
    public TMP_Text textObject;    //オブジェクトテキスト
    public TMP_Text textSpeed;     //速度テキスト
    public TMP_Text textDistance;  //距離テキスト
    public TMP_Text textGameStatus;//
    public static UIStage uIStage;
    //説明
    private string[] desc
        = { "列車を止めろ",
            "ハイスコアを目指せ",
            "作業員を守れ",
            "列車を止めろ" };
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
        
        SetTextObject(Stage.putNum);

        Transform[] chilled = objUIGameDesc.GetComponentsInChildren<Transform>();

        foreach (Transform transform in chilled)
        {
            if (transform.name == "TMP_Desc")
            {
                TMP_Text text = transform.GetComponent<TMP_Text>();
                text.text = desc[GameBase.gameMode];
            }
            else if(transform.name == "TMP_ClearCond")
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
        textObject.text = $"{num:00}";
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

    public void SetUIGamePrep()
    {
        objUIGameDesc.SetActive(false);
        objUIGamePrep.SetActive(true);
    }
}
