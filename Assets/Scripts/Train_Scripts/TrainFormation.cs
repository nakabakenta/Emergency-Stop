using UnityEngine;
using UnityEngine.Rendering;
using static Stage;

public class TrainFormation : MonoBehaviour
{
    private Stage cSStage;
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
    private bool isStop = true;
    private bool isMaxSpeed = false;
    private GameState gameState;

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

    public void SetStage(Stage script)
    {
        cSStage = script;
    }

    // Update is called once per frame
    void Update()
    {
        gameState = cSStage.GetState();

        if(gameState == GameState.GameDep)
        {
            isStop = cSStage.SetTrainSpeed(moveSpeed, isMaxSpeed);
            if(isStop) moveSpeed = 0.0f;
        }

        if (!isStop)
        {
            MoveTrain();
        }
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

                if(!isMaxSpeed) isMaxSpeed = true;
                Debug.Log(isMaxSpeed);
            }
        }
        else
        {
            moveSpeed += accel[nowAccel] * Time.deltaTime;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + moveSpeed * Time.deltaTime);
    }

    public void Derailment(float value)
    {
        if (gameState == GameState.GameDep && !isStop)
        {
            moveSpeed -= value / 3.6f;
        }
    }

    public float Decel(float value)
    {
        if(gameState == GameState.GameDep && !isStop)
        {
            moveSpeed -= value / 3.6f;
        }

        return moveSpeed;
    }
}
