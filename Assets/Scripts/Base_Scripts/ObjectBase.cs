using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //�I�u�W�F�N�g�\����
    [System.Serializable]
    public struct StructObject
    {
        [Header("�X�e�[�^�X(�ϋv,�d��,�e��)")]
        public float endurance; //�ϋv
        public float elasticity;//�e��
    }

    //�\���̕ϐ�
    public StructObject structObj; //�I�u�W�F�N�g

    public float maxDistance;      //�ő勗��

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

    //�����蔻��(OnCollisionStay)
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
