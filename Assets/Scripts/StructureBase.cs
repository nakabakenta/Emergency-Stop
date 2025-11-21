using System.Collections.Generic;
using UnityEngine;

public class StructureBase : MonoBehaviour
{
    //列車構造体
    [System.Serializable]
    public struct StructStructure
    {
        [Header("ステータス")]
        public float structureHp;//ストラクチャーの体力
        public int score;        //スコア
    }

    //構造体変数
    public StructStructure structStructure;//ストラクチャー

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定(OnCollisionEnter)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Object" && collision.gameObject.tag != "Structure")
        {
            if(this.GetComponent<BoxCollider>() != null)
            {
                Destroy(this.GetComponent<BoxCollider>());

                //自分の全ての子オブジェクトを取得
                foreach (Transform obj in GetComponentsInChildren<Transform>())
                {
                    if (obj == transform) continue; // 自分自身は除外

                    if (!obj.TryGetComponent<MeshCollider>(out var meshCollider))
                    {
                        meshCollider = obj.gameObject.AddComponent<MeshCollider>();
                        meshCollider.convex = true;
                    }

                    if (!obj.TryGetComponent<Rigidbody>(out _))
                    {
                        obj.gameObject.AddComponent<Rigidbody>();
                    }
                }
            }
        }
    }
}
