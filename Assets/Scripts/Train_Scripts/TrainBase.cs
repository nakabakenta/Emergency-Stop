using System;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    enum enumStatus
    {
        Normal,    //通常
        Derailment,//脱線
        Stop,      //停止
    }

    //列車構造体
    [System.Serializable]
    public struct StructTrain
    {
        [Header("ステータス")]
        public string formName;       //編成名
        public int formNum;           //編成番号
        public FloatFB2 concatLength; //列車の連結間隔(前・後)
        public FloatFB2 couplerHp;    //連結器の体力(前・後)
        public FloatFB2 pantoHp;      //パンタグラフの体力(前・後)
        public BoolFB2 isConcat;      //連結(前・後)
        public BoolFB2 isPowerFeeding;//給電(前・後)
        public BoolFB2 isOnRail;      //レール上(前・後)
        public string status;         //状態
    }

    private BoxCollider boxCollider;

    //構造体変数
    public StructTrain structTrain;//列車

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

    //当たり判定(OnCollisionStay)
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            if (boxCollider.enabled)
            {
                boxCollider.enabled = false;

                //自分の全ての子オブジェクトを取得
                foreach (Transform obj in this.transform)
                {
                    //Rigidbodyがなければ追加
                    if (obj.GetComponent<Rigidbody>() == null)
                    {
                        Rigidbody rb = obj.gameObject.AddComponent<Rigidbody>();
                    }
                }
            }
        }
    }
}
