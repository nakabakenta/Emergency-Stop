using UnityEngine;

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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
