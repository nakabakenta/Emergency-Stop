using System;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
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

    //�\���̕ϐ�
    public StructTrain structTrain;//���

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    enum enumStatus
    {
        Normal,    //�ʏ�
        Derailment,//�E��
        Stop,      //��~
    }
}
