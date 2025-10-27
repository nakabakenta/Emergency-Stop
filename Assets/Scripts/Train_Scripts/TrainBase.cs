using System;
using Unity.VisualScripting;
using UnityEngine;
using static TrainBase;

public class TrainBase : MonoBehaviour
{
    //��ԍ\����
    [System.Serializable]
    public struct StructTrain
    {
        [Header("�X�e�[�^�X")]
        public int formNum;               //�Ґ��ԍ�
        public float trainHp;             //��Ԃ̗̑�
        public FloatFB2 concatLength;     //��Ԃ̘A���Ԋu(�O�E��)
        public FloatFB2 couplerHp;        //�A����̗̑�(�O�E��)
        public FloatFB2 pantoHp;          //�p���^�O���t�̗̑�(�O�E��)
        public BoolFB2 isConcat;          //�A��(�O�E��)
        public BoolFB2 isPowerFeeding;    //���d(�O�E��)
        public BoolFB2 isOnRail;          //���[����(�O�E��)
    }                                     
                                          
    private float nowSpeed;               //���݂̑��x
    private int status;                   //���
    private float[] statusDecel 
        = new float[2] { 2.0f, 1.0f };
    private BoxCollider boxCollider;

    //�\���̕ϐ�
    public StructTrain structTrain;//���

    public void SetTrain()
    {
        status = (int)TrainStatus.Normal;
        boxCollider = GetComponent<BoxCollider>();
    }

    public float GetNowSpeed()
    {
        return nowSpeed;
    }

    //
    public float CollisionObject(float mass)
    {
        if (status == (int)TrainStatus.Normal)
        {
            if (structTrain.trainHp <= 0)
            {
                status = (int)TrainStatus.Derailment;
                structTrain.trainHp = 0;
                boxCollider.enabled = false;

                //�����̑S�Ă̎q�I�u�W�F�N�g���擾
                foreach (Transform obj in this.transform)
                {
                    Rigidbody rb = obj.gameObject.AddComponent<Rigidbody>();
                }
            }
            else
            {
                structTrain.trainHp -= mass;
            }
        }

        if (status != (int)TrainStatus.Stop)
        {
            float decel = mass / statusDecel[status];

            if (nowSpeed <= 0.0f)
            {
                status = (int)TrainStatus.Stop;
                nowSpeed = 0.0f;
            }
            else
            {
                nowSpeed -= decel;
            }
        }

        return nowSpeed;
    }
}
