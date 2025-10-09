using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonMenu : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public static int nowButton;//���݂̃{�^��

    //���j���[���ꗗ
    enum MenuName
    {
        GameModeSelect,//�Q�[�����[�h�I��
        Museum,        //������
        Option,        //�I�v�V����
        BackToTtle,    //�^�C�g���ɖ߂�
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        uIMenu.SetText(nowButton);
    }

    //�N���b�N���ꂽ�ꍇ
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            switch (nowButton)
            {
                case (int)MenuName.GameModeSelect:
                    UIMenu.nowStatus = nowButton + 1;
                    uIMenu.SetMenu();
                    break;
                case (int)MenuName.Museum:
                    break;
                case (int)MenuName.Option:
                    break;
                case (int)MenuName.BackToTtle:
                    UIMenu.nowStatus = nowButton;
                    uIMenu.SetMenu();
                    break;
            }
        }
    }

    //�X�N���[�����삪�s��ꂽ�ꍇ
    public override void OnScroll(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            float scrollDelta = eventData.scrollDelta.y;//�X�N���[���̉�]��

            if (scrollDelta != 0)
            {
                //��ɃX�N���[�����ꂽ�ꍇ��-1�A����ȊO��1
                int vertical = (scrollDelta > 0) ? -1 : 1;

                if ((nowButton == (int)MenuName.GameModeSelect && vertical == -1) ||
                    (nowButton == (int)MenuName.BackToTtle && vertical == 1))
                {
                    return;
                }

                ButtonScroll(vertical);
            }
        }
    }

    void ButtonScroll(int vertical)
    {
        for (int i = 0; i < setUIButton.objUIButton.Length; i++)
        {
            RectTransform rectTransform
                = setUIButton.objUIButton[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition
                = new Vector2(rectTransform.anchoredPosition.x + vertical * 100, rectTransform.anchoredPosition.y + vertical * 200);

            if(i == nowButton)
            {
                rectTransform.localScale = Function.ResetVector3(0.75f);
            }
            else if( i == nowButton + vertical)
            {
                rectTransform.localScale = Vector3.one;
            }
        }

        nowButton += vertical;
        uIMenu.SetText(nowButton);
    }
}
