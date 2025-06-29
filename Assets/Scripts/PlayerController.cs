using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;           //移動速度
    public float objectDistance;      //オブジェクトの距離
    private int nowCameraMode;        //現在のカメラモード
    private GameObject objCamera;     //カメラオブジェクト
    public GameObject objSelectObject;//選択中のオブジェクト
    private GameObject objNowObject;  //現在のオブジェクト

    public Vector2 [] positionLimit   //座標限界値
        = new Vector2[2];
    public float addObjectRotation;   //オブジェクトに与える回転値

    public float rotationSpeed;       //回転速度値
    public Vector2 rotationLimit;     //回転限界値
    private Vector2 nowAngle;         //現在の角度

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
        //移動限界位を設定する
        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, positionLimit[0].x, positionLimit[1].x);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, positionLimit[0].y, positionLimit[1].y);
        //ビューポート座標をワールド座標に変換する
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPosition.x, viewPortPosition.y, viewPortPosition.z));

        if (objNowObject == null)
        {
            objNowObject = Instantiate(objSelectObject, worldPosition, Quaternion.identity);//オブジェクト生成
        }
        else
        {
            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");//マウスホイール回転方向
            objNowObject.transform.position = worldPosition;

            if(scrollWheel != 0)
            {
                objNowObject.transform.rotation *= RotationObject(scrollWheel);
            }

            //マウス左クリック
            if (Input.GetMouseButtonDown(0))
            {
                objNowObject = null;
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

    Quaternion RotationObject(float scrollWheel)
    {
        Vector3 objectAngle = Vector3.zero;

        KeyCode? nowKey = null;//現在のキー
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
        ;//マウス右クリック
        if (Input.GetMouseButtonDown(2)) { }
        ;//マウス中クリック

        //マウスの移動量取得
        //nowRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        //nowRotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;

        //
        //nowRotation.y = Mathf.Clamp(nowRotation.y, minMaxRotation.x, minMaxRotation.y);

        //回転を反映
        //this.transform.rotation = Quaternion.Euler(nowRotation.y, nowRotation.x, 0.0f);
    }
}
