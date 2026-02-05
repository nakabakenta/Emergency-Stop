using UnityEngine;

public class ObjInfo : MonoBehaviour
{
    public GameObject genObj;//生成するオブジェクト

    public GameObject ObjGen(Vector3 pos)
    {
        Transform parentObj = GameObject.Find("PlaceObj").GetComponent<Transform>(); //親オブジェクトのTransformを取得する
        GameObject nowObj = Instantiate(genObj, pos, Quaternion.identity, parentObj);//オブジェクト生成

        return nowObj;
    }

    public GameObject ObjPut(GameObject obj)
    {
        BoxCollider collider = obj.GetComponent<BoxCollider>();
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        collider.isTrigger = false; rb.isKinematic = false;

        return null;
    }
}
