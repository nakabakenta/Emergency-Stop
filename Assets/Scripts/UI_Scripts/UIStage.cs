using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class UIStage : MonoBehaviour
{
    public TMP_Text timerText;//ボタンテキスト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float seconds = Stage.waitTimer % 60f;
        timerText.text = $"{seconds:00.00}";
    }
}
