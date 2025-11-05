using System;
using Unity.VisualScripting;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    //列車構造体
    [System.Serializable]
    public struct StructTrain
    {
        [Header("ステータス")]
        public float trainHp;         //列車の体力
        public FloatFB2 concatLength; //列車の連結間隔(前・後)
        public FloatFB2 couplerHp;    //連結器の体力(前・後)
        public FloatFB2 pantoHp;      //パンタグラフの体力(前・後)
        public BoolFB2 isConcat;      //連結(前・後)
        public BoolFB2 isPowerFeeding;//給電(前・後)
        public BoolFB2 isOnRail;      //レール上(前・後)
    }
 
    private int trainStatus;              //状態
    private TrainFormation trainFormation;

    //構造体変数
    public StructTrain structTrain;//列車

    public void SetTrain(TrainFormation script)
    {
        trainFormation = script;
        trainStatus = (int)TrainStatus.Normal;
    }

    //
    public float CollisionObject(float mass)
    {
        if (GetComponent<Rigidbody>() == null)
        {
           Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
           rb.mass = 5000;
           rb.constraints = RigidbodyConstraints.FreezePositionY;
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

                //自分の全ての子オブジェクトを取得
                foreach (Transform obj in this.transform)
                {
                    obj.gameObject.AddComponent<Rigidbody>();
                    //Rigidbody rb = obj.gameObject.AddComponent<Rigidbody>();
                    //rb.constraints = RigidbodyConstraints.FreezePositionY;
                }
            }
            else
            {
                trainStatus = (int)TrainStatus.Collision;
            }
        }

        float moveSpeed = trainFormation.Decel(mass, trainStatus);

        return moveSpeed;
    }
}
