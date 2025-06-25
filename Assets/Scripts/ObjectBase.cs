using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    //オブジェクト構造体
    [System.Serializable]
    public struct StructObject
    {
        [Header("ステータス")]
        public float endurance; //耐久
        public float weight;    //重量
        public float elasticity;//弾力
    }

    //構造体変数
    public StructObject structObject;//オブジェクト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
