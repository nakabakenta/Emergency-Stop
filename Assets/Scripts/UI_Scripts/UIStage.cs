using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIStage : MonoBehaviour
{
    public GameObject objUIGameDesc, objUIGamePrep;//UI�I�u�W�F�N�g
    public TMP_Text textTimer;     //�^�C�}�[�e�L�X�g
    public TMP_Text textObject;    //�I�u�W�F�N�g�e�L�X�g
    public TMP_Text textSpeed;     //���x�e�L�X�g
    public TMP_Text textDistance;  //�����e�L�X�g
    public TMP_Text textGameStatus;//
    public static UIStage uIStage;
    //����
    private string[] desc
        = { "��Ԃ��~�߂�",
            "�n�C�X�R�A��ڎw��",
            "��ƈ������",
            "��Ԃ��~�߂�" };
    //�N���A����
    private string[] clearCond
        = { "�E���x��0km�ɂ���\n�E0m�܂łɒ�~������",
            "�E�Ƃɂ����X�R�A���グ��",
            "�E��ƈ������",
            "�E���x��0km�ɂ���\n�E0m�܂łɒ�~������" };

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
