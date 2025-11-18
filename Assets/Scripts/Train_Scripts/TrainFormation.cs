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
    private float moveSpeed = 0;
    private GameObject[] objTrain;        //列車オブジェクト
    private TrainFormation trainFormation;//
    private bool stop = false;

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
        objTrain = new GameObject[trainNum];
        
        for (int formNum = 0; formNum < trainNum; formNum++)
        {
            enumTrainType type = (enumTrainType)System.Enum.Parse(typeof(enumTrainType), formSetting[formNum]);
            objTrain[formNum] = Instantiate(trainPre[(int)type], this.transform.position, Quaternion.identity, transform);//オブジェクト生成

            for (int lastTrain = 0; lastTrain < formNum + 1; lastTrain++)
            {
                TrainBase trainBase = objTrain[lastTrain].GetComponent<TrainBase>();
                trainBase.SetTrain(trainFormation);
                float length = 0;

                if (formNum == trainNum - 1)
                {
                    length = trainBase.structTrain.concatLength.front;
                }
                else
                {
                    length = trainBase.structTrain.concatLength.front + trainBase.structTrain.concatLength.back;
                }

                objTrain[lastTrain].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, objTrain[lastTrain].transform.position.z + length);
            }
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage.status == (int)GameStatus.GameDep && !stop)
        {
            MoveTrain();
        }

        UIStage.uIStage.SetTextSpeed(Function.SetSpeed(moveSpeed));
    }

    void MoveTrain()
    {
        if (Function.SetSpeed(moveSpeed) >= trainFormation.maxSpeed[trainFormation.nowAccel])
        {
            if (nowAccel < accel.Length - 1)
            {
                nowAccel++;
            }

            if (nowAccel == accel.Length - 1 && Function.SetSpeed(moveSpeed) > maxSpeed[nowAccel])
            {
                moveSpeed = maxSpeed[nowAccel] / 3.6f;
            }
        }
        else
        {
            moveSpeed += accel[nowAccel] * Time.deltaTime;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + moveSpeed * Time.deltaTime);
    }

    public float Decel(float decel, int status)
    {
        moveSpeed -= decel / 3.6f;

        if (moveSpeed <= 0.0f)
        {
            moveSpeed = 0.0f;
            stop = true;
        }

        //if (status == (int)TrainStatus.Derailment)
        //{
            
        //}

        if (moveSpeed <= 0.0f && stop)
        {
            Stage.status = (int)GameStatus.GameClear;
        }

        return moveSpeed;
    }
}
