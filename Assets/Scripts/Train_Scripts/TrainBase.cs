using System;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    //��ԍ\����
    [System.Serializable]
    public struct StructTrain
    {
        [Header("�X�e�[�^�X")]
        public string trainType;       //��ԃ^�C�v
        public string formationName;   //�Ґ���
        public int formationNumber;    //�Ґ��ԍ�
        public float[] acceleration;   //������
        public FloatFB2 trainLength;   //��Ԃ̒���(�O�E��)
        public FloatFB2 couplerHp;     //�A����̗̑�(�O�E��)
        public FloatFB2 pantographHp;  //�p���^�O���t�̗̑�(�O�E��)
        public BoolFB2 pantograph;     //�p���^�O���t�̗L��(�O�E��)
        public BoolFB2 isConcatenation;//�A���̗L��(�O�E��)
        public BoolFB2 isWiring;       //�ː��ڐG�̗L��(�O�E��)
        public string status;          //���
    }

    //�\���̕ϐ�
    public StructTrain structTrain;//���

    //��ԃ^�C�v�ꗗ
    enum enumTrainType
    {
        M,
        T,
        Mc,
        Tc,
    }

    private void Awake()
    {
        for (int i = 0; i < pantograph.Length; i++)
        {
            if (pantograph[i])
            {
                isWiring = new bool[i];
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
