using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;           //�ړ����x
    public float objectDistance;      //�I�u�W�F�N�g�̋���
    private int nowCameraMode;        //���݂̃J�������[�h
    private GameObject objCamera;     //�J�����I�u�W�F�N�g
    public GameObject objSelectObject;//�I�𒆂̃I�u�W�F�N�g
    private GameObject objNowObject;  //���݂̃I�u�W�F�N�g

    public Vector2 [] positionLimit   //���W���E�l
        = new Vector2[2];
    public float addObjectRotation;   //�I�u�W�F�N�g�ɗ^�����]�l

    public float rotationSpeed;       //��]���x�l
    public Vector2 rotationLimit;     //��]���E�l
    private Vector2 nowAngle;         //���݂̊p�x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = objectDistance;

        Vector3 viewPortPosition = Camera.main.ScreenToViewportPoint(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z));
        //�ړ����E�ʂ�ݒ肷��
        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, positionLimit[0].x, positionLimit[1].x);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, positionLimit[0].y, positionLimit[1].y);
        //�r���[�|�[�g���W�����[���h���W�ɕϊ�����
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPosition.x, viewPortPosition.y, viewPortPosition.z));

        if (objNowObject == null)
        {
            objNowObject = Instantiate(objSelectObject, worldPosition, Quaternion.identity);//�I�u�W�F�N�g����
        }
        else
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");//�}�E�X�z�C�[����]����
            objNowObject.transform.position = worldPosition;

            if(scrollWheel != 0)
            {
                objNowObject.transform.rotation *= RotationObject(scrollWheel);
            }

            //�}�E�X���N���b�N
            if (Input.GetMouseButtonDown(0))
            {
                objNowObject = null;
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

    Quaternion RotationObject(float scrollWheel)
    {
        Vector3 objectAngle = Vector3.zero;

        KeyCode? nowKey = null;//���݂̃L�[
        KeyCode[] inputKey = { KeyCode.X, KeyCode.Y, KeyCode.Z };

        if (nowKey != null)
        {
            if (Input.GetKeyUp((KeyCode)nowKey))
            {
                nowKey = null;
            }
        }

        foreach (KeyCode key in inputKey)
        {
            if (Input.GetKey(key))
            {
                nowKey = key;

                switch (nowKey)
                {
                    case KeyCode.X:
                        objectAngle.x = (scrollWheel < 0) ? -addObjectRotation : addObjectRotation;
                        break;
                    case KeyCode.Y:
                        objectAngle.y = (scrollWheel < 0) ? -addObjectRotation : addObjectRotation;
                        break;
                    case KeyCode.Z:
                        objectAngle.z = (scrollWheel < 0) ? -addObjectRotation : addObjectRotation;
                        break;
                }
            }
            else
            {
                objectAngle.y = (scrollWheel < 0) ? -addObjectRotation : addObjectRotation;
            }
        }

        return Quaternion.Euler(objectAngle.x, objectAngle.y, objectAngle.z);
    }

    void PlayerInput()
    {
        if (Input.GetMouseButtonDown(1)) { }
        ;//�}�E�X�E�N���b�N
        if (Input.GetMouseButtonDown(2)) { }
        ;//�}�E�X���N���b�N

        //�}�E�X�̈ړ��ʎ擾
        //nowRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        //nowRotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;

        //
        //nowRotation.y = Mathf.Clamp(nowRotation.y, minMaxRotation.x, minMaxRotation.y);

        //��]�𔽉f
        //this.transform.rotation = Quaternion.Euler(nowRotation.y, nowRotation.x, 0.0f);
    }
}
