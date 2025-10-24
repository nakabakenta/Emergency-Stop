using System;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
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

    //構造体変数
    public StructTrain structTrain;//列車

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
        Normal,    //通常
        Derailment,//脱線
        Stop,      //停止
    }
}
