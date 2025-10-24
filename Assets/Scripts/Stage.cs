using UnityEngine;

public class Stage : MonoBehaviour
{
    public int maxPutNumber;       //�ő�ݒu��
    public static int nowPutNumber;//���݂̐ݒu��
    public float waitTime;         //�ҋ@����
    private float waitTimer;       //�ҋ@�^�C�}�[
    public static string status;   //���

    private UIStage uIStage;

    public Transform trainFormation;
    public Transform endPosition;

    private void Awake()
    {
        waitTimer = waitTime;
        nowPutNumber = maxPutNumber;

        uIStage = this.GetComponent<UIStage>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer != 0.0f)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0.0f)
            {
                waitTimer = 0.0f;
            }

            uIStage.SetTextTimer(waitTimer);
        }

        float distance = Vector3.Distance(trainFormation.position, endPosition.position);
        uIStage.SetTextDistance(distance);
    }
}
