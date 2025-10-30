using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class UIStage : MonoBehaviour
{
    public TMP_Text textDesc;     //説明テキスト
    public TMP_Text textTimer;    //タイマーテキスト
    public TMP_Text textObject;   //オブジェクトテキスト
    public TMP_Text textSpeed;    //速度テキスト
    public TMP_Text textDistance; //距離テキスト

    public TMP_Text textGameStatus;

    public static UIStage uIStage;

    private void Awake()
    {
        uIStage = this.GetComponent<UIStage>();
        SetTextObject(Stage.putNum);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void SetTextTimer(float timer)
    {
        textTimer.text = $"{timer:00.00}";
    }

    public void SetTextObject(int num)
    {
        textObject.text = num.ToString();
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
}
