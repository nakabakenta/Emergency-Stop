using UnityEngine;

public class TrainBase : MonoBehaviour
{
    //列車構造体
    [System.Serializable]
    public struct StructTrain
    {
        [Header("ステータス")]
        public string trainType;    //列車タイプ
        public float acceleration;  //加速
        public string formationName;//編成名
    }
    public bool[] pantograph        //パンタグラフ(前・後)
        = new bool[2];
    protected bool[] isConcatenation//連結の有無(前・後)
        = new bool[2];
    protected bool[] isWiring;      //架線接触の有無

    protected int carNumber;//両番号

    //構造体変数
    public StructTrain structTrain;//列車

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
