using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IScrollHandler
{
    protected Button button;       //Button�R���|�[�l���g
    public SetUIButton setUIButton;//SetUIButton�X�N���v�g
    public static UIMenu uIMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //�擾
        button = this.GetComponent<Button>();//Button

        if(GameBase.nowScene == SceneName.Menu.ToString())
        {
            if (uIMenu == null)
            {
                uIMenu = GameObject.Find("Canvas_" + GameBase.nowScene).GetComponent<UIMenu>();
            }
        }
    }

    //�N���b�N���ꂽ�ꍇ
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }

    //�}�E�X���d�Ȃ����ꍇ
    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    //�}�E�X�����ꂽ�ꍇ
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }

    //�X�N���[�����삪�s��ꂽ�ꍇ
    public virtual void OnScroll(PointerEventData eventData)
    {

    }
}
