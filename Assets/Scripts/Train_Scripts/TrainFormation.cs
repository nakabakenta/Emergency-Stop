using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainFormation : MonoBehaviour
{
    public GameObject[] trainPre;   //��ԃv���n�u
    public float[] accel;           //������
    public float[] brake;           //������
    public float[] maxSpeed;        //�ő呬�x
    public string[] formSetting;    //�Ґ��ݒ�
    public float distance;          //����

    protected int trainNum;         //��Ԑ�
    protected float nowSpeed;       //���݂̑��x
    protected GameObject[] objTrain;//��ԃI�u�W�F�N�g

    //��ԃ^�C�v�ꗗ
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
            objTrain[i] = Instantiate(trainPre[(int)type], this.transform.position, Quaternion.identity, transform);//�I�u�W�F�N�g����

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
