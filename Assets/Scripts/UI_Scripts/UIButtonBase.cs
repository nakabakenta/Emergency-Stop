using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected string[] excludeName;  //���O���閼�O
    protected GameObject[] objButton;//�{�^���I�u�W�F�N�g
    protected Button button;         //Button�R���|�[�l���g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        //�擾
        button = this.GetComponent<Button>();//Button
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
}
