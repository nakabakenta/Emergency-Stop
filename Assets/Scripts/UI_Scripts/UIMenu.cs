using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour
{
    public GameObject[] objUI;          //UI�I�u�W�F�N�g
    public GameObject objBackGround;    //�w�i�I�u�W�F�N�g
    public GameObject objUIButtonReturn;
    public TMP_Text buttonText;         //�{�^���e�L�X�g
    public static int nowStatus;        //���݂̏��
    private string[] description        //����
        = { "�v���C����Q�[�����[�h��I�����܂�", "�Q�[�����Ŏg�p�������f�����{���ł��܂�", "�Q�[���̃I�v�V�������m�F�ł��܂�", "�^�C�g���ɖ߂�܂�"};

    //����ꂽ���̃I�u�W�F�N�g��z�u���ēd�Ԃ��Ԃ����郂�[�h
    //�^�C�g���ɖ߂�܂����H

    //UI���ꗗ
    public enum UIName
    {
        Menu,
        GameMode,
        Option,
        BackToTtle
    }

    private void Awake()
    {
        GameBase.nowScene = "Menu";//�f�o�b�N�p
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowStatus = (int)UIName.Menu;
    }

    public void SetMenu()
    {
        if (nowStatus == (int)UIName.Menu)
        {
            objUI[(int)UIName.Menu].SetActive(true);
            objUI[(int)UIName.GameMode].SetActive(false);
            objUI[(int)UIName.BackToTtle].SetActive(false);
            objBackGround.SetActive(false);
            objUIButtonReturn.SetActive(false);
        }
        else if (nowStatus == (int)UIName.GameMode)
        {
            objUI[(int)UIName.Menu].SetActive(false);
            objUI[(int)UIName.GameMode].SetActive(true);
            objUIButtonReturn.SetActive(true);
        }
        else if(nowStatus == (int)UIName.BackToTtle)
        {
            objUI[(int)UIName.BackToTtle].SetActive(true);
            objBackGround.SetActive(true);
        }
    }

    public void SetText(int number)
    {
        buttonText.text = description[number];
    }
}
