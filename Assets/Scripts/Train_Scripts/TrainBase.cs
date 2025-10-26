using System;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    enum enumStatus
    {
        Normal,    //�ʏ�
        Derailment,//�E��
        Stop,      //��~
    }

    //��ԍ\����
    [System.Serializable]
    public struct StructTrain
    {
        [Header("�X�e�[�^�X")]
        public string formName;       //�Ґ���
        public int formNum;           //�Ґ��ԍ�
        public FloatFB2 concatLength; //��Ԃ̘A���Ԋu(�O�E��)
        public FloatFB2 couplerHp;    //�A����̗̑�(�O�E��)
        public FloatFB2 pantoHp;      //�p���^�O���t�̗̑�(�O�E��)
        public BoolFB2 isConcat;      //�A��(�O�E��)
        public BoolFB2 isPowerFeeding;//���d(�O�E��)
        public BoolFB2 isOnRail;      //���[����(�O�E��)
        public string status;         //���
    }

    private BoxCollider boxCollider;

    //�\���̕ϐ�
    public StructTrain structTrain;//���

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�����蔻��(OnCollisionStay)
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            if (boxCollider.enabled)
            {
                boxCollider.enabled = false;

                //�����̑S�Ă̎q�I�u�W�F�N�g���擾
                foreach (Transform obj in this.transform)
                {
                    //Rigidbody���Ȃ���Βǉ�
                    if (obj.GetComponent<Rigidbody>() == null)
                    {
                        Rigidbody rb = obj.gameObject.AddComponent<Rigidbody>();
                    }
                }
            }
        }
    }
}
