using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected string[] excludeName;//���O���閼�O
    public GameObject[] objButton; //�{�^���I�u�W�F�N�g
    protected Button button;       //Button�R���|�[�l���g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        List<GameObject> listObjButton = new List<GameObject>();//�{�^���I�u�W�F�N�g���X�g

        //�擾
        button = this.GetComponent<Button>();//Button
        Transform transformChild
            = GameObject.Find("UI_" + GameBase.scene).transform.Find("UI_Button");

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
