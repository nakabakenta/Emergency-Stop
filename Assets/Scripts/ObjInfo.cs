using UnityEngine;

public class ObjInfo : MonoBehaviour
{
    public GameObject genObj;//��������I�u�W�F�N�g

    public GameObject ObjGen(Vector3 pos)
    {
        Transform parentObj = GameObject.Find("PlaceObj").GetComponent<Transform>(); //�e�I�u�W�F�N�g��Transform���擾����
        GameObject nowObj = Instantiate(genObj, pos, Quaternion.identity, parentObj);//�I�u�W�F�N�g����

        return nowObj;
    }

    public GameObject ObjPlace(GameObject obj)
    {
        BoxCollider collider = obj.GetComponent<BoxCollider>();
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        collider.isTrigger = false; rb.isKinematic = false;
        Stage.nowPutNum--;
        UIStage.uIStage.SetTextObject();

        return null;
    }
}
