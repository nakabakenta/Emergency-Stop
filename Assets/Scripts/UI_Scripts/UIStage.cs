using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class UIStage : MonoBehaviour
{
    public TMP_Text textTimer;   //�^�C�}�[�e�L�X�g
    public TMP_Text textObject;  //�I�u�W�F�N�g�e�L�X�g
    public TMP_Text textSpeed;   //���x�e�L�X�g
    public TMP_Text textDistance;//�����e�L�X�g

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
