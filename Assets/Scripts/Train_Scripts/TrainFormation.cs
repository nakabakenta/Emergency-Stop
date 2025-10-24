using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainFormation : MonoBehaviour
{
    public GameObject[] trainPre;   //列車プレハブ
    public float[] accel;           //加速力
    public float[] brake;           //減速力
    public float[] maxSpeed;        //最大速度
    public string[] formSetting;    //編成設定
    public float distance;          //距離

    protected int trainNum;         //列車数
    protected float nowSpeed;       //現在の速度
    protected GameObject[] objTrain;//列車オブジェクト

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
        objTrain = new GameObject[formSetting.Length];
        trainNum = formSetting.Length;

        for (int i = 0; i < objTrain.Length; i++)
        {
            enumTrainType type = (enumTrainType)System.Enum.Parse(typeof(enumTrainType), formSetting[i]);
            objTrain[i] = Instantiate(trainPre[(int)type], this.transform.position, Quaternion.identity, transform);//オブジェクト生成

            for (int j = 0; j <= i; j++)
            {
                TrainBase trainBase = objTrain[j].GetComponent<TrainBase>();
                float length = 0;

                if (i == objTrain.Length - 1)
                {
                    length = trainBase.structTrain.concatLength.front;
                }
                else
                {
                    length = trainBase.structTrain.concatLength.front + trainBase.structTrain.concatLength.back;
                }

                objTrain[j].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, objTrain[j].transform.position.z + length);
            }
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - distance);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nowSpeed * 3.6f < maxSpeed[0])
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + accel[0] * Time.deltaTime);
        }
    }
}
