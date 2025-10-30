using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;           //�ړ����x
    public float objDistance;         //�I�u�W�F�N�g�̋���
    public float objPlaceTime;        //�I�u�W�F�N�g�̐ݒu����
    public static float objPlaceTimer;//�I�u�W�F�N�g�̐ݒu�^�C�}�[
    private int nowCameraMode;        //���݂̃J�������[�h
    private GameObject[] objCamera;   //�J�����I�u�W�F�N�g
    private GameObject nowObj;        //���݂̃I�u�W�F�N�g

    public Vector2 minPos, maxPos;    //�ŏ��E��ʒu

    public float addObjRotation;      //�I�u�W�F�N�g�ɗ^�����]�l
    public float rotationSpeed;       //��]���x�l
    public Vector2 rotationLimit;     //��]���E�l
    private Vector2 nowAngle;         //���݂̊p�x

    private float maxDistance = 10f;  // ���̍ő勗��
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        objPlaceTimer = 0.0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Stage.status != GameStatus.GameClear.ToString() || Stage.status != GameStatus.GameOver.ToString()) PlayerInput();

        if (Stage.nowPutNum == 0 || Stage.status == GameStatus.GameStart.ToString())
        {
            lineRenderer.enabled = false;
        }
    }

    void PlayerInput()
    {
        if(Stage.status == null)
        {
            Vector2 mousePos = Input.mousePosition;//�}�E�X�ʒu����ʍ��W�Ŏ擾����
            //��ʍ��W���r���[�|�[�g���W�ɕϊ�����
            Vector2 viewPortPos = Camera.main.ScreenToViewportPoint(mousePos);
            //��ʌ��E�l��ݒ肷��
            viewPortPos.x = Mathf.Clamp(viewPortPos.x, minPos.x, maxPos.x);
            viewPortPos.y = Mathf.Clamp(viewPortPos.y, minPos.y, maxPos.y);
            //�r���[�|�[�g���W�����[���h���W�ɕϊ�����
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPos.x, viewPortPos.y, objDistance));
            worldPos.z = this.transform.position.z - objDistance;//Z�����Œ�i�I�u�W�F�N�g��Z���𒲐��j

            if (Stage.nowPutNum > 0)
            {
                //�}�E�X���N���b�N
                if (nowObj == null || Input.GetMouseButtonDown(0)) ObjSetting(worldPos);
                else
                {
                    nowObj.transform.position = worldPos;
                    //�}�E�X�z�C�[���N���b�N
                    if (Input.GetMouseButtonDown(2)) nowObj.transform.rotation = Quaternion.identity;//��]��0�ɂ���
                    float scrollWheel = Input.GetAxis("Mouse ScrollWheel");                          //�}�E�X�z�C�[���̉�]��
                    if (scrollWheel != 0) nowObj.transform.rotation *= RotationObject(scrollWheel);

                    // Raycast�����s
                    if (Physics.Raycast(worldPos, Vector3.down, out RaycastHit hit, maxDistance))
                    {
                        // �����ɓ���������A���̈ʒu�܂Ő���`��
                        lineRenderer.SetPosition(0, worldPos);
                        lineRenderer.SetPosition(1, hit.point);
                    }
                    else
                    {
                        // ���ɂ�������Ȃ���΁A�ő勗���܂Ő���`��
                        lineRenderer.SetPosition(0, worldPos);
                        lineRenderer.SetPosition(1, worldPos + Vector3.down * maxDistance);
                    }
                } 
            }
        }
        else
        {
            if (nowObj != null) Destroy(nowObj);
        }

        //W�L�[
        if (Input.GetKey(KeyCode.W)) this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //A�L�[
        if (Input.GetKey(KeyCode.A)) this.transform.position -= transform.right * moveSpeed * Time.deltaTime;
        //S�L�[
        if (Input.GetKey(KeyCode.S)) this.transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        //D�L�[
        if (Input.GetKey(KeyCode.D)) this.transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    void ObjSetting(Vector3 pos)
    {
        ObjInfo objInfo = this.GetComponent<ObjInfo>();

        if (Input.GetMouseButtonDown(0)) nowObj = objInfo.ObjPlace(nowObj);
        else if (nowObj == null) nowObj = objInfo.ObjGen(pos);
    }

    Quaternion RotationObject(float scrollWheel)
    {
        Vector3 objectAngle = Vector3.zero;
        bool inputKey = false;//�L�[���͊m�F

        if (Input.GetKey(KeyCode.X))//X�L�[��������Ă���ꍇ
        {
            objectAngle.x = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Y))//Y�L�[��������Ă���ꍇ
        {
            objectAngle.y = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Z))//Z�L�[��������Ă���ꍇ
        {
            objectAngle.z = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
            inputKey = true;
        }
        if(!inputKey)//�L�[���͂��Ȃ��ꍇ
        {
            objectAngle.y = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
        }

        return Quaternion.Euler(objectAngle.x, objectAngle.y, objectAngle.z);  
    }

    //void PlayerInput()
    //{
    //    if (Input.GetMouseButtonDown(1)) { }
    //    ;//�}�E�X�E�N���b�N
    //    if (Input.GetMouseButtonDown(2)) { }
    //    ;//�}�E�X���N���b�N

    //    //�}�E�X�̈ړ��ʎ擾
    //    //nowRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
    //    //nowRotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;

    //    //
    //    //nowRotation.y = Mathf.Clamp(nowRotation.y, minMaxRotation.x, minMaxRotation.y);

    //    //��]�𔽉f
    //    //this.transform.rotation = Quaternion.Euler(nowRotation.y, nowRotation.x, 0.0f);
    //}
}
