using System.Collections.Generic;
using UnityEngine;

public class SetUIButton : MonoBehaviour
{
    public GameObject[] objUIButton;//�{�^���I�u�W�F�N�g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    { 
        Transform thisTransform = this.transform;               //�q�I�u�W�F�N�g���擾����g�����X�t�H�[��
        List<GameObject> listObjButton = new List<GameObject>();//�{�^���I�u�W�F�N�g���X�g

        //�w�肵���g�����X�t�H�[���̎q�I�u�W�F�N�g���擾
        foreach (Transform transform in thisTransform.transform)
        {
            UIButtonBase uIButtonBase = transform.gameObject.GetComponent<UIButtonBase>();//�q�I�u�W�F�N�g��UIButtonBase�X�N���v�g���擾����
            uIButtonBase.setUIButton = this.GetComponent<SetUIButton>();                  //�擾����UIButtonBase�X�N���v�g�ɂ��̃I�u�W�F�N�g��SetUIButton�X�N���v�g��n��
            listObjButton.Add(transform.gameObject);                                      //���X�g�Ɏq�I�u�W�F�N�g������
        }

        objUIButton = listObjButton.ToArray();//���X�g��z��ɕϊ�����
    }
}
