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
        nowButton = 0;
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
       
    }

    //�}�E�X�����ꂽ�ꍇ
    public override void OnPointerExit(PointerEventData eventData)
    {

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
                = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + vertical * 200);
        }

        nowButton += vertical;
    }
}
