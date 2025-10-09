using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class SetUIButton : MonoBehaviour
{
    public GameObject[] objUIButton;//�{�^���I�u�W�F�N�g

    //�X�N���v�g���ꗗ
    enum ScriptName
    {
        UIButtonMenu,
        UIButtonGameMode,
        UIButtonSelection
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    { 
        Transform thisTransform = this.transform;               //�q�I�u�W�F�N�g���擾����g�����X�t�H�[��
        List<GameObject> listObjButton = new List<GameObject>();//�{�^���I�u�W�F�N�g���X�g

        //�q�I�u�W�F�N�g�̐��܂Ŏ��s����
        for (int i = 0; i < thisTransform.childCount; i++)
        {
            Transform transform = thisTransform.GetChild(i);//�q�I�u�W�F�N�g���擾����

            //�擾�����q�I�u�W�F�N�g�ɂǂ̃X�N���v�g�����Ă��邩���ׂ�
            for (int j = 0; j < (int)ScriptName.UIButtonSelection + 1; j++)
            {
                Type scriptType = Type.GetType(((ScriptName)j).ToString());      //�X�N���v�g����o�^����
                Component script = transform.gameObject.GetComponent(scriptType);//�o�^�������O�̃X�N���v�g�����Ă��邩�m�F����

                //�o�^�������O�̃X�N���v�g�����Ă����ꍇ
                if (script)
                {
                    FieldInfo publicFieldInfo                                          //�擾�����X�N���v�g���̕ϐ�"setUIButton"�����t���N�V��������
                        = scriptType.GetField("setUIButton");
                    publicFieldInfo.SetValue(script, this.GetComponent<SetUIButton>());//���t���N�V���������ϐ��ɂ��̃I�u�W�F�N�g�̃X�N���v�g��n��

                    //�{�^���̏�����(i == 0�̎�����)
                    if (i == 0)
                    {
                        RectTransform rectTransform//�q�I�u�W�F�N�g��"RectTransform"���擾����
                            = transform.gameObject.GetComponent<RectTransform>();
                        FieldInfo staticFieldInfo  //�擾�����X�N���v�g���̐ÓI�ϐ�"nowButton"�����t���N�V��������
                            = scriptType.GetField("nowButton");
                        rectTransform.localScale = Vector3.one;//�q�I�u�W�F�N�g�̃X�P�[����1�ɂ���
                        staticFieldInfo.SetValue(null, i);     //���t���N�V���������ϐ���"i(0)"��n��
                    }

                    break;//for�I��
                }
            }

            listObjButton.Add(transform.gameObject);//���X�g�Ɏq�I�u�W�F�N�g������
        }

        objUIButton = listObjButton.ToArray();//���X�g��z��ɕϊ�����
    }
}
