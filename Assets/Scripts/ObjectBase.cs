using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //�I�u�W�F�N�g�\����
    [System.Serializable]
    public struct StructObject
    {
        [Header("�X�e�[�^�X")]
        public float endurance; //�ϋv
        public float weight;    //�d��
        public float elasticity;//�e��
    }

    //�\���̕ϐ�
    public StructObject structObject;//�I�u�W�F�N�g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
