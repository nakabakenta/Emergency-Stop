using UnityEngine;

public class TrainBase : MonoBehaviour
{
    //��ԍ\����
    [System.Serializable]
    public struct StructTrain
    {
        [Header("�X�e�[�^�X")]
        public string trainType;    //��ԃ^�C�v
        public float acceleration;  //����
        public string formationName;//�Ґ���
    }
    public bool[] pantograph        //�p���^�O���t(�O�E��)
        = new bool[2];
    protected bool[] isConcatenation//�A���̗L��(�O�E��)
        = new bool[2];
    protected bool[] isWiring;      //�ː��ڐG�̗L��

    protected int carNumber;//���ԍ�

    //�\���̕ϐ�
    public StructTrain structTrain;//���

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
