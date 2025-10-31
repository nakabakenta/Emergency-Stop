using System;
using Unity.VisualScripting;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    //��ԍ\����
    [System.Serializable]
    public struct StructTrain
    {
        [Header("�X�e�[�^�X")]
        public float trainHp;         //��Ԃ̗̑�
        public FloatFB2 concatLength; //��Ԃ̘A���Ԋu(�O�E��)
        public FloatFB2 couplerHp;    //�A����̗̑�(�O�E��)
        public FloatFB2 pantoHp;      //�p���^�O���t�̗̑�(�O�E��)
        public BoolFB2 isConcat;      //�A��(�O�E��)
        public BoolFB2 isPowerFeeding;//���d(�O�E��)
        public BoolFB2 isOnRail;      //���[����(�O�E��)
    }
 
    private int trainStatus;              //���
    private TrainFormation trainFormation;

    //�\���̕ϐ�
    public StructTrain structTrain;//���

    public void SetTrain(TrainFormation script)
    {
        trainFormation = script;
        trainStatus = (int)TrainStatus.Normal;
    }

    //
    public float CollisionObject(float mass)
    {
        if(GetComponent<Rigidbody>() == null)
        {
           Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
           rb.mass = 5000;
        }

        if (trainStatus != (int)TrainStatus.Derailment)
        {
            structTrain.trainHp -= mass;

            if (structTrain.trainHp <= 0)
            {
                trainStatus = (int)TrainStatus.Derailment;
                structTrain.trainHp = 0;
                Destroy(GetComponent<BoxCollider>());
                Destroy(GetComponent<Rigidbody>());

                //�����̑S�Ă̎q�I�u�W�F�N�g���擾
                foreach (Transform obj in this.transform)
                {
                    obj.gameObject.AddComponent<Rigidbody>();
                }
            }
            else
            {
                trainStatus = (int)TrainStatus.Collision;
            }
        }

        float moveSpeed = trainFormation.Decel(mass / 3.6f);

        return moveSpeed;
    }
}
