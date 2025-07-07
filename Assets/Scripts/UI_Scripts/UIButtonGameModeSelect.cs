using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIButtonGameModeSelect : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public static int nowButton;//���݂̃{�^��

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        List<GameObject> listObjButton = new List<GameObject>();//�{�^���I�u�W�F�N�g���X�g
        Transform transformChild
            = GameObject.Find("UI_" + GameBase.scene).transform.Find("UI_Button_" + GameBase.scene);

        //
        foreach (Transform transform in transformChild.transform)
        {
            bool exclude = false;//���O�t���O

            //���O���閼�O�����݂���ꍇ
            if (excludeName != null)
            {
                //���O���閼�O���܂܂�Ă��邩�`�F�b�N����
                foreach (string name in excludeName)
                {
                    ///���O���閼�O���܂܂�Ă���ꍇ
                    if (transform.name.Contains(name))
                    {
                        exclude = true;//���O����
                        break;
                    }
                }
            }

            //���O���Ă��Ȃ��ꍇ
            if (!exclude)
            {
                listObjButton.Add(transform.gameObject);//���X�g�ɃI�u�W�F�N�g������
            }
        }

        objButton = listObjButton.ToArray();//���X�g��z��ɕϊ����ăI�u�W�F�N�g�ɓ����
        nowButton = 0;

        SetScale(1.25f);
    }

    //�N���b�N���ꂽ�ꍇ
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {
            //�{�^���I�u�W�F�N�g��T��
            for (int i = 0; i < objButton.Length; i++)
            {
                //�����ꂽ�{�^���ƃ{�^���I�u�W�F�N�g�̖��O����v�����ꍇ
                if (gameObject.name == objButton[i].name)
                {
                    GameBase.gameMode = ((GameModeName)i).ToString();//�z��ԍ����Q�[�����[�h���ɕϊ�����
                    break;
                }
            }

            //if(GameBase.gameMode == GameModeName.Normal.ToString())
            //{
            //    SceneLoader.LoadScene(SceneName.StageSelect.ToString());
            //}

            SceneLoader.LoadScene(SceneName.StageSelect.ToString());
        }
    }

    //�}�E�X���d�Ȃ����ꍇ
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {
            
        }    
    }

    //�}�E�X�����ꂽ�ꍇ
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {

        }
    }

    //�X�N���[�����삪�s��ꂽ�ꍇ
    public void OnScroll(PointerEventData eventData)
    {
        if (this.name == objButton[nowButton].name)
        {
            float scrollDelta = eventData.scrollDelta.y;//�X�N���[���̉�]��

            if (scrollDelta != 0)
            {
                //��ɃX�N���[�����ꂽ�ꍇ��-200�A����ȊO��200
                int vertical = (scrollDelta > 0) ? -1 : 1;

                if ((gameObject.name == objButton[0].name && vertical == -1) ||
                   (gameObject.name == objButton[objButton.Length - 1].name && vertical == 1))
                {
                    return;
                }

                SetScale(1);
                ButtonScroll(vertical);
            }
        }
    }

    void ButtonScroll(int vertical)
    {
        for(int i = 0; i < objButton.Length; i++)
        {
            RectTransform rectTransform 
                = objButton[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition 
                = new Vector2(rectTransform.anchoredPosition.x + vertical * -50, rectTransform.anchoredPosition.y + vertical * 200);
        }

        nowButton += vertical;
        SetScale(1.25f);
    }

    void SetScale(float scale)
    {
        RectTransform rectTransform
                = objButton[nowButton].GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(scale, scale, rectTransform.localScale.z);
    }
}
