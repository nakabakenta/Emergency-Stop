using System;
using Unity.VisualScripting;
using UnityEngine;
using static TrainBase;

public class TrainBase : MonoBehaviour
{
    //列車構造体
    [System.Serializable]
    public struct StructTrain
    {
        [Header("ステータス")]
        public int formNum;               //編成番号
        public float trainHp;             //列車の体力
        public FloatFB2 concatLength;     //列車の連結間隔(前・後)
        public FloatFB2 couplerHp;        //連結器の体力(前・後)
        public FloatFB2 pantoHp;          //パンタグラフの体力(前・後)
        public BoolFB2 isConcat;          //連結(前・後)
        public BoolFB2 isPowerFeeding;    //給電(前・後)
        public BoolFB2 isOnRail;          //レール上(前・後)
    }                                     
                                          
    private float nowSpeed;               //現在の速度
    private int status;                   //状態
    private float[] statusDecel 
        = new float[2] { 2.0f, 1.0f };
    private BoxCollider boxCollider;

    //構造体変数
    public StructTrain structTrain;//列車

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

                //自分の全ての子オブジェクトを取得
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
