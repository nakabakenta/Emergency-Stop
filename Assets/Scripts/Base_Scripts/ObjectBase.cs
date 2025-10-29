using UnityEngine;
using static UnityEngine.UI.Image;

public class ObjectBase : MonoBehaviour
{
    //オブジェクト構造体
    [System.Serializable]
    public struct StructObject
    {
        [Header("ステータス(耐久,重量,弾力)")]
        public float endurance; //耐久
        public float elasticity;//弾力
    }

    //構造体変数
    public StructObject structObj; //オブジェクト

    public float maxDistance;      //最大距離

    private float maxSpeed = 10.0f;
    private Rigidbody rb;
    private LineRenderer lineRend;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //GameObject objLineRend = Resources.Load<GameObject>("LineRenderer");
        //lineRend = objLineRend.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, maxDistance))
        //{
        //    // 何かに当たったら、その位置まで線を伸ばす
        //    lineRend.SetPosition(0, this.transform.position);
        //    lineRend.SetPosition(1, hit.point);
        //}
        //else
        //{
        //    // 何にも当たらなかったら、最大距離まで線を出す
        //    lineRend.SetPosition(0, this.transform.position);
        //    lineRend.SetPosition(1, this.transform.position + Vector3.down * maxDistance);
        //}
    }

    //当たり判定(OnCollisionStay)
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Train")
        {
            TrainBase trainBase = collision.gameObject.GetComponent<TrainBase>();
            float force = trainBase.CollisionObject(rb.mass);
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            Vector3 velocity = rb.linearVelocity;

            if (velocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = velocity.normalized * maxSpeed;
            }
        }
    }
}
