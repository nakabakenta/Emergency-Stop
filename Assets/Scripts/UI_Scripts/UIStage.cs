using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class UIStage : MonoBehaviour
{
    public TMP_Text textTimer;   //タイマーテキスト
    public TMP_Text textObject;  //オブジェクトテキスト
    public TMP_Text textSpeed;   //速度テキスト
    public TMP_Text textDistance;//距離テキスト

    private void Awake()
    {
        SetTextObject();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void SetTextTimer(float timer)
    {
        float seconds = timer % 60f;
        textTimer.text = $"{timer:00.00}";
    }

    public void SetTextObject()
    {
        textObject.text = Stage.nowPutNumber.ToString();
    }

    public void SetTextDistance(float distance)
    {
        textDistance.text = $"{distance:F0} m";
    }
}
