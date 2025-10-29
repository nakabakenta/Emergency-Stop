using UnityEngine;
using static UnityEngine.UI.Image;

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
        //    // �����ɓ���������A���̈ʒu�܂Ő���L�΂�
        //    lineRend.SetPosition(0, this.transform.position);
        //    lineRend.SetPosition(1, hit.point);
        //}
        //else
        //{
        //    // ���ɂ�������Ȃ�������A�ő勗���܂Ő����o��
        //    lineRend.SetPosition(0, this.transform.position);
        //    lineRend.SetPosition(1, this.transform.position + Vector3.down * maxDistance);
        //}
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
