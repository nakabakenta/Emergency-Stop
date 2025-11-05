using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;           //移動速度
    public float objDistance;         //オブジェクトの距離
    public float objPlaceTime;        //オブジェクトの設置時間
    public static float objPlaceTimer;//オブジェクトの設置タイマー
    private int nowCameraMode;        //現在のカメラモード
    private GameObject[] objCamera;   //カメラオブジェクト
    private GameObject nowObj;        //現在のオブジェクト

    public Vector2 minPos, maxPos;    //最小・大位置
    public float addObjRotation;      //オブジェクトに与える回転値
    public float rotationSpeed;       //回転速度値
    public Vector2 rotationLimit;     //回転限界値
    private Vector2 nowAngle;         //現在の角度
    private float maxDistance = 10f;  //最大距離
    private LineRenderer lineRenderer;
    private ObjInfo objInfo;

    private void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        objInfo = this.GetComponent<ObjInfo>();
        objPlaceTimer = 0.0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Stage.status != (int)GameStatus.GameClear || Stage.status != (int)GameStatus.GameOver) PlayerInput();

        if (Stage.status == (int)GameStatus.GameDep)
        {
            lineRenderer.enabled = false;
        }
    }

    void PlayerInput()
    {
        if(Stage.status == (int)GameStatus.GamePrep)
        {
            Vector2 mousePos = Input.mousePosition;//マウス位置を画面座標で取得する
            //画面座標をビューポート座標に変換する
            Vector2 viewPortPos = Camera.main.ScreenToViewportPoint(mousePos);
            //画面限界値を設定する
            viewPortPos.x = Mathf.Clamp(viewPortPos.x, minPos.x, maxPos.x);
            viewPortPos.y = Mathf.Clamp(viewPortPos.y, minPos.y, maxPos.y);
            //ビューポート座標をワールド座標に変換する
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(viewPortPos.x, viewPortPos.y, objDistance));
            worldPos.z = this.transform.position.z - objDistance;//Z軸を固定（オブジェクトのZ軸を調整）

            UIStage.uIStage.SetPos(worldPos);

            if (nowObj == null) nowObj = objInfo.ObjGen(worldPos);
            else
            {
                nowObj.transform.position = worldPos;
                //マウス左クリック
                if (Input.GetMouseButtonDown(0)) nowObj = objInfo.ObjPlace(nowObj);
                //マウスホイールクリック
                if (Input.GetMouseButtonDown(2)) nowObj.transform.rotation = Quaternion.identity;//回転を0にする
                float scrollWheel = Input.GetAxis("Mouse ScrollWheel");                          //マウスホイールの回転量
                if (scrollWheel != 0) nowObj.transform.rotation *= RotationObject(scrollWheel);

                // Raycastを実行
                if (Physics.Raycast(worldPos, Vector3.down, out RaycastHit hit, maxDistance))
                {
                    // 何かに当たったら、その位置まで線を描く
                    lineRenderer.SetPosition(0, worldPos);
                    lineRenderer.SetPosition(1, hit.point);
                }
                else
                {
                    // 何にも当たらなければ、最大距離まで線を描く
                    lineRenderer.SetPosition(0, worldPos);
                    lineRenderer.SetPosition(1, worldPos + Vector3.down * maxDistance);
                }
            }
        }
        else
        {
            if (nowObj != null) Destroy(nowObj);
        }

        //Wキー
        if (Input.GetKey(KeyCode.W)) this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //Aキー
        if (Input.GetKey(KeyCode.A)) this.transform.position -= transform.right * moveSpeed * Time.deltaTime;
        //Sキー
        if (Input.GetKey(KeyCode.S)) this.transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        //Dキー
        if (Input.GetKey(KeyCode.D)) this.transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    Quaternion RotationObject(float scrollWheel)
    {
        Vector3 objectAngle = Vector3.zero;
        bool inputKey = false;//キー入力確認

        if (Input.GetKey(KeyCode.X))//Xキーが押されている場合
        {
            objectAngle.x = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Y))//Yキーが押されている場合
        {
            objectAngle.y = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
            inputKey = true;
        }
        if (Input.GetKey(KeyCode.Z))//Zキーが押されている場合
        {
            objectAngle.z = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
            inputKey = true;
        }
        if(!inputKey)//キー入力がない場合
        {
            objectAngle.y = (scrollWheel > 0) ? addObjRotation : -addObjRotation;
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
