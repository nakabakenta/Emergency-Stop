using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;            //�ړ����x
    public float objectDistance;       //�I�u�W�F�N�g�̋���
    public float objectPutTime;        //�I�u�W�F�N�g�̐ݒu����
    public static float objectPutTimer;//�I�u�W�F�N�g�̐ݒu�^�C�}�[
    private int nowCameraMode;         //���݂̃J�������[�h
    private GameObject objCamera;      //�J�����I�u�W�F�N�g
    public GameObject objSelectObject; //�I�𒆂̃I�u�W�F�N�g
    private GameObject objNowObject;   //���݂̃I�u�W�F�N�g

    public Vector2 [] positionLimit   //���W���E�l
        = new Vector2[2];
    public float addObjectRotation;   //�I�u�W�F�N�g�ɗ^�����]�l

    public float rotationSpeed;       //��]���x�l
    public Vector2 rotationLimit;     //��]���E�l
    private Vector2 nowAngle;         //���݂̊p�x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPutTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Stage.waitTimer == 0.0f)
        {
            if(objNowObject != null)
            {
                ObjectPut();
            }
        }
        else
        {
            PlayerInput();
        }
    }

    void PlayerInput()
    {
        //�}�E�X�ʒu����ʍ��W�Ŏ擾����
        Vector2 mousePosition = Input.mousePosition;
        //��ʍ��W���r���[�|�[�g���W�ɕϊ�����
        Vector2 viewPortPosition = Camera.main.ScreenToViewportPoint(mousePosition);
        //�ړ����E�l��ݒ肷��
        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, positionLimit[0].x, positionLimit[1].x);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, positionLimit[0].y, positionLimit[1].y);
        //�r���[�|�[�g���W�����[���h���W�ɕϊ�����
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPosition.x, viewPortPosition.y, objectDistance));
        //Z�����Œ�i�I�u�W�F�N�g��Z���𒲐��j
        worldPosition.z = this.transform.position.z - objectDistance;

        if (Stage.nowPutNum > 0)
        {
            if (objNowObject == null)
            {
                objNowObject = Instantiate(objSelectObject, worldPosition, Quaternion.identity);//�I�u�W�F�N�g����
            }

            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");//�}�E�X�z�C�[���̉�]��
            objNowObject.transform.position = worldPosition;

            if (scrollWheel != 0)
            {
                objNowObject.transform.rotation *= RotationObject(scrollWheel);
            }

            //�}�E�X���N���b�N
            if (Input.GetMouseButtonDown(0))
            {
                ObjectPut();
            }
            //�}�E�X�z�C�[���N���b�N
            if (Input.GetMouseButtonDown(2))
            {
                objNowObject.transform.rotation = Quaternion.identity;//��]��0�ɂ���
            }
        }

        //W�L�[
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        //A�L�[
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        //S�L�[
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        //D�L�[
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }

    void ObjectPut()
    {
        BoxCollider objCollider = objNowObject.GetComponent<BoxCollider>();
        Rigidbody objRigidBody = objNowObject.GetComponent<Rigidbody>();
        objCollider.isTrigger = false;
        objRigidBody.isKinematic = false;
        objNowObject = null;
        Stage.nowPutNum--;
        UIStage.uIStage.SetTextObject();
    }

    Quaternion RotationObject(float scrollWheel)
    {
        Vector3 objectAngle = Vector3.zero;
        bool inputKey = false;//�L�[���͊m�F

        if (Input.GetKey(KeyCode.X))//X�L�[��������Ă���ꍇ
        {
            objectAngle.x = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Y))//Y�L�[��������Ă���ꍇ
        {
            objectAngle.y = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Z))//Z�L�[��������Ă���ꍇ
        {
            objectAngle.z = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
            inputKey = true;
        }
        if(inputKey == false)//�L�[���͂��Ȃ��ꍇ
        {
            objectAngle.y = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
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
