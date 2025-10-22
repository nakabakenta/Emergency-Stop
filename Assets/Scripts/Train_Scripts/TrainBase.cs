using System;
using UnityEngine;

public class TrainBase : MonoBehaviour
{
    //列車構造体
    [System.Serializable]
    public struct StructTrain
    {
        [Header("ステータス")]
        public string trainType;       //列車タイプ
        public string formationName;   //編成名
        public int formationNumber;    //編成番号
        public float[] acceleration;   //加速力
        public FloatFB2 trainLength;   //列車の長さ(前・後)
        public FloatFB2 couplerHp;     //連結器の体力(前・後)
        public FloatFB2 pantographHp;  //パンタグラフの体力(前・後)
        public BoolFB2 pantograph;     //パンタグラフの有無(前・後)
        public BoolFB2 isConcatenation;//連結の有無(前・後)
        public BoolFB2 isWiring;       //架線接触の有無(前・後)
        public string status;          //状態
    }

    //構造体変数
    public StructTrain structTrain;//列車

    //列車タイプ一覧
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
