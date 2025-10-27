using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainFormation : MonoBehaviour
{
    public GameObject[] trainPre;         //列車プレハブ
    public float[] accel;                 //加速力
    public float[] brake;                 //減速力
    public float[] maxSpeed;              //最大速度
    public string[] formSetting;          //編成設定
    public float distance;                //距離
    private int trainNum;                 //列車数
    private int nowAccel = 0;
    private float[] moveSpeed;
    private GameObject[] objTrain;        //列車オブジェクト
    private TrainFormation trainFormation;//

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
        trainFormation = this.GetComponent<TrainFormation>();
        trainNum = formSetting.Length;
        moveSpeed = new float[trainNum];
        objTrain = new GameObject[trainNum];
        

        for (int i = 0; i < trainNum; i++)
        {
            enumTrainType type = (enumTrainType)System.Enum.Parse(typeof(enumTrainType), formSetting[i]);
            objTrain[i] = Instantiate(trainPre[(int)type], this.transform.position, Quaternion.identity, transform);//オブジェクト生成

            for (int j = 0; j < i + 1; j++)
            {
                TrainBase trainBase = objTrain[j].GetComponent<TrainBase>();
                trainBase.SetTrain();
                float length = 0;

                if (i == trainNum - 1)
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

    // Update is called once per frame
    void Update()
    {
        MoveTrain();
    }

    public float MoveTrain()
    {
        for (int i = 0; i < trainNum; i++)
        {
            TrainBase trainBase = objTrain[i].GetComponent<TrainBase>();
            moveSpeed[i] = trainBase.GetNowSpeed();
        }

        if (Function.SetSpeed(nowSpeed) >= trainFormation.maxSpeed[trainFormation.nowAccel])
        {
            if (nowAccel < accel.Length - 1)
            {
                nowAccel++;
            }

            if (nowAccel == accel.Length - 1 && nowSpeed > maxSpeed[nowAccel])
            {
                nowSpeed = maxSpeed[nowAccel];
            }
        }
        else
        {
            nowSpeed += accel[nowAccel] * Time.deltaTime;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + nowSpeed * Time.deltaTime);

        UIStage.uIStage.SetTextSpeed(Function.SetSpeed(trainFormation.MoveTrain()));

        return 0;
    }
}
