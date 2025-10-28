using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;            //移動速度
    public float objectDistance;       //オブジェクトの距離
    public float objectPutTime;        //オブジェクトの設置時間
    public static float objectPutTimer;//オブジェクトの設置タイマー
    private int nowCameraMode;         //現在のカメラモード
    private GameObject objCamera;      //カメラオブジェクト
    public GameObject objSelectObject; //選択中のオブジェクト
    private GameObject objNowObject;   //現在のオブジェクト

    public Vector2 [] positionLimit   //座標限界値
        = new Vector2[2];
    public float addObjectRotation;   //オブジェクトに与える回転値

    public float rotationSpeed;       //回転速度値
    public Vector2 rotationLimit;     //回転限界値
    private Vector2 nowAngle;         //現在の角度

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
        //マウス位置を画面座標で取得する
        Vector2 mousePosition = Input.mousePosition;
        //画面座標をビューポート座標に変換する
        Vector2 viewPortPosition = Camera.main.ScreenToViewportPoint(mousePosition);
        //移動限界値を設定する
        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, positionLimit[0].x, positionLimit[1].x);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, positionLimit[0].y, positionLimit[1].y);
        //ビューポート座標をワールド座標に変換する
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPosition.x, viewPortPosition.y, objectDistance));
        //Z軸を固定（オブジェクトのZ軸を調整）
        worldPosition.z = this.transform.position.z - objectDistance;

        if (Stage.nowPutNum > 0)
        {
            if (objNowObject == null)
            {
                objNowObject = Instantiate(objSelectObject, worldPosition, Quaternion.identity);//オブジェクト生成
            }

            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");//マウスホイールの回転量
            objNowObject.transform.position = worldPosition;

            if (scrollWheel != 0)
            {
                objNowObject.transform.rotation *= RotationObject(scrollWheel);
            }

            //マウス左クリック
            if (Input.GetMouseButtonDown(0))
            {
                ObjectPut();
            }
            //マウスホイールクリック
            if (Input.GetMouseButtonDown(2))
            {
                objNowObject.transform.rotation = Quaternion.identity;//回転を0にする
            }
        }

        //Wキー
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        //Aキー
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        //Sキー
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        //Dキー
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
        bool inputKey = false;//キー入力確認

        if (Input.GetKey(KeyCode.X))//Xキーが押されている場合
        {
            objectAngle.x = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Y))//Yキーが押されている場合
        {
            objectAngle.y = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Z))//Zキーが押されている場合
        {
            objectAngle.z = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
            inputKey = true;
        }
        if(inputKey == false)//キー入力がない場合
        {
            objectAngle.y = (scrollWheel > 0) ? addObjectRotation : -addObjectRotation;
        }

        return Quaternion.Euler(objectAngle.x, objectAngle.y, objectAngle.z);  
    }

    //void PlayerInput()
    //{
    //    if (Input.GetMouseButtonDown(1)) { }
    //    ;//マウス右クリック
    //    if (Input.GetMouseButtonDown(2)) { }
    //    ;//マウス中クリック

    //    //マウスの移動量取得
    //    //nowRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
    //    //nowRotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;

    //    //
    //    //nowRotation.y = Mathf.Clamp(nowRotation.y, minMaxRotation.x, minMaxRotation.y);

    //    //回転を反映
    //    //this.transform.rotation = Quaternion.Euler(nowRotation.y, nowRotation.x, 0.0f);
    //}
}
