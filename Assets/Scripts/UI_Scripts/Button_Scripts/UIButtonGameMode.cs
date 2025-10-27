using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonGameMode : UIButtonBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    public static int nowButton;//���݂̃{�^��

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    //�N���b�N���ꂽ�ꍇ
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            GameBase.nowGameMode = ((GameMode)nowButton).ToString();//���݂̃{�^���ԍ����Q�[�����[�h���ɕϊ�����

            //if(GameBase.gameMode == GameModeName.Normal.ToString())
            //{
            //    SceneLoader.LoadScene(SceneName.StageSelect.ToString());
            //}

            SceneLoader.LoadScene(Scene.StageSelect.ToString());
        }
    }

    //�}�E�X���d�Ȃ����ꍇ
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {
            
        }    
    }

    //�}�E�X�����ꂽ�ꍇ
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (this.name == setUIButton.objUIButton[nowButton].name)
        {

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

                if ((nowButton == (int)GameMode.Normal && vertical == -1) ||
                    (nowButton == (int)GameMode.Free && vertical == 1))
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

            if (i == nowButton)
            {
                rectTransform.localScale = Function.ResetVector3(0.75f);
            }
            else if (i == nowButton + vertical)
            {
                rectTransform.localScale = Vector3.one;
            }
        }

        nowButton += vertical;
        //uIMenu.SetText(nowButton);
    }
}
